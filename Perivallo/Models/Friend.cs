using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Perivallo.Models
{
    public class Friend
    {
        public int Id { get; set; }
        public bool Accepted { get; set; }
        [Required]
        public User FriendFrom { get; set; }
        [Required]
        public User FriendTo { get; set; }
        public Friend()
        {
            Accepted = false;
        }
    }
}
