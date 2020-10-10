using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Perivallo.DAL;
using Perivallo.Models;

namespace Perivallo.Areas.Xqcow.Controllers
{
    [Area("Xqcow")]
    [Authorize(Roles = "Admin,Moderator")]
    public class DashboardController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<User> _userManager;
        public DashboardController(AppDbContext db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            DateTime dateNow = DateTime.Now;
            int commentCount = _db.Comments.Count() + _db.Replies.Count();
            int commentsToday = _db.Comments.Where(c => c.Date.AddDays(1) >= dateNow).Count() + _db.Replies.Where(r => r.Date.AddDays(1) >= dateNow).Count();
            int adminCount = 0;
            int modCount = 0;
            int normalUserCount = 0;
            foreach (User user in _db.Users.Where(u=>!u.Deleted))
            {
                if ((await _userManager.GetRolesAsync(user))[0] == "Admin")
                {
                    adminCount++;
                }
                else if ((await _userManager.GetRolesAsync(user))[0] == "Moderator")
                {
                    modCount++;
                }
                else if((await _userManager.GetRolesAsync(user))[0] == "User")
                {
                    normalUserCount++;
                }
            }
            ViewBag.TotalUserCount = _db.Users.Count();
            ViewBag.TotalPostCount = _db.Posts.Count();
            ViewBag.TotalCommentCount = commentCount;
            ViewBag.TotalMessageCount = _db.Messages.Count();
            ViewBag.BannedUsersCount = _db.Users.Where(u => u.Deleted).Count();
            ViewBag.AdminCount = adminCount;
            ViewBag.ModCount = modCount;
            ViewBag.NormalUserCount = normalUserCount;
            ViewBag.RegsToday = _db.Users.Where(u=>u.RegDate.AddDays(1)>=dateNow).Count();
            ViewBag.RegsWeek = _db.Users.Where(u => u.RegDate.AddDays(7) >= dateNow).Count();
            ViewBag.PostsToday = _db.Posts.Where(p => p.Date.AddDays(1) >= dateNow).Count();
            ViewBag.CommentsToday = commentsToday;
            ViewBag.MessagesToday=_db.Messages.Where(m => m.Date.AddDays(1) >= dateNow).Count();
            ViewBag.PostReportsCount = _db.PostReports.Count();
            ViewBag.CommentReportsCount = _db.CommentReports.Count();
            ViewBag.UserReportsCount = _db.UserReports.Count();
            return View();
        }
    }
}
