using System;
using System.Collections.Generic;
using System.Text;

namespace ForumWebAPPDomain.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public Theme Theme { get; set; }

        public List<Comment> Commnets { get; set; }

        public List<CommentReplay> CommentReplays { get; set; }

        public string ImgUrl { get; set; }

        public User user { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;        

    }
}
