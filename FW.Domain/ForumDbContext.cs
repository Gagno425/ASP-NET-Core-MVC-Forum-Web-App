using ForumWebAPPDomain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForumWebAPPDomain
{
    public class ForumDbContext : IdentityDbContext<User>
    {
        public ForumDbContext(DbContextOptions<ForumDbContext> options)
        : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentReplay> CommentReplays { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Gender> Gender { get; set; }

    }
}
