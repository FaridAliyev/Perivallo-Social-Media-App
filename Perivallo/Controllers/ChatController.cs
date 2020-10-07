using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Perivallo.DAL;
using Perivallo.Hubs;
using Perivallo.Models;
using Perivallo.ViewModels;

namespace Perivallo.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<User> _userManager;
        public ChatController(AppDbContext db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            User currentUser = await _userManager.GetUserAsync(User);
            List<ChatUser> currentChatUsers = _db.ChatUsers.Where(c => c.UserId == currentUser.Id).ToList();
            List<User> currentChatFriends = new List<User>();
            List<ChatUser> currentChats = new List<ChatUser>();
            foreach (ChatUser cu in currentChatUsers)
            {
                foreach (ChatUser item in _db.ChatUsers.Include(c=>c.User).Where(c=>c.ChatId==cu.ChatId))
                {
                    if (item.UserId!=currentUser.Id)
                    {
                        currentChats.Add(item);
                        currentChatFriends.Add(item.User);
                    }
                }
            }
            List<User> friends = new List<User>();
            foreach (Friend item in _db.Friends.Include(f => f.FriendTo).Include(f => f.FriendFrom).Where(f => f.Accepted && !f.FriendFrom.Deleted && !f.FriendTo.Deleted))
            {
                bool hasChat = false;
                if (item.FriendFrom == currentUser)
                {
                    foreach (User user in currentChatFriends)
                    {
                        if (item.FriendTo==user)
                        {
                            hasChat = true;
                        }
                    }
                    if (!hasChat)
                    {
                        friends.Add(item.FriendTo);
                    }
                }
                else if (item.FriendTo == currentUser)
                {
                    foreach (User user in currentChatFriends)
                    {
                        if (item.FriendFrom == user)
                        {
                            hasChat = true;
                        }
                    }
                    if (!hasChat)
                    {
                        friends.Add(item.FriendFrom);
                    }
                }
            }
            ChatVM model = new ChatVM()
            {
                Friends = friends,
                CurrentChats=currentChats
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateChat()
        {
            string id = Request.Form["friend"];
            if (id == null)
            {
                return BadRequest();
            }
            User currentUser = await _userManager.GetUserAsync(User);
            User user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return BadRequest();
            }
            Chat chat = new Chat();
            List<ChatUser> chatUsers = new List<ChatUser>();
            chatUsers.Add(new ChatUser
            {
                Chat=chat,
                UserId=id
            });
            chatUsers.Add(new ChatUser
            {
                Chat = chat,
                UserId = currentUser.Id
            });
            chat.ChatUsers = chatUsers;
            _db.Chats.Add(chat);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Chat");
        }

        public async Task<IActionResult> Dm(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            Chat chat = await _db.Chats.FindAsync(id);
            User currentUser = await _userManager.GetUserAsync(User);
            if (chat == null)
            {
                return NotFound();
            }
            bool chatMember = false;
            foreach (ChatUser item in _db.ChatUsers.Where(c=>c.ChatId==id))
            {
                if (item.UserId==currentUser.Id)
                {
                    chatMember = true;
                }
            }
            if (!chatMember)
            {
                return NotFound();
            }
            List<ChatUser> currentChatUsers = _db.ChatUsers.Where(c => c.UserId == currentUser.Id).ToList();
            List<User> currentChatFriends = new List<User>();
            List<ChatUser> currentChats = new List<ChatUser>();
            foreach (ChatUser cu in currentChatUsers)
            {
                foreach (ChatUser item in _db.ChatUsers.Include(c => c.User).Where(c => c.ChatId == cu.ChatId))
                {
                    if (item.UserId != currentUser.Id)
                    {
                        currentChats.Add(item);
                        currentChatFriends.Add(item.User);
                    }
                }
            }
            List<User> friends = new List<User>();
            foreach (Friend item in _db.Friends.Include(f => f.FriendTo).Include(f => f.FriendFrom).Where(f => f.Accepted))
            {
                bool hasChat = false;
                if (item.FriendFrom == currentUser)
                {
                    foreach (User user in currentChatFriends)
                    {
                        if (item.FriendTo == user)
                        {
                            hasChat = true;
                        }
                    }
                    if (!hasChat)
                    {
                        friends.Add(item.FriendTo);
                    }
                }
                else if (item.FriendTo == currentUser)
                {
                    foreach (User user in currentChatFriends)
                    {
                        if (item.FriendFrom == user)
                        {
                            hasChat = true;
                        }
                    }
                    if (!hasChat)
                    {
                        friends.Add(item.FriendFrom);
                    }
                }
            }

            ChatVM model = new ChatVM()
            {
                Friends=friends,
                CurrentChats=currentChats,
                Messages=_db.Messages.Include(m=>m.User).Where(m=>m.ChatId==id),
                Chat=chat
            };
            foreach (ChatUser chatUser in _db.ChatUsers.Include(c => c.User).Where(c => c.ChatId == id))
            {
                if (chatUser.UserId != currentUser.Id)
                {
                    User currentChatFriend = chatUser.User;
                    model.CurrentChatFriend = currentChatFriend;
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Dm")]
        public async Task<IActionResult> CreateMessage(int chatId,string message)
        {
            User currentUser = await _userManager.GetUserAsync(User);
            Message msg = new Message()
            {
                Date=DateTime.Now,
                Text=message,
                ChatId=chatId,
                UserId=currentUser.Id
            };
            _db.Messages.Add(msg);
            await _db.SaveChangesAsync();
            return RedirectToAction("Dm", "Chat", new { id = chatId });
        }

        
    }
}
