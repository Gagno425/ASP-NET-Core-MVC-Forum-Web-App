using ForumWebAPPDomain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWebAPPUI.Models.ViewModels
{
    public class UserViewModel
    {
        public AuthorizeUserViewModel AuthorizeUser { get; set; }
        [Required]
        public string Username { get; set; }
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ImgUrl { get; set; }
    }
}
