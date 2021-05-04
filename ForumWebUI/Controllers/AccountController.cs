using AutoMapper;
using ForumWebAPPDomain.Models;
using ForumWebAPPServices.Abstractions;
using ForumWebAPPUI.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWebAPPUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IGenderService _genderService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signinManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public AccountController
        (IGenderService genderService,
         UserManager<User> userManager,
         SignInManager<User> signInManager,
         RoleManager<IdentityRole> roleManager,
         IMapper mapper)
        {
            _userManager = userManager;
            _genderService = genderService;
            _signinManager = signInManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<User> GetAuthorizeUser()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var user = await _userManager.FindByIdAsync(userId);

            return user;
        }
 
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            if (AuthorizeUser() == false)
            {
                AuthorizeUserViewModel authorizeUserViewModel = _mapper.Map<AuthorizeUserViewModel>(GetAuthorizeUser().Result);
                LoginViewModel model = new LoginViewModel() { AuthorizeUser = authorizeUserViewModel };
                ViewBag.returnUrl = returnUrl;
                return View(model);
            }
            return StatusCode(204);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signinManager.SignOutAsync();
            return Redirect("/");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                

                if (user != null && user.IsBlocked == false)
                {
                    var IsInRole = await _userManager.IsInRoleAsync(user, "User");
                    if (IsInRole == true)
                    {
                        await _signinManager.SignOutAsync();
                        var result = await _signinManager.PasswordSignInAsync(user, model.Password, false, false);
                        if (result.Succeeded)
                        {
                            return Redirect(returnUrl ?? "/");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Invalid email or password!");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid email or password!");
                    }
                }
                else
                {
                    if (user !=  null && user.IsBlocked == true)
                    {
                        ModelState.AddModelError("", "This account is blocked!");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid email or password!");
                    }
                }
            }
            return View(model);
        }

        public bool AuthorizeUser()
        {
            var IsAuthorized = true;
            string userid = _userManager.GetUserId(HttpContext.User);
            if (userid == null)
            {
                IsAuthorized = false;
            }     

            return IsAuthorized;
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (AuthorizeUser() == false)
            {
                RegisterViewModel model = new RegisterViewModel();
                AuthorizeUserViewModel authorizeUserViewModel = _mapper.Map<AuthorizeUserViewModel>(GetAuthorizeUser().Result);
                model.Genders = _genderService.GetGenders().ToList();
                model.AuthorizeUser = authorizeUserViewModel;
                return View(model);
            }

            return StatusCode(204);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            string AvatarImg = "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png";
           
         

            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    UserName = model.CreateUser.Username,
                    FirstName = model.CreateUser.FirstName,
                    LastName = model.CreateUser.LastName,
                    Email = model.CreateUser.Email,
                    Birthdate = model.CreateUser.BirthDate,
                    Gender = _genderService.GetGenderById(model.CreateUser.GenderId),
                    ImgUrl = AvatarImg,
                    IsBlocked = false
                };
                var result = await _userManager.CreateAsync(user, model.CreateUser.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                    return RedirectToAction(nameof(Login));
                }
                else
                {
                    AddIdendityErrors(result);
                }
            }
            model.Genders = _genderService.GetGenders().ToList();
            return View(model);
        }
        public void AddIdendityErrors(IdentityResult result)
        {
            foreach (var Error in result.Errors)
            {
                ModelState.AddModelError("", Error.Description);
            }
        }
    }
}
