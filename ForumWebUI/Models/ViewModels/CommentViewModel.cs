using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWebAPPUI.Models.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        public string CommentDesctription { get; set; }

        public string UserId { get; set; }

        public UserViewModel User { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public List<ReplayCommentViewModel> CommentReplies { get; set; }
    }
}
