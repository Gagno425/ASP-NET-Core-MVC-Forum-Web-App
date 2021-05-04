using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWebAPPUI.Models.ViewModels
{
    public class AdminViewModel
    {
        public AuthorizeUserViewModel AuthorizeUser { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
