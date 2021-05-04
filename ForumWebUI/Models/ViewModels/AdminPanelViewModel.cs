using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWebAPPUI.Models.ViewModels
{
    public class AdminPanelViewModel
    {
        public ThemeViewModel Theme { get; set; }
        public List<ThemeViewModel> Themes { get; set; }
        public List<UserViewModel> BlockedUsers { get; set; }
        public List<UserViewModel> ActiveUsers { get; set; }
    }
}
