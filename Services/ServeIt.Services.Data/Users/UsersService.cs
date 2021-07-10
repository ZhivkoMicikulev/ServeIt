﻿namespace ServeIt.Services.Data.Users
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using ServeIt.Data.Common.Repositories;
    using ServeIt.Data.Models;
    using ServeIt.Web.ViewModels.User;

    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<User> userRepository;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManger;

        public UsersService(IDeletableEntityRepository<User> userRepository, UserManager<User> userManager, SignInManager<User> signInManger)
        {
            this.userRepository = userRepository;
            this.userManager = userManager;
            this.signInManger = signInManger;
        }

        public async Task<User> IsThereAnyUser(LoginUserInputModel model)
        {
            var user = await this.userManager.FindByNameAsync(model.Username);
            if (user != null && await this.userManager.CheckPasswordAsync(user, model.Password))
            {
                return user;
            }

            return null;
        }

        public async Task<bool> LoginUser(LoginUserInputModel model)
        {
     var result = await this.signInManger.PasswordSignInAsync(model.Username, model.Password, true, false);

     if (result.Succeeded)
            {
               return true;
            }
            else
            {
                return false;
            }
        }

        public async Task LogoutUser()
        {
           await this.signInManger.SignOutAsync();
        }

        public async Task RegisterUser(RegisterUserModel model)
        {
            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Username,
                Email = model.Email,
                PhoneNumber = model.Phonenumber,
                IsItOwnerOfRestaurant = model.IsItOwner,
            };

            var result = await this.userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                if (this.userManager.Users.Count() == 1)
                {
                await this.userManager.AddToRoleAsync(user, "Administrator");
                }
                else if (model.IsItOwner)
                {
                   await this.userManager.AddToRoleAsync(user, "Restaurant");
                }
                else
                {
                    await this.userManager.AddToRoleAsync(user, "User");
                }
            }
        }
    }
}
