using Perivallo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Perivallo.ViewModels
{
    public class ChatVM
    {
        public IEnumerable<User> Friends { get; set; }
        public IEnumerable<ChatUser> CurrentChats { get; set; }
        public User CurrentChatFriend { get; set; }
        public IEnumerable<Message> Messages { get; set; }
        public Chat Chat { get; set; }
    }
}
