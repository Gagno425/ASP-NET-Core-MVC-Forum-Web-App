using Microsoft.AspNetCore.Identity;
using System;

namespace ForumWebAPPDomain.Models
{
   public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public string ImgUrl { get; set; }

        public DateTime Birthdate { get; set; }

        public bool IsBlocked { get; set; } = false;
    }
}
