using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Perivallo.Models
{
    public class Friend
    {
        public int Id { get; set; }
        public bool Accepted { get; set; }
        [ForeignKey("FriendFrom")]
        public string FriendFromId { get; set; }
        [ForeignKey("FriendTo")]
        public string FriendToId { get; set; }
        public User FriendFrom { get; set; }
        public User FriendTo { get; set; }
        public Friend()
        {
            Accepted = false;
        }
    }
}
