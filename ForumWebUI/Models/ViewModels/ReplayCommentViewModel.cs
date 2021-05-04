using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWebAPPUI.Models.ViewModels
{
    public class ReplayCommentViewModel
    {
        public int Id { get; set; }

        public string ReplayDescription { get; set; }

        public string UserId { get; set; }

        public UserViewModel User { get; set; }

        DateTime CreateDate = DateTime.Now;
    }
}
