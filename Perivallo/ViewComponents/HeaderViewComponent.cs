using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Perivallo.DAL;
using Perivallo.Models;
using Perivallo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Perivallo.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly UserManager<User> _userManager;
        private readonly AppDbContext _db;
        public HeaderViewComponent(AppDbContext db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            User currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            NavbarVM model = new NavbarVM()
            {
                FriendRequests = _db.Friends.Include(f => f.FriendFrom).Where(f => f.FriendToId == currentUser.Id && !f.Accepted),
                Notifications=_db.Notifications.Include(n=>n.NotificationFrom).Include(n=>n.Post).Include(n=>n.NotificationType).Where(n=>n.NotificationToId==currentUser.Id).OrderByDescending(n=>n.Date)
            };
            if (User.Identity.IsAuthenticated)
            {
                model.User = currentUser;
            }
            return View(await Task.FromResult(model));
        }

    }
}
