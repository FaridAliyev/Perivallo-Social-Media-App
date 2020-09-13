using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Perivallo.Models
{
    public class Message
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public int ChatId { get; set; }
        public virtual Chat Chat { get; set; }
    }
}
