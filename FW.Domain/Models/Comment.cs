using System;
using System.Collections.Generic;
using System.Text;

namespace ForumWebAPPDomain.Models
{
   public class Comment
    {
        public int Id { get; set; }

        public string CommentDesctription  { get; set; }

        public User User { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
