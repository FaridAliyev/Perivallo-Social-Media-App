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

namespace Perivallo.Areas.Xqcow.Controllers
{
    [Area("Xqcow")]
    [Authorize(Roles = "Admin,Moderator")]
    public class ReportController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<User> _userManager;
        public ReportController(AppDbContext db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public IActionResult PostReports()
        {
            var model = _db.PostReports.Include(p=>p.ReportFrom).Include(p=>p.Post).ThenInclude(p=>p.User).OrderByDescending(p => p.Date);
            return View(model);
        }

        public async Task<IActionResult> DeletePostReport(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            PostReport report = await _db.PostReports.FindAsync(id);
            if (report == null)
            {
                return NotFound();
            }
            _db.PostReports.Remove(report);
            await _db.SaveChangesAsync();
            return RedirectToAction("PostReports");
        }

        public async Task<IActionResult> BanUser(string id, string returnUrl)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            User currentUser = await _userManager.GetUserAsync(User);
            User user = await _userManager.FindByIdAsync(id);
            if (user == null || user == currentUser || (await _userManager.GetRolesAsync(user))[0] == "Admin")
            {
                return NotFound();
            }
            user.Deleted = true;
            await _userManager.UpdateAsync(user);
            return LocalRedirect(returnUrl);
        }

        public async Task<IActionResult> UnbanUser(string id, string returnUrl)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            User currentUser = await _userManager.GetUserAsync(User);
            User user = await _userManager.FindByIdAsync(id);
            if (user == null || user == currentUser)
            {
                return NotFound();
            }
            user.Deleted = false;
            await _userManager.UpdateAsync(user);
            return LocalRedirect(returnUrl);
        }

        public IActionResult CommentReports()
        {
            var model = _db.CommentReports.Include(p => p.ReportFrom).Include(p => p.Comment).ThenInclude(p => p.User).OrderByDescending(p => p.Date);
            return View(model);
        }

        public async Task<IActionResult> DeleteCommentReport(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            CommentReport report = await _db.CommentReports.FindAsync(id);
            if (report == null)
            {
                return NotFound();
            }
            _db.CommentReports.Remove(report);
            await _db.SaveChangesAsync();
            return RedirectToAction("CommentReports");
        }

        public IActionResult UserReports()
        {
            var model = _db.UserReports.Include(p => p.ReportFrom).Include(p => p.ReportTo).OrderByDescending(p => p.Date);
            return View(model);
        }

        public async Task<IActionResult> DeleteUserReport(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            UserReport report = await _db.UserReports.FindAsync(id);
            if (report == null)
            {
                return NotFound();
            }
            _db.UserReports.Remove(report);
            await _db.SaveChangesAsync();
            return RedirectToAction("UserReports");
        }
    }
}
