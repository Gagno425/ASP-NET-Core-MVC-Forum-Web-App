using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWebAPPUI.Models.ViewModels
{
    public class ThemeViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Theme_type { get; set; }
    }
}
