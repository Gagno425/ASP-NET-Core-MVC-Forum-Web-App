using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWebAPPUI.Models.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int ThemeId { get; set; }

        public ThemeViewModel Theme { get; set; }

        public UserViewModel User { get; set; }

        public string UserId { get; set; }

        public AuthorizeUserViewModel AuthorizeUser { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public List<CommentViewModel> Comments { get; set; }
    }
}
