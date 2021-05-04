using AutoMapper;
using ForumWebAPPDomain.Models;
using ForumWebAPPUI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWebAPPUI
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, AuthorizeUserViewModel>();
            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();
            CreateMap<Theme, ThemeViewModel>();
            CreateMap<User, AdminViewModel>();
            CreateMap<Post, PostViewModel>();
            CreateMap<PostViewModel, Post>();
            CreateMap<Theme, ThemeViewModel>();
            CreateMap<Comment, CommentViewModel>();
            CreateMap<Post, PostViewModel>();
            CreateMap<CommentReplay, ReplayCommentViewModel>();
        }
    }
}
