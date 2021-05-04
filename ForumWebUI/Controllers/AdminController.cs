using AutoMapper;
using ForumWebAPPDomain.Models;
using ForumWebAPPServices.Abstractions;
using ForumWebAPPUI.Helper;
using ForumWebAPPUI.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWebAPPUI.Controllers
{
    public class AdminController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IThemeService _themeService;
        private readonly IMapper _mapper;

        public AdminController (UserManager<User> userManager, SignInManager<User> signInManager, IThemeService themeService, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _themeService = themeService;
            _mapper = mapper;
        }

        public async Task<User> GetAuthorizeUser()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var user = await _userManager.FindByIdAsync(userId);

            return user;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (AuthorizeUser().Result == true)
            {
                return RedirectToAction(nameof(Panel));
            }
            else if (GetAuthorizeUser().Result != null && await _userManager.IsInRoleAsync(GetAuthorizeUser().Result, "User") == true)
            {
                return StatusCode(204);
            }

            AuthorizeUserViewModel authorizeUserViewModel = _mapper.Map<AuthorizeUserViewModel>(GetAuthorizeUser().Result);
            AdminViewModel model = new AdminViewModel();
            model.AuthorizeUser = authorizeUserViewModel;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(AdminViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Username);
                var IsInRole = await _userManager.IsInRoleAsync(user, "Admin");
                if (user != null && IsInRole == true)
                {
                    await _signInManager.SignOutAsync();
                    
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(Panel));
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid username or password!");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password!");
                }
            }
            return View(model);
        }

        public async Task<bool> AuthorizeUser()
        {
            string userid = _userManager.GetUserId(HttpContext.User);
            User user = new User();
            if (userid != null)
            {
                user = await _userManager.FindByIdAsync(userid);
            }
            var IsInRole = await _userManager.IsInRoleAsync(user, "Admin");

            return IsInRole;
        }

 
        [HttpGet]
        public IActionResult Panel()
        {
     
            if (AuthorizeUser().Result == true)
            {
                AdminPanelViewModel ViewModel = new AdminPanelViewModel();
                var MappedModel = MappingAdminModel(ViewModel).Result;

                return View(MappedModel);
            }
          
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult DeleteTheme(int Id)
        {
            _themeService.DeleteThemeById(Id);
            return RedirectToAction(nameof(Panel));
        }

        public async Task<AdminPanelViewModel> MappingAdminModel(AdminPanelViewModel model)
        {
            List<UserViewModel> ActiveUsers = new List<UserViewModel>();
            List<UserViewModel> BlockedUsers = new List<UserViewModel>();

            model.Themes = _mapper.Map<List<ThemeViewModel>>(_themeService.GetThemes().ToList());


            foreach (var user in _userManager.Users)
            {
                var IsInRole = await _userManager.IsInRoleAsync(user, "Admin");
                if (user.IsBlocked == false && IsInRole == false)
                {
                    //ActiveUsers.Add(new UserViewModel() { Id = user.Id, Email = user.Email, FirstName = user.FirstName, LastName = user.LastName, ImgUrl = user.ImgUrl });
                    ActiveUsers.Add(_mapper.Map<UserViewModel>(user));
                }
                else if(user.IsBlocked == true && IsInRole == false)
                {
                    //BlockedUsers.Add(new UserViewModel() { Id = user.Id, Email = user.Email, FirstName = user.FirstName, LastName = user.LastName, ImgUrl = user.ImgUrl });
                    BlockedUsers.Add(_mapper.Map<UserViewModel>(user));
                }
            }


            model.BlockedUsers = ActiveUsers;
            model.ActiveUsers = BlockedUsers;

            return model;
        }

        [HttpPost]
        public IActionResult CreateTheme(ThemeViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_themeService.GetThemes().Any(t => t.Theme_type == model.Theme_type))
                {
                    ModelState.AddModelError("", "This theme is already exist!");
                    AdminPanelViewModel ViewModel = new AdminPanelViewModel();
                    var MappedModel = MappingAdminModel(ViewModel).Result;
                    MappedModel.Theme = model;
                    return View("Panel", MappedModel);
                }

                
                _themeService.AddTheme(model.Theme_type);
            }

            return RedirectToAction(nameof(Panel));

        }


        [HttpGet]
        public async Task<IActionResult> BlockUsers(string Id)
        {
            bool IsBlocked = true;

            var user = await _userManager.FindByIdAsync(Id);
            user.IsBlocked = IsBlocked;
            await _userManager.UpdateAsync(user);

            return RedirectToAction(nameof(Panel));

        }

        [HttpGet]
        public async Task<IActionResult> UnBlockUsers(string Id)
        {
            bool IsBlocked = false;

            var user = await _userManager.FindByIdAsync(Id);
            user.IsBlocked = IsBlocked;
            await _userManager.UpdateAsync(user);

            return RedirectToAction(nameof(Panel));
        }

        

        [HttpGet]
        public IActionResult ClickedSubMenu(string click)
        {
            MenuActionHelper.SubMenuAction = click;
            return RedirectToAction(nameof(Panel));
        }
    }
}
