using Perivallo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Perivallo.ViewModels
{
    public class HomeVM
    {
        public User User { get; set; }
        public Post Post { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}
