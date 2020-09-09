using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Perivallo.Models
{
    public class Post
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Link { get; set; }
        public string Location { get; set; }
        public string Text { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public ICollection<PostImage> PostImages { get; set; }
        public ICollection<PostTaggedUser> PostTaggedUsers { get; set; }
        public ICollection<PostLike> PostLikes { get; set; }
    }
}
