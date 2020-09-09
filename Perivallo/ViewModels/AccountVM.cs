using Perivallo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Perivallo.ViewModels
{
    public class AccountVM
    {
        public User User { get; set; }
        public string CurrentUserRole { get; set; }
        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<PostTaggedUser> PostTaggedUsers { get; set; }
    }
}
