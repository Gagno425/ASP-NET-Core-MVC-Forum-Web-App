using ForumWebAPPDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForumWebAPPServices.Abstractions
{
 public   interface IGenderService
    {
        Gender GetGenderById(int id);

        IQueryable<Gender> GetGenders();
    }
}
