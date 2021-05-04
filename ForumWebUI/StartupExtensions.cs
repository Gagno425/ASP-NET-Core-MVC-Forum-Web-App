
using ForumWebAPPServices.Abstractions;
using ForumWebAPPServices.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWebAPPUI
{
    public static class StartupExtensions 
    {
        public static void RegisterDIServices(this IServiceCollection services)
        {
            services.AddTransient<IGenderService, GenderService>();
            services.AddTransient<IThemeService, ThemeService>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<ICommentService, CommentService>();
        } 
    }
}
