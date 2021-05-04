using AutoMapper;
using ForumWebAPPDomain.Models;
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
    [Authorize(Roles = "User")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;


        public UserController(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<User> GetAuthorizeUser()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var user = await _userManager.FindByIdAsync(userId);

            return user;
        }

        [HttpGet]
        public IActionResult Profile()
        {
            AuthorizeUserViewModel authorizeUserViewModel = _mapper.Map<AuthorizeUserViewModel>(GetAuthorizeUser().Result);
            UserViewModel model = _mapper.Map<UserViewModel>(GetAuthorizeUser().Result);
            model.AuthorizeUser = authorizeUserViewModel;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(UserViewModel Model)
        {
            var user = await _userManager.FindByIdAsync(Model.Id);


            if (ModelState.IsValid)
            {
                user.UserName = Model.Username;
                user.ImgUrl = "/Images/" + Model.ImgUrl;
                user.FirstName = Model.FirstName;
                user.LastName = Model.LastName;
                user.Email = Model.Email;
                IdentityResult result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Profile));
                }
                else
                {
                    AddIdendityErrors(result);
                }
            }
           
            return View(Model);

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
