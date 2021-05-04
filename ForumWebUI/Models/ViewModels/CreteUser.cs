using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWebAPPUI.Models.ViewModels
{
    public class CreteUser
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int GenderId { get; set; }
        public string ImgUrl { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Password { get; set; }


    }
}
