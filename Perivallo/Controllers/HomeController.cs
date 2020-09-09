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
            foreach (Friend item in _db.Friends.Include(f=>f.FriendTo).Include(f=>f.FriendFrom).Where(f=>f.Accepted))
            {
                if (item.FriendFrom==currentUser)
                {
                    friends.Add(item.FriendTo);
                }
                else if (item.FriendTo == currentUser)
                {
                    friends.Add(item.FriendFrom);
                }
                friends.Add(currentUser);
            }
            List<Post> posts = new List<Post>();
            foreach (User friend in friends)
            {
                posts.AddRange(_db.Posts.Include(p => p.User).Include(p => p.PostTaggedUsers).Include(p => p.PostImages).Include(p => p.PostLikes).Where(p => p.User == friend));
            }
            List<User> suggestedfriends = new List<User>();
            bool isFriend = false;
            foreach (User u in _db.Users.Include(u=>u.Posts))
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
            model.Users = _db.Users;
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
            Post post = homeVM.Post;
            post.Date = DateTime.Now;
            User user = await _userManager.GetUserAsync(User);
            post.User = user;
            string tagged = Request.Form["tags"];
            if (tagged != null)
            {
                string[] taggedUsersIds = tagged.Split(",");
                List<PostTaggedUser> postTaggedUsers = new List<PostTaggedUser>();
                foreach (string id in taggedUsersIds)
                {
                    postTaggedUsers.Add(new PostTaggedUser
                    {
                        UserId=id,
                        Post=post
                    });
                }
                post.PostTaggedUsers = postTaggedUsers;
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
            _db.PostLikes.Remove(postLike);
            await _db.SaveChangesAsync();
            int newLikesCount = _db.PostLikes.Where(p => p.PostId == id).Count();
            return newLikesCount;
        }

        public async Task<IActionResult> DeletePost(int? id,string returnUrl)
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
            if (post.User!=currentUser)
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
            _db.Posts.Remove(post);
            await _db.SaveChangesAsync();
            return LocalRedirect(returnUrl);
        }
    }
}
