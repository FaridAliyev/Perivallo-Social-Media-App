using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Perivallo.Models
{
    public class ChatUser
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public int ChatId { get; set; }
        public virtual Chat Chat { get; set; }

    }
}
