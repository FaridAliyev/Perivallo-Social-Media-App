﻿using System;
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
    public class PostController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _db;
        public PostController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager, AppDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _db = db;
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Post post = await _db.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            User currentUser = await _userManager.GetUserAsync(User);
            User postOwner = await _userManager.FindByIdAsync(post.UserId);
            List<User> friends = new List<User>();
            foreach (Friend item in _db.Friends.Include(f => f.FriendTo).Include(f => f.FriendFrom).Where(f => f.Accepted))
            {
                if (item.FriendFrom == postOwner)
                {
                    friends.Add(item.FriendTo);
                }
                else if (item.FriendTo == postOwner)
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
            if (postOwner.Private && !isFriend && postOwner != currentUser)
            {
                return NotFound();
            }
            PostDetailsVM model = new PostDetailsVM()
            {
                User = currentUser,
                Post = _db.Posts.Include(p => p.User).Include(p => p.PostTaggedUsers).Include(p => p.PostLikes).Include(p => p.PostImages).Include(p => p.SavedPosts).Include(p => p.Comments).FirstOrDefault(p => p.Id == id),
                PostTaggedUsers = _db.PostTaggedUsers.Include(p => p.User),
                Comments = _db.Comments.Include(c=>c.User).Include(c=>c.CommentLikes).Include(c=>c.Replies).Where(c => c.PostId == id).OrderByDescending(c => c.CommentLikes.Count()),
                CurrentUserRole = (await _userManager.GetRolesAsync(currentUser))[0]
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Details")]
        public async Task<IActionResult> PostComment(int? id,PostDetailsVM postDetailsVM)
        {
            if (string.IsNullOrEmpty(postDetailsVM.Comment.Text.Trim()))
            {
                return BadRequest();
            }
            Post post = await _db.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            Comment comment = postDetailsVM.Comment;
            comment.Date = DateTime.Now;
            User currentUser = await _userManager.GetUserAsync(User);
            comment.UserId = currentUser.Id;
            comment.PostId = (int)id;
            _db.Comments.Add(comment);
            if (currentUser.Id!=post.UserId)
            {
                Notification notification = new Notification()
                {
                    Date = DateTime.Now,
                    NotificationFromId = currentUser.Id,
                    NotificationToId = post.UserId,
                    PostId = (int)id,
                    NotificationTypeId = 3
                };
                _db.Notifications.Add(notification);
            }
            await _db.SaveChangesAsync();
            return RedirectToAction("Details", "Post", new { id = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostReply(int? commentId, string reply)
        {
            if (string.IsNullOrEmpty(reply.Trim()))
            {
                return BadRequest();
            }
            Comment comment = await _db.Comments.FindAsync(commentId);
            User currentUser = await _userManager.GetUserAsync(User);
            if (comment == null)
            {
                return NotFound();
            }
            Reply newReply = new Reply()
            {
                Text = reply,
                Date = DateTime.Now,
                UserId = currentUser.Id,
                CommentId = (int)commentId
            };
            _db.Replies.Add(newReply);
            if (currentUser.Id != comment.UserId)
            {
                Notification notification = new Notification()
                {
                    Date = DateTime.Now,
                    NotificationFromId = currentUser.Id,
                    NotificationToId = comment.UserId,
                    PostId = comment.PostId,
                    NotificationTypeId = 5
                };
                _db.Notifications.Add(notification);
            }
            await _db.SaveChangesAsync();
            return RedirectToAction("Details", "Post", new { id = comment.PostId });
        }

        public async Task<int> CommentLike(int? id)
        {
            if (id == null)
            {
                return 0;
            }
            Comment comment = await _db.Comments.FindAsync(id);
            if (comment == null)
            {
                return 0;
            }
            User currentUser = await _userManager.GetUserAsync(User);
            CommentLike commentLike = new CommentLike()
            {
                UserId = currentUser.Id,
                CommentId = (int)id
            };
            if (currentUser.Id!=comment.UserId)
            {
                Notification notification = new Notification()
                {
                    Date = DateTime.Now,
                    NotificationFromId = currentUser.Id,
                    NotificationToId = comment.UserId,
                    PostId = comment.PostId,
                    NotificationTypeId = 2
                };
                _db.Notifications.Add(notification);
            }
            _db.CommentLikes.Add(commentLike);
            await _db.SaveChangesAsync();
            int newLikesCount = _db.CommentLikes.Where(p => p.CommentId == id).Count();
            return newLikesCount;
        }

        public async Task<int> CommentDislike(int? id)
        {
            if (id == null)
            {
                return -1;
            }
            Comment comment = await _db.Comments.FindAsync(id);
            if (comment == null)
            {
                return -1;
            }
            User currentUser = await _userManager.GetUserAsync(User);
            CommentLike commentLike = _db.CommentLikes.Where(p => p.UserId == currentUser.Id && p.CommentId == id).FirstOrDefault();
            if (currentUser.Id != comment.UserId)
            {
                Notification notification = _db.Notifications.Where(n => n.NotificationFromId == currentUser.Id && n.NotificationToId == comment.UserId && n.PostId == comment.PostId && n.NotificationTypeId == 2).FirstOrDefault();
                _db.Notifications.Remove(notification);
            }
            _db.CommentLikes.Remove(commentLike);
            await _db.SaveChangesAsync();
            int newLikesCount = _db.CommentLikes.Where(p => p.CommentId == id).Count();
            return newLikesCount;
        }
    }
}
