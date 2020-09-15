using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Perivallo.Areas.Xqcow.ViewModels;
using Perivallo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Perivallo.Areas.Xqcow.ViewComponents
{
    public class SidebarViewComponent:ViewComponent
    {
        private readonly UserManager<User> _userManager;
        public SidebarViewComponent(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            User user = await _userManager.FindByNameAsync(User.Identity.Name);

            SidebarVM model = new SidebarVM()
            {
                Role = (await _userManager.GetRolesAsync(user))[0]
            };

            return View(await Task.FromResult(model));
        }
    }
}
