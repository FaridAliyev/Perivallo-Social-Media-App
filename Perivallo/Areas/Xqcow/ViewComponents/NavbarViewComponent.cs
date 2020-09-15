using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Perivallo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Perivallo.Areas.Xqcow.ViewComponents
{
    public class NavbarViewComponent:ViewComponent
    {
        private readonly UserManager<User> _userManager;
        public NavbarViewComponent(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            User user = await _userManager.FindByNameAsync(User.Identity.Name);
            return View(await Task.FromResult(user));
        }
    }
}
