using ForumWebAPPDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForumWebAPPServices.Abstractions
{
    public interface IPostService
    {
        IQueryable<Post> GetPosts();

        void AddPost(Post post);

        Post GetPostById(int Id);
    }
}
