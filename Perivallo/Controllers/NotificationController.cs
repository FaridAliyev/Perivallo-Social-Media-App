using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Perivallo.DAL;
using Perivallo.Models;
using Perivallo.ViewModels;

namespace Perivallo.Controllers
{
    [Authorize]
    public class NotificationController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly AppDbContext _db;
        public NotificationController(AppDbContext db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            User currentUser = await _userManager.GetUserAsync(User);
            NavbarVM model = new NavbarVM()
            {
                FriendRequests = _db.Friends.Include(f=>f.FriendFrom).Where(f => f.FriendToId == currentUser.Id && !f.Accepted),
                Notifications = _db.Notifications.Include(n => n.NotificationFrom).Include(n => n.Post).Include(n => n.NotificationType).Where(n => n.NotificationToId == currentUser.Id).OrderByDescending(n => n.Date)
            };
            return View(model);
        }
    }
}
