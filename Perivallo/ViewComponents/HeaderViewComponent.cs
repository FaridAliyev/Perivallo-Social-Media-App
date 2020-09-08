using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
            NavbarVM model = new NavbarVM();
            if (User.Identity.IsAuthenticated)
            {
                model.User = await _userManager.FindByNameAsync(User.Identity.Name);
            }
            return View(await Task.FromResult(model));
        }

    }
}
