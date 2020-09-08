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
        public DbSet<Friend> Friends { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    builder.Entity<Friend>()
        //            .WithMany(u => u.FriendFroms)
        //            .HasForeignKey(f => f.FriendFromId)
        //            .WillCascadeOnDelete(false);

        //    builder.Entity<Friend>()
        //                .WithMany(u => u.FriendTos)
        //                .HasForeignKey(f => f.FriendToId)
        //                .WillCascadeOnDelete(false);
        //}
    }
}
