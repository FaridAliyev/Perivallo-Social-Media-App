using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Perivallo.DAL;
using Perivallo.Hubs;
using Perivallo.Models;

namespace Perivallo.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class ChandleController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<User> _userManager;
        private readonly IHubContext<ChatHub> _hub;
        public ChandleController(AppDbContext db, UserManager<User> userManager, IHubContext<ChatHub> hub)
        {
            _db = db;
            _userManager = userManager;
            _hub = hub;
        }
        [HttpPost("[action]/{connectionId}/{roomId}")]
        public async Task<IActionResult> JoinRoom(string connectionId, string roomId)
        {
            await _hub.Groups.AddToGroupAsync(connectionId, roomId);
            return Ok();
        }

        [HttpPost("[action]/{connectionId}/{roomId}")]
        public async Task<IActionResult> LeaveRoom(string connectionId, string roomId)
        {
            await _hub.Groups.RemoveFromGroupAsync(connectionId, roomId);
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SendMessage(int roomId, string message)
        {
            User currentUser = await _userManager.GetUserAsync(User);
            Message msg = new Message()
            {
                Date = DateTime.Now,
                Text = message,
                ChatId = roomId,
                UserId = currentUser.Id
            };
            _db.Messages.Add(msg);
            await _db.SaveChangesAsync();
            await _hub.Clients.Group(roomId.ToString()).SendAsync("ReceiveMessage", new
            {
                Text = msg.Text,
                Name = currentUser.UserName,
                Date = msg.Date.ToString("dd/mm/yyyy hh:mm")
            });
            return Ok();
        }
    }
}
