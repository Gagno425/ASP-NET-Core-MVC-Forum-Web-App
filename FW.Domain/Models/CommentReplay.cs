using System;
using System.Collections.Generic;
using System.Text;

namespace ForumWebAPPDomain.Models
{
  public  class CommentReplay
    {
        public int Id { get; set; }

        public string ReplayDescription { get; set; }

        public Comment Comment { get; set; }

        public User User { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
