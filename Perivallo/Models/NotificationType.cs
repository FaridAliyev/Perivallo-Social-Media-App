using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Perivallo.Models
{
    public class NotificationType
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}
