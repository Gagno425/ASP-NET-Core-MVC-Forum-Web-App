using ForumWebAPPDomain;
using ForumWebAPPDomain.Models;
using ForumWebAPPServices.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForumWebAPPServices.Implementations
{
    public class PostService : IPostService
    {
        private readonly ForumDbContext _context;

        public PostService(ForumDbContext context)
        {
            _context = context;
        }

        public void AddPost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public Post GetPostById(int Id)
        {
            return _context.Posts.SingleOrDefault(post => post.Id == Id);
        }

        public IQueryable<Post> GetPosts()
        {
            return _context.Posts.Include(p => p.user);
        }
    }
}
