using AutoMapper;
using ForumWebAPPDomain.Models;
using ForumWebAPPServices.Abstractions;
using ForumWebAPPUI.Models;
using ForumWebAPPUI.Models.ViewModels;
using ForumWebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IPostService _postService;
        private readonly IThemeService _themeService;
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        public int PageSize = 5;

        public HomeController(UserManager<User> userManager, IMapper mapper, IPostService postService, IThemeService themeService, ICommentService commentService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _postService = postService;
            _themeService = themeService;
            _commentService = commentService;
        }

        public async Task<User> GetAuthorizeUser()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var user = await _userManager.FindByIdAsync(userId);

            return user;
        }


        [HttpGet]
        public async Task<IActionResult> Index(int ThemeId, int PostId, int page = 1)
        {
            
            AuthorizeUserViewModel authorizeUserViewModel = _mapper.Map<AuthorizeUserViewModel>(GetAuthorizeUser().Result);

            HomeViewModel model = new HomeViewModel() {
                AuthorizeUser = authorizeUserViewModel,
                Themes = _mapper.Map<List<ThemeViewModel>>(_themeService.GetThemes().ToList())
            };

            List<PostViewModel> posts = _mapper.Map<List<PostViewModel>>(_postService.GetPosts().ToList()).Where(p => ThemeId == 0 || p.ThemeId == ThemeId).ToList();

            

            model.Posts = posts.OrderByDescending(p => p.CreateDate)
                               .Skip((page - 1) * PageSize)
                               .Take(PageSize)
                               .ToList();

            foreach (var post in model.Posts)
            {
                post.Theme = _mapper.Map<ThemeViewModel>(_themeService.GetThemeById(post.ThemeId));
            }

            HomeViewModel.ThemeId = ThemeId;


            HomeViewModel.PostId = PostId;

            if (ThemeId != 0)
            {
                model.Post.ThemeId = ThemeId;
                model.Posts = posts.Where(p => p.ThemeId == ThemeId)
                                       .OrderByDescending(p => p.CreateDate)
                                       .Skip((page - 1) * PageSize)
                                       .Take(PageSize)
                                       .ToList(); 
            }

            if (PostId != 0)
            {
                model.Posts = posts.Where(p => p.Id == PostId).ToList();
                model.Post = _mapper.Map<PostViewModel>(_postService.GetPostById(PostId));
                model.Post.Comments = _mapper.Map<List<CommentViewModel>>(_commentService.GetCommentsById(PostId));
                foreach (var comment in model.Post.Comments)
                {
                    comment.CommentReplies = _mapper.Map<List<ReplayCommentViewModel>>(_commentService.GetCommentReplies(comment.Id));
                    comment.User = _mapper.Map<UserViewModel>(await _userManager.FindByIdAsync(comment.UserId));
                    foreach (var replayComment in comment.CommentReplies)
                    {
                        replayComment.User = _mapper.Map<UserViewModel>(await _userManager.FindByIdAsync(replayComment.UserId));
                    }
                }
            }

            int totalItems = posts.Count();

            model.PagingInfo = new PagingInfo()
            {
                CurrentPage = page,
                TotalItems = totalItems,
                ItemsPerPage = PageSize
            };

            return View(model);
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult AddPost(PostViewModel model)
        {
            Post post = _mapper.Map<Post>(model);
            post.Theme = _themeService.GetThemeById(model.ThemeId);
            post.user = GetAuthorizeUser().Result;
            _postService.AddPost(post);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult AddPost()
        {

            return RedirectToAction(nameof(Index));
        }
    }

}
