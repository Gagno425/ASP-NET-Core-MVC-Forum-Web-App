using ForumWebAPPDomain;
using ForumWebAPPDomain.Models;
using ForumWebAPPServices.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForumWebAPPServices.Implementations
{
 public   class GenderService : IGenderService
    {
        private readonly ForumDbContext _context;
        public GenderService(ForumDbContext context)
        {
            _context = context;
        }
        public Gender GetGenderById(int id)
        {
            return _context.Gender.FirstOrDefault(g => g.Id == id);
        }

        public IQueryable<Gender> GetGenders()
        {
            return _context.Gender;
        }
    }
}
