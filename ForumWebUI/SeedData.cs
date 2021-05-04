using ForumWebAPPDomain;
using ForumWebAPPDomain.Models;
using ForumWebAPPServices.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWebAPPUI
{
    public static class SeedData
    {

        public static void AddAdministratorUser(IApplicationBuilder app)
        {
            using (var @scope = app.ApplicationServices.CreateScope())
            {
                try
                {
                    UserManager<User> _userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                    IGenderService _genderService =  scope.ServiceProvider.GetRequiredService<IGenderService>();

                    string AvatarImg = "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png";

                    bool IsInRole = false;

                    foreach (var user in _userManager.Users)
                    {
                        if (_userManager.IsInRoleAsync(user, "Admin").Result)
                        {
                            IsInRole = true;
                        }
                    }
                   
                    if (IsInRole == false)
                    {
                        User user = new User()
                        {
                            UserName = "Admin",
                            FirstName = "Admin",
                            LastName = "Admin",
                            Email = "Admin@example.com",
                            Birthdate = DateTime.Now,
                            Gender = _genderService.GetGenderById(1),
                            ImgUrl = AvatarImg,
                            IsBlocked = false
                        };

                        var result = _userManager.CreateAsync(user, "Admin1").Result;

                        if (result.Succeeded)
                        {
                            var AddInRole = _userManager.AddToRoleAsync(user, "Admin").Result;
                        }

                       

                        
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }


        public static void AddRoles(IApplicationBuilder app)
        {
            using (var @scope = app.ApplicationServices.CreateScope())
            {
                try
                {
                    RoleManager<IdentityRole> _roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                    bool AdminRoleIsCreated = false;
                    bool UserRoleIsCreated = false;

                    foreach (var role in _roleManager.Roles)
                    {
                        if (role.Name == "Admin")
                        {
                            AdminRoleIsCreated = true;
                        }
                        else if (role.Name == "User")
                        {
                            UserRoleIsCreated = true;
                        }
                    }

                    if (AdminRoleIsCreated == false)
                    {
                        var CreateAdmin = _roleManager.CreateAsync(new IdentityRole() { Name = "Admin" }).Result;
                    }
                    else if (UserRoleIsCreated == false)
                    {
                        var CreateUser = _roleManager.CreateAsync(new IdentityRole() { Name = "User" }).Result;
                    }
                }

                catch (Exception ex)
                {

                }
            }
        }
    }
}
