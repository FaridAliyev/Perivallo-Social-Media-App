using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Perivallo.Models
{
    public class Friend
    {
        public int Id { get; set; }
        public string FriendFromId { get; set; }
        public string FriendToId { get; set; }
        public bool Accepted { get; set; }
        public virtual User FriendFrom { get; set; }
        public virtual User FriendTo  { get; set; }
        public Friend()
        {
            Accepted = false;
        }
    }
}
