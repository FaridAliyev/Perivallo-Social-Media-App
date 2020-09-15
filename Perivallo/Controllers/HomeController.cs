using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Perivallo.DAL;
using Perivallo.Helpers;
using Perivallo.Models;
using Perivallo.ViewModels;

namespace Perivallo.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<User> _userManager;
        private readonly IHostingEnvironment _env;
        public HomeController(AppDbContext db, UserManager<User> userManager, IHostingEnvironment env)
        {
            _db = db;
            _userManager = userManager;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            User currentUser = await _userManager.GetUserAsync(User);
            HomeVM model = new HomeVM();
            if (User.Identity.IsAuthenticated)
            {
                model.User = currentUser;
            }
            List<User> friends = new List<User>();
            foreach (Friend item in _db.Friends.Include(f=>f.FriendTo).Include(f=>f.FriendFrom).Where(f=>f.Accepted&&!f.FriendFrom.Deleted&&!f.FriendTo.Deleted))
            {
                if (item.FriendFrom==currentUser)
                {
                    friends.Add(item.FriendTo);
                }
                else if (item.FriendTo == currentUser)
                {
                    friends.Add(item.FriendFrom);
                }
            }
            friends.Add(currentUser);
            List<Post> posts = new List<Post>();
            foreach (User friend in friends)
            {
                posts.AddRange(_db.Posts.Include(p => p.User).Include(p => p.PostTaggedUsers).Include(p => p.PostImages).Include(p => p.PostLikes).Include(p=>p.SavedPosts).Include(p=>p.Comments).Where(p => p.User == friend));
            }
            List<User> suggestedfriends = new List<User>();
            bool isFriend = false;
            foreach (User u in _db.Users.Include(u=>u.Posts).Where(u=>!u.Deleted))
            {
                isFriend = false;
                foreach (User f in friends)
                {
                    if (u==f)
                    {
                        isFriend = true;
                    }
                }
                if (!isFriend)
                {
                    suggestedfriends.Add(u);
                }
            }
            model.Users = _db.Users.Where(u=>!u.Deleted);
            model.Posts = posts.OrderByDescending(f=>f.Date);
            model.Role = (await _userManager.GetRolesAsync(currentUser))[0];
            model.SuggestedUsers = suggestedfriends.OrderByDescending(s=>s.Posts.Count());
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Index")]
        public async Task<IActionResult> CreatePost(HomeVM homeVM,IFormFile[] postFiles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            foreach (IFormFile item in postFiles)
            {
                if (!item.isImage())
                {
                    return BadRequest();
                }
            }
            if (string.IsNullOrEmpty(homeVM.Post.Text.Trim()) && string.IsNullOrEmpty(homeVM.Post.Link.Trim()) && postFiles.Length == 0)
            {
                return BadRequest();
            }
            Post post = homeVM.Post;
            post.Date = DateTime.Now;
            User user = await _userManager.GetUserAsync(User);
            post.User = user;
            string tagged = Request.Form["tags"];
            if (tagged != null)
            {
                string[] taggedUsersIds = tagged.Split(",");
                List<PostTaggedUser> postTaggedUsers = new List<PostTaggedUser>();
                List<Notification> notifications = new List<Notification>();
                foreach (string id in taggedUsersIds)
                {
                    postTaggedUsers.Add(new PostTaggedUser
                    {
                        UserId=id,
                        Post=post
                    });
                    notifications.Add(new Notification
                    {
                        Date=DateTime.Now,
                        NotificationFromId=user.Id,
                        NotificationToId=id,
                        Post=post,
                        NotificationTypeId=4
                    });
                }
                post.PostTaggedUsers = postTaggedUsers;
                post.Notifications = notifications;
            }
            foreach (IFormFile item in postFiles)
            {
                PostImage postImage = new PostImage()
                {
                    Image=await item.SaveImg(_env.WebRootPath,"img"),
                    Post=post
                };
                _db.PostImages.Add(postImage);
            }
            _db.Posts.Add(post);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Search(string term)
        {
            List<User> users = _userManager.Users.Where(u => u.Deleted == false).Take(20).ToList();
            List<UserVM> model = new List<UserVM>();
            foreach (User user in users)
            {
                if (user.UserName.ToLower().Contains(term.ToLower()) || user.Name.ToLower().Contains(term.ToLower()))
                {
                    model.Add(new UserVM
                    {
                        Name = user.Name,
                        Username = user.UserName,
                        Avatar=user.Avatar
                    });
                }
            }
            return PartialView("_UserSearch", model);
        }

        public async Task<int> PostLike(int? id)
        {
            if (id == null)
            {
                return 0;
            }
            Post post = await _db.Posts.FindAsync(id);
            if (post == null)
            {
                return 0;
            }
            User currentUser = await _userManager.GetUserAsync(User);
            PostLike postLike = new PostLike()
            {
                UserId = currentUser.Id,
                PostId = (int)id
            };
            if (currentUser.Id!=post.UserId)
            {
                Notification notification = new Notification()
                {
                    Date = DateTime.Now,
                    NotificationFromId = currentUser.Id,
                    NotificationToId = post.UserId,
                    PostId = (int)id,
                    NotificationTypeId = 1
                };
                _db.Notifications.Add(notification);
            }
            _db.PostLikes.Add(postLike);
            await _db.SaveChangesAsync();
            int newLikesCount = _db.PostLikes.Where(p => p.PostId == id).Count();
            return newLikesCount;
        }

        public async Task<int> PostDislike(int? id)
        {
            if (id == null)
            {
                return -1;
            }
            Post post = await _db.Posts.FindAsync(id);
            if (post == null)
            {
                return -1;
            }
            User currentUser = await _userManager.GetUserAsync(User);
            PostLike postLike = _db.PostLikes.Where(p => p.UserId == currentUser.Id && p.PostId == id).FirstOrDefault();
            if (currentUser.Id != post.UserId)
            {
                Notification notification = _db.Notifications.Where(n => n.NotificationFromId == currentUser.Id && n.NotificationToId == post.UserId && n.PostId == post.Id && n.NotificationTypeId == 1).FirstOrDefault();
                _db.Notifications.Remove(notification);
            }
            _db.PostLikes.Remove(postLike);
            await _db.SaveChangesAsync();
            int newLikesCount = _db.PostLikes.Where(p => p.PostId == id).Count();
            return newLikesCount;
        }

        public async Task<int> SavePost(int? id)
        {
            if (id == null)
            {
                return 0;
            }
            Post post = await _db.Posts.FindAsync(id);
            if (post == null)
            {
                return 0;
            }
            User currentUser = await _userManager.GetUserAsync(User);
            SavedPost saved = new SavedPost()
            {
                UserId = currentUser.Id,
                PostId = (int)id
            };
            _db.SavedPosts.Add(saved);
            await _db.SaveChangesAsync();
            return 1;
        }

        public async Task<int> UnsavePost(int? id)
        {
            if (id == null)
            {
                return 0;
            }
            Post post = await _db.Posts.FindAsync(id);
            if (post == null)
            {
                return 0;
            }
            User currentUser = await _userManager.GetUserAsync(User);
            SavedPost saved = _db.SavedPosts.Where(p => p.UserId == currentUser.Id && p.PostId == id).FirstOrDefault();
            _db.SavedPosts.Remove(saved);
            await _db.SaveChangesAsync();
            return 1;
        }

        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            Post post = await _db.Posts.FindAsync(id);
            if (post==null)
            {
                return NotFound();
            }
            User currentUser = await _userManager.GetUserAsync(User);
            string currentUserRole = (await _userManager.GetRolesAsync(currentUser))[0];
            if (post.UserId!=currentUser.Id)
            {
                if (currentUserRole != "Admin" && currentUserRole!="Moderator")
                {
                    return NotFound();
                }
            }
            foreach (PostLike pl in _db.PostLikes)
            {
                if (pl.PostId==post.Id)
                {
                    _db.PostLikes.Remove(pl);
                }
            }
            foreach (PostImage pi in _db.PostImages)
            {
                if (pi.PostId==post.Id)
                {
                    _db.PostImages.Remove(pi);
                }
            }
            foreach (PostTaggedUser ptu in _db.PostTaggedUsers)
            {
                if (ptu.PostId==post.Id)
                {
                    _db.PostTaggedUsers.Remove(ptu);
                }
            }
            foreach (SavedPost sp in _db.SavedPosts)
            {
                if (sp.PostId==post.Id)
                {
                    _db.SavedPosts.Remove(sp);
                }
            }
            foreach (Comment c in _db.Comments)
            {
                if (c.PostId == post.Id)
                {
                    _db.Comments.Remove(c);
                }
            }
            _db.Posts.Remove(post);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> DeleteComment(int? id,string returnUrl)
        {
            if (id == null)
            {
                return NotFound();
            }
            Comment comment = await _db.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            User currentUser = await _userManager.GetUserAsync(User);
            string currentUserRole = (await _userManager.GetRolesAsync(currentUser))[0];
            if (comment.UserId != currentUser.Id)
            {
                if (currentUserRole != "Admin" && currentUserRole != "Moderator")
                {
                    return NotFound();
                }
            }
            _db.Comments.Remove(comment);
            await _db.SaveChangesAsync();
            return LocalRedirect(returnUrl);
        }

        public async Task<IActionResult> SendRequest(string id, string returnUrl)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
            User user = await _userManager.FindByIdAsync(id);
            User currentUser = await _userManager.GetUserAsync(User);
            if (user == null || user == currentUser)
            {
                return BadRequest();
            }
            Friend friend = new Friend()
            {
                FriendFromId = currentUser.Id,
                FriendToId = user.Id
            };
            _db.Friends.Add(friend);
            await _db.SaveChangesAsync();
            return LocalRedirect(returnUrl);
        }

        public async Task<IActionResult> RevertRequest(string id, string returnUrl)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
            User user = await _userManager.FindByIdAsync(id);
            User currentUser = await _userManager.GetUserAsync(User);
            if (user == null|| user == currentUser)
            {
                return BadRequest();
            }
            Friend friend = _db.Friends.Where(f => f.FriendFromId == currentUser.Id && f.FriendToId == user.Id).FirstOrDefault();
            _db.Friends.Remove(friend);
            await _db.SaveChangesAsync();
            return LocalRedirect(returnUrl);
        }

        public async Task<IActionResult> Unfriend(string id, string returnUrl)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
            User user = await _userManager.FindByIdAsync(id);
            User currentUser = await _userManager.GetUserAsync(User);
            if (user == null || user == currentUser)
            {
                return BadRequest();
            }
            foreach (Friend item in _db.Friends.Where(f=>f.Accepted))
            {
                if (item.FriendFromId==user.Id)
                {
                    if (item.FriendToId==currentUser.Id)
                    {
                        _db.Friends.Remove(item);
                    }
                }
                else if (item.FriendToId == user.Id)
                {
                    if (item.FriendFromId==currentUser.Id)
                    {
                        _db.Friends.Remove(item);
                    }
                }
            }
            await _db.SaveChangesAsync();
            return LocalRedirect(returnUrl);
        }

        public async Task<IActionResult> ConfirmRequest(string id, string returnUrl)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
            User user = await _userManager.FindByIdAsync(id);
            User currentUser = await _userManager.GetUserAsync(User);
            if (user == null || user == currentUser)
            {
                return BadRequest();
            }
            Friend friend = _db.Friends.Where(f => f.FriendFromId == user.Id && f.FriendToId == currentUser.Id).FirstOrDefault();
            friend.Accepted = true;
            await _db.SaveChangesAsync();
            return LocalRedirect(returnUrl);
        }

        public async Task<IActionResult> IgnoreRequest(string id, string returnUrl)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
            User user = await _userManager.FindByIdAsync(id);
            User currentUser = await _userManager.GetUserAsync(User);
            if (user == null || user == currentUser)
            {
                return BadRequest();
            }
            Friend friend = _db.Friends.Where(f => f.FriendFromId == user.Id && f.FriendToId == currentUser.Id).FirstOrDefault();
            _db.Friends.Remove(friend);
            await _db.SaveChangesAsync();
            return LocalRedirect(returnUrl);
        }

        public async Task<IActionResult> ConfirmAll(string returnUrl)
        {
            User currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return BadRequest();
            }
            foreach (Friend item in _db.Friends.Where(f=>f.FriendToId==currentUser.Id&&!f.Accepted))
            {
                item.Accepted = true;
            }
            await _db.SaveChangesAsync();
            return LocalRedirect(returnUrl);
        }

        public async Task<IActionResult> IgnoreAll(string returnUrl)
        {
            User currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return BadRequest();
            }
            foreach (Friend item in _db.Friends.Where(f => f.FriendToId == currentUser.Id && !f.Accepted))
            {
                _db.Friends.Remove(item);
            }
            await _db.SaveChangesAsync();
            return LocalRedirect(returnUrl);
        }

        public async Task<int> ReportPost(int? id,string text)
        {
            if (id == null)
            {
                return 0;
            }
            Post post = await _db.Posts.FindAsync(id);
            User currentUser = await _userManager.GetUserAsync(User);
            if (post == null || currentUser.Id == post.UserId||string.IsNullOrEmpty(text.Trim()))
            {
                return 0;
            }
            PostReport report = new PostReport()
            {
                Date = DateTime.Now,
                ReportFromId = currentUser.Id,
                PostId = (int)id,
                Reason=text
            };
            _db.PostReports.Add(report);
            await _db.SaveChangesAsync();
            return 1;
        }

        public async Task<int> ReportComment(int? id, string text)
        {
            if (id == null)
            {
                return 0;
            }
            Comment comment = await _db.Comments.FindAsync(id);
            User currentUser = await _userManager.GetUserAsync(User);
            if (comment == null || currentUser.Id == comment.UserId || string.IsNullOrEmpty(text.Trim()))
            {
                return 0;
            }
            CommentReport report = new CommentReport()
            {
                Date = DateTime.Now,
                ReportFromId = currentUser.Id,
                CommentId = (int)id,
                Reason = text
            };
            _db.CommentReports.Add(report);
            await _db.SaveChangesAsync();
            return 1;
        }

        public async Task<int> ReportUser(string id, string text)
        {
            if (string.IsNullOrEmpty(id))
            {
                return 0;
            }
            User user = await _userManager.FindByIdAsync(id);
            User currentUser = await _userManager.GetUserAsync(User);
            if (user == null || currentUser.Id == user.Id || string.IsNullOrEmpty(text.Trim()))
            {
                return 0;
            }
            UserReport report = new UserReport()
            {
                Date = DateTime.Now,
                ReportFromId = currentUser.Id,
                ReportToId = id,
                Reason = text
            };
            _db.UserReports.Add(report);
            await _db.SaveChangesAsync();
            return 1;
        }
    }
}
