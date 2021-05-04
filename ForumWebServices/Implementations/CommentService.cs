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
    public class CommentService : ICommentService
    {
        private readonly ForumDbContext _context;

        public CommentService(ForumDbContext context)
        {
            _context = context;
        }

        public void AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public List<CommentReplay> GetCommentReplies(int CommentId)
        {
            var replayComments = _context.CommentReplays.Include(c => c.Comment).Where(cr => cr.Comment.Id == CommentId).Include(cr => cr.User).ToList();
            return replayComments;
        }

        public List<Comment> GetCommentsById(int PostId)
        {
            var post = _context.Posts.Include(p => p.Commnets).SingleOrDefault(p => p.Id == PostId);
            return post.Commnets;
        }
    }
}
