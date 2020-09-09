using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Perivallo.Models;
using Perivallo.ViewModels;

namespace Perivallo.Controllers
{
    [Authorize]
    public class SearchController : Controller
    {
        private readonly UserManager<User> _userManager;
        public SearchController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Filter(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return RedirectToAction("Index","Search");
            }
            List<User> users = _userManager.Users.Where(u => u.Deleted == false).ToList();
            List<UserVM> model = new List<UserVM>();
            foreach (User user in users)
            {
                if (user.UserName.ToLower().Contains(search.ToLower()) || user.Name.ToLower().Contains(search.ToLower()))
                {
                    model.Add(new UserVM
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Username = user.UserName,
                        Avatar = user.Avatar
                    });
                }
            }
            return View(model);
        }
    }
}
