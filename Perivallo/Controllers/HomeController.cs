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
            //List<Friend> friend = _db.Friends.Where(f => f.FriendFrom == currentUser || f.FriendTo == currentUser).ToList();
            HomeVM model = new HomeVM();
            if (User.Identity.IsAuthenticated)
            {
                model.User = await _userManager.FindByNameAsync(User.Identity.Name);
            }
            model.Users = _db.Users;
            model.Posts = _db.Posts.Include(p => p.User).Include(p => p.PostTaggedUsers).Include(p => p.PostImages).Where(p => p.UserId == currentUser.Id).OrderByDescending(p => p.Id);
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
    }
}
