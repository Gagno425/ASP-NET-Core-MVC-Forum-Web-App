using ForumWebAPPDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWebAPPUI.Models.ViewModels
{
    public class RegisterViewModel
    {
        public AuthorizeUserViewModel AuthorizeUser { get; set; }

        public CreteUser CreateUser { get; set; }

        public List<Gender> Genders { get; set; }
    }
}
