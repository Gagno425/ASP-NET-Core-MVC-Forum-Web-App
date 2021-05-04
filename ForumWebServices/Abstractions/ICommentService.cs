using ForumWebAPPDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForumWebAPPServices.Abstractions
{
    public interface ICommentService
    {
        List<Comment> GetCommentsById(int PostId);

        List<CommentReplay> GetCommentReplies(int CommentId);

        void AddComment(Comment comment);
    }
}
