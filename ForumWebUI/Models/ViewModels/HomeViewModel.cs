using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWebAPPUI.Models.ViewModels
{
    public class HomeViewModel
    {
        public AuthorizeUserViewModel AuthorizeUser { get; set; }

        public List<ThemeViewModel> Themes { get; set; }

        public List<PostViewModel> Posts { get; set; }

        static public int ThemeId;

        static public int PostId;

        public PostViewModel Post { get; set; } = new PostViewModel();

        public PagingInfo PagingInfo { get; set; }
    }
}
