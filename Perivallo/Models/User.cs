using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Perivallo.Models
{
    public class User : IdentityUser
    {
        [Required, StringLength(200)]
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Cover { get; set; }
        [StringLength(200)]
        public string About { get; set; }
        public bool Private { get; set; }
        public bool Deleted { get; set; }
        public DateTime RegDate { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<PostTaggedUser> PostTaggedUsers { get; set; }
        public ICollection<PostLike> PostLikes { get; set; }
        public ICollection<SavedPost> SavedPosts { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<CommentLike> CommentLikes { get; set; }
        public User()
        {
            Private = false;
            Deleted = false;
        }
    }
}
