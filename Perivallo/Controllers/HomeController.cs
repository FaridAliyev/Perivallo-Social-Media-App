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
            model.Users = _db.Users;
            model.Posts = _db.Posts.Include(p => p.User).Include(p => p.PostTaggedUsers).Include(p => p.PostImages).Include(p=>p.PostLikes).Where(p => p.UserId == currentUser.Id).OrderByDescending(p => p.Id);
            model.Role = (await _userManager.GetRolesAsync(currentUser))[0];
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
    }
}
