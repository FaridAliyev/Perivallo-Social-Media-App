using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Perivallo.Areas.Xqcow.ViewModels;
using Perivallo.Models;

namespace Perivallo.Areas.Xqcow.Controllers
{
    [Area("Xqcow")]
    [Authorize(Roles = "Admin")]
    public class AccController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            List<User> users = _userManager.Users.Where(u => u.Deleted == false).ToList();
            List<ApUserVM> userVMs = new List<ApUserVM>();
            foreach (User user in users)
            {
                userVMs.Add(new ApUserVM
                {
                    Id=user.Id,
                    Name = user.Name,
                    Username = user.UserName,
                    Email = user.Email,
                    Role = (await _userManager.GetRolesAsync(user))[0]
                });
            }
            return View(userVMs);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            User user = await _userManager.FindByIdAsync(id);
            if (user == null || user.Deleted || user.UserName == User.Identity.Name)
            {
                return NotFound();
            }
            ApUserVM model = new ApUserVM()
            {
                Name = user.Name,
                Username = user.UserName,
                Email = user.Email,
                Role = (await _userManager.GetRolesAsync(user))[0],
                Roles = _roleManager.Roles.ToList()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, ApUserVM apUserVM)
        {
            if (!ModelState.IsValid)
            {
                return View(new ApUserVM
                {
                    Roles = _roleManager.Roles.ToList()
                });
            }
            if (id == null)
            {
                return NotFound();
            }
            User user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            user.Name = apUserVM.Name;
            user.UserName = apUserVM.Username;
            user.Email = apUserVM.Email;
            string role = (await _userManager.GetRolesAsync(user))[0];
            string newRole = Request.Form["role"];
            if (apUserVM.Password != null)
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, apUserVM.Password);
            }
            IdentityResult identityResult = await _userManager.UpdateAsync(user);
            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(new ApUserVM
                {
                    Name = user.Name,
                    Username = user.UserName,
                    Email = user.Email,
                    Role = (await _userManager.GetRolesAsync(user))[0],
                    Roles = _roleManager.Roles.ToList()
                });
            }
            if (role != newRole)
            {
                await _userManager.RemoveFromRoleAsync(user, role);
                await _userManager.AddToRoleAsync(user, newRole);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AdminUsers()
        {
            List<User> users = _userManager.Users.Where(u => u.Deleted == false).ToList();
            List<ApUserVM> userVMs = new List<ApUserVM>();
            foreach (User user in users)
            {
                if ((await _userManager.GetRolesAsync(user))[0] == "Admin")
                {
                    userVMs.Add(new ApUserVM
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Username = user.UserName,
                        Email = user.Email,
                        Role = (await _userManager.GetRolesAsync(user))[0]
                    });
                }
            }
            return View(userVMs);
        }

        public async Task<IActionResult> Moderators()
        {
            List<User> users = _userManager.Users.Where(u => u.Deleted == false).ToList();
            List<ApUserVM> userVMs = new List<ApUserVM>();
            foreach (User user in users)
            {
                if ((await _userManager.GetRolesAsync(user))[0] == "Moderator")
                {
                    userVMs.Add(new ApUserVM
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Username = user.UserName,
                        Email = user.Email,
                        Role = (await _userManager.GetRolesAsync(user))[0]
                    });
                }
            }
            return View(userVMs);
        }

        public async Task<IActionResult> NormalUsers()
        {
            List<User> users = _userManager.Users.Where(u => u.Deleted == false).ToList();
            List<ApUserVM> userVMs = new List<ApUserVM>();
            foreach (User user in users)
            {
                if ((await _userManager.GetRolesAsync(user))[0] == "User")
                {
                    userVMs.Add(new ApUserVM
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Username = user.UserName,
                        Email = user.Email,
                        Role = (await _userManager.GetRolesAsync(user))[0]
                    });
                }
            }
            return View(userVMs);
        }

        public async Task<IActionResult> Blocked()
        {
            List<User> users = _userManager.Users.Where(u => u.Deleted == true).ToList();
            List<ApUserVM> userVMs = new List<ApUserVM>();
            foreach (User user in users)
            {
                userVMs.Add(new ApUserVM
                {
                    Id = user.Id,
                    Name = user.Name,
                    Username = user.UserName,
                    Email = user.Email,
                    Role = (await _userManager.GetRolesAsync(user))[0]
                });
            }
            return View(userVMs);
        }

        public async Task<IActionResult> Activate(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            User user = await _userManager.FindByIdAsync(id);
            if (user == null || !user.Deleted)
            {
                return NotFound();
            }
            user.Deleted = false;
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Blocked");
        }

        public async Task<IActionResult> Search(string term)
        {
            List<User> users = _userManager.Users.Where(u=>!u.Deleted).ToList();
            List<ApUserVM> model = new List<ApUserVM>();
            foreach (User user in users)
            {
                if (user.UserName.Contains(term) || user.Email.Contains(term) || user.Name.Contains(term))
                {
                    model.Add(new ApUserVM
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Username = user.UserName,
                        Email = user.Email,
                        Deleted=user.Deleted,
                        Role = (await _userManager.GetRolesAsync(user))[0]
                    });
                }
            }
            return PartialView("_ApUserSearch", model);
        }
    }
}
