using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Perivallo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Perivallo.DAL
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostImage> PostImages { get; set; }
        public DbSet<PostTaggedUser> PostTaggedUsers { get; set; }
        public DbSet<PostLike> PostLikes { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<SavedPost> SavedPosts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentLike> CommentLikes { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationType> NotificationTypes { get; set; }
        public DbSet<UserReport> UserReports { get; set; }
        public DbSet<PostReport> PostReports { get; set; }
        public DbSet<CommentReport> CommentReports { get; set; }
    }
}
