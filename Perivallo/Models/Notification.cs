using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Perivallo.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("NotificationFrom")]
        public string NotificationFromId { get; set; }
        [ForeignKey("NotificationTo")]
        public string NotificationToId { get; set; }
        public int PostId { get; set; }
        public User NotificationFrom { get; set; }
        public User NotificationTo { get; set; }
        public virtual Post Post { get; set; }
        public int NotificationTypeId { get; set; }
        public virtual NotificationType NotificationType { get; set; }
    }
}
