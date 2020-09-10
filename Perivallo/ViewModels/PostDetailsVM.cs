using Perivallo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Perivallo.ViewModels
{
    public class PostDetailsVM
    {
        public Comment Comment { get; set; }
        public User User { get; set; }
        public string CurrentUserRole { get; set; }
        public Post Post { get; set; }
        public IEnumerable<PostTaggedUser> PostTaggedUsers { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}
