using ForumWebAPPDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForumWebAPPServices.Abstractions
{
    public interface IThemeService
    {
        IQueryable<Theme> GetThemes();

        Theme GetThemeById(int Id);

        void AddTheme(string model);

        void DeleteThemeById(int Id);
    }
}
