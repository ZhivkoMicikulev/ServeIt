﻿namespace ServeIt.Services.Data.Users
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using ServeIt.Data.Models;
    using ServeIt.Web.ViewModels.User;

    public interface IUsersService
    {
        Task RegisterUser(RegisterUserModel model);

        Task<bool> LoginUser(LoginUserInputModel model);

        Task<User> IsThereAnyUser(LoginUserInputModel model);

        Task LogoutUser();
    }
}