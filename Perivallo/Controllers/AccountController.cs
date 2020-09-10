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
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _db;
        private readonly IHostingEnvironment _env;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager, AppDbContext db, IHostingEnvironment env)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _db = db;
            _env = env;
        }

        [Authorize]
        [Route("p/{username}")]
        public async Task<IActionResult> Index(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return NotFound();
            }
            User user = await _userManager.FindByNameAsync(username);
            if (user == null || user.Deleted)
            {
                return NotFound();
            }
            User currentUser = await _userManager.GetUserAsync(User);
            List<User> friends = new List<User>();
            foreach (Friend item in _db.Friends.Include(f => f.FriendTo).Include(f => f.FriendFrom).Where(f => f.Accepted))
            {
                if (item.FriendFrom == user)
                {
                    friends.Add(item.FriendTo);
                }
                else if (item.FriendTo == user)
                {
                    friends.Add(item.FriendFrom);
                }
            }
            ViewBag.FriendsCount = friends.Count();
            AccountVM model = new AccountVM()
            {
                User = user,
                Posts = _db.Posts.Include(p => p.User).Include(p => p.PostTaggedUsers).Include(p => p.PostLikes).Include(p => p.PostImages).Include(p=>p.SavedPosts).Include(p=>p.Comments).Where(p => p.UserId == user.Id).OrderByDescending(p => p.Id),
                PostTaggedUsers = _db.PostTaggedUsers.Include(p => p.User),
                CurrentUserRole = (await _userManager.GetRolesAsync(currentUser))[0]
            };
            int postCount = _db.Posts.Where(p => p.User == user).Count();
            ViewBag.PostCount = postCount;
            foreach (User f in friends)
            {
                if (currentUser==f)
                {
                    ViewBag.IsFriend = 8;
                }
            }
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Register")]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.RegError = 1;
                return View(register);
            }

            User user = new User
            {
                Name = register.Name,
                UserName = register.Username,
                Email = register.Email,
                RegDate = DateTime.Now
            };

            IdentityResult identityResult = await _userManager.CreateAsync(user, register.Password);

            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                ViewBag.RegError = 1;
                return View(register);
            }
            await _userManager.AddToRoleAsync(user, Helpers.Extensions.Role.User.ToString());
            await _signInManager.SignInAsync(user, true);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Login")]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if (!ModelState.IsValid) return View(login);
            User user = await _userManager.FindByEmailAsync(login.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Email or Password is incorrect!!!");
                return View(login);
            }
            if (user.Deleted == true)
            {
                ModelState.AddModelError(string.Empty, "This user has been deleted");
                return View(login);
            }

            Microsoft.AspNetCore.Identity.SignInResult signInResult;
            if (login.Checked)
            {
                signInResult = await _signInManager.PasswordSignInAsync(user, login.Password, true, true);
            }
            else
            {
                signInResult = await _signInManager.PasswordSignInAsync(user, login.Password, false, true);
            }

            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Email or Password is incorrect!!!");
                return View(login);
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task CreateRole()
        {
            if (!await _roleManager.RoleExistsAsync(Helpers.Extensions.Role.Admin.ToString()))
            {
                await _roleManager.CreateAsync(new IdentityRole(Helpers.Extensions.Role.Admin.ToString()));
            }

            if (!await _roleManager.RoleExistsAsync(Helpers.Extensions.Role.Moderator.ToString()))
            {
                await _roleManager.CreateAsync(new IdentityRole(Helpers.Extensions.Role.Moderator.ToString()));
            }

            if (!await _roleManager.RoleExistsAsync(Helpers.Extensions.Role.User.ToString()))
            {
                await _roleManager.CreateAsync(new IdentityRole(Helpers.Extensions.Role.User.ToString()));
            }
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        [Authorize]
        public async Task<IActionResult> Settings()
        {
            User user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }
            UserVM userVM = new UserVM()
            {
                Name = user.Name,
                Username = user.UserName,
                Email = user.Email,
                Avatar = user.Avatar,
                Cover = user.Cover,
                About = user.About,
                Private = user.Private
            };
            return View(userVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Settings(UserVM user, IFormFile avatar, IFormFile cover)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            User currentUser = await _userManager.GetUserAsync(User);
            if (avatar != null)
            {
                if (!avatar.isImage())
                {
                    ModelState.AddModelError(string.Empty, "Please pick a file matching the format!");
                    return View(user);
                }
                currentUser.Avatar = await avatar.SaveImg(_env.WebRootPath, "img");
            }
            if (cover != null)
            {
                if (!cover.isImage())
                {
                    ModelState.AddModelError(string.Empty, "Please pick a file matching the format!");
                    return View(user);
                }
                currentUser.Cover = await cover.SaveImg(_env.WebRootPath, "img");
            }

            currentUser.Name = user.Name;
            currentUser.Email = user.Email;
            currentUser.About = user.About;
            currentUser.Private = user.Private;
            currentUser.UserName = user.Username;
            if (user.Password != null)
            {
                currentUser.PasswordHash = _userManager.PasswordHasher.HashPassword(currentUser, user.Password);
            }
            await _userManager.UpdateAsync(currentUser);
            await _signInManager.SignInAsync(currentUser, true);
            return RedirectToAction("Index", new { username = currentUser.UserName });
        }

        [Authorize]
        [Route("p/oldest/{username}")]
        public async Task<IActionResult> Oldest(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return NotFound();
            }
            User user = await _userManager.FindByNameAsync(username);
            if (user == null || user.Deleted)
            {
                return NotFound();
            }
            User currentUser = await _userManager.GetUserAsync(User);
            List<User> friends = new List<User>();
            foreach (Friend item in _db.Friends.Include(f => f.FriendTo).Include(f => f.FriendFrom).Where(f => f.Accepted))
            {
                if (item.FriendFrom == user)
                {
                    friends.Add(item.FriendTo);
                }
                else if (item.FriendTo == user)
                {
                    friends.Add(item.FriendFrom);
                }
            }
            ViewBag.FriendsCount = friends.Count();
            AccountVM model = new AccountVM()
            {
                User = user,
                Posts = _db.Posts.Include(p => p.User).Include(p => p.PostTaggedUsers).Include(p => p.PostImages).Where(p => p.UserId == user.Id),
                PostTaggedUsers = _db.PostTaggedUsers.Include(p => p.User),
                CurrentUserRole = (await _userManager.GetRolesAsync(currentUser))[0]
            };
            int postCount = _db.Posts.Where(p => p.User == user).Count();
            ViewBag.PostCount = postCount;
            foreach (User f in friends)
            {
                if (currentUser == f)
                {
                    ViewBag.IsFriend = 8;
                }
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> RemoveCover()
        {
            User user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }
            user.Cover = null;
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Settings", "Account", new { username = user.UserName });
        }

        [Authorize]
        public async Task<IActionResult> RemoveAvatar()
        {
            User user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }
            user.Avatar = null;
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Settings", "Account", new { username = user.UserName });
        }

        [Authorize]
        public async Task<IActionResult> Tagged(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return NotFound();
            }
            User user = await _userManager.FindByNameAsync(username);
            User currentUser = await _userManager.GetUserAsync(User);
            if (user==null)
            {
                return NotFound();
            }
            List<PostTaggedUser> postTagged = _db.PostTaggedUsers.Where(p => p.UserId == user.Id).ToList();
            List<Post> posts = new List<Post>();
            List<User> friends = new List<User>();
            foreach (Friend item in _db.Friends.Include(f => f.FriendTo).Include(f => f.FriendFrom).Where(f => f.Accepted))
            {
                if (item.FriendFrom == user)
                {
                    friends.Add(item.FriendTo);
                }
                else if (item.FriendTo == user)
                {
                    friends.Add(item.FriendFrom);
                }
            }
            bool isFriend = false;
            foreach (User f in friends)
            {
                if (currentUser == f)
                {
                    isFriend = true;
                }
            }
            if (user.Private && !isFriend && user != currentUser)
            {
                return NotFound();
            }
            foreach (PostTaggedUser item in postTagged)
            {
                posts.Add(_db.Posts.Include(p => p.User).Include(p => p.PostTaggedUsers).Include(p => p.PostLikes).Include(p => p.PostImages).Include(p=>p.SavedPosts).Include(p=>p.Comments).FirstOrDefault(p=>p.Id==item.PostId));
            }
            AccountVM model = new AccountVM()
            {
                User = user,
                Posts = posts.OrderByDescending(p => p.Date),
                PostTaggedUsers = _db.PostTaggedUsers.Include(p => p.User),
                CurrentUserRole = (await _userManager.GetRolesAsync(currentUser))[0]
            };
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Friends(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return NotFound();
            }
            User user = await _userManager.FindByNameAsync(username);
            User currentUser= await _userManager.GetUserAsync(User);
            if (user==null)
            {
                return NotFound();
            }
            List<User> friends = new List<User>();
            foreach (Friend item in _db.Friends.Include(f => f.FriendTo).Include(f => f.FriendFrom).Where(f => f.Accepted))
            {
                if (item.FriendFrom == user)
                {
                    friends.Add(item.FriendTo);
                }
                else if (item.FriendTo == user)
                {
                    friends.Add(item.FriendFrom);
                }
            }
            bool isFriend = false;
            foreach (User f in friends)
            {
                if (currentUser == f)
                {
                    isFriend = true;
                }
            }
            if (user.Private&&!isFriend&&user!=currentUser)
            {
                return NotFound();
            }
            AccountVM model = new AccountVM()
            {
                User = user,
                Friends = friends
            };
            int postCount = _db.Posts.Where(p => p.User == user).Count();
            ViewBag.PostCount = postCount;
            ViewBag.FriendsCount = friends.Count();
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Saved()
        {
            User user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }
            List<Post> posts = new List<Post>();
            List<SavedPost> savedPosts = _db.SavedPosts.Where(p => p.UserId == user.Id).ToList();
            foreach (SavedPost item in savedPosts)
            {
                posts.Add(_db.Posts.Include(p => p.User).Include(p => p.PostTaggedUsers).Include(p => p.PostLikes).Include(p => p.PostImages).Include(p=>p.SavedPosts).Include(p=>p.Comments).FirstOrDefault(p => p.Id == item.PostId));
            }
            AccountVM model = new AccountVM()
            {
                User = user,
                Posts = posts.OrderByDescending(p=>p.Date),
                PostTaggedUsers=_db.PostTaggedUsers.Include(p=>p.User),
                CurrentUserRole = (await _userManager.GetRolesAsync(user))[0]
            };
            return View(model);
        }
    }
}
