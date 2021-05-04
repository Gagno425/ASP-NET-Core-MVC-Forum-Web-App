using ForumWebAPPDomain;
using ForumWebAPPDomain.Models;
using ForumWebAPPServices.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForumWebAPPServices.Implementations
{
    public class ThemeService : IThemeService
    {
        private readonly ForumDbContext _context;

        public ThemeService(ForumDbContext context)
        {
            _context = context;
        }

        public void AddTheme(string model)
        {
            _context.Themes.Add(new Theme() { Theme_type = model });
            _context.SaveChanges();
        }

        public void DeleteThemeById(int Id)
        {
            _context.Themes.Remove(_context.Themes.FirstOrDefault(t => t.Id == Id));
            foreach (var item in _context.Posts.Where(p => p.Theme.Id == Id).ToList())
            {
                _context.Posts.Remove(item);
            }
            
            _context.SaveChanges();
        }

        public Theme GetThemeById(int Id)
        {
            return _context.Themes.SingleOrDefault(t => t.Id == Id);
        }

        public IQueryable<Theme> GetThemes()
        {
            return _context.Themes;
        }
    }
}
