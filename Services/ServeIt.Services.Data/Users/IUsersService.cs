﻿namespace ServeIt.Services.Data.Users
{
    using System.Threading.Tasks;

    using ServeIt.Data.Models;
    using ServeIt.Web.ViewModels.User;

    public interface IUsersService
    {
        Task RegisterUser(RegisterUserModel model);

        Task<bool> LoginUser(LoginUserInputModel model);

        Task<User> IsThereAnyUser(LoginUserInputModel model);

        Task EditUsername(EditProfileInputModel model,string userId);

        Task EditEmail(EditProfileInputModel model, string userId);

        Task EditPhoneNumber(EditProfileInputModel model, string userId);

        Task EditPassword(EditProfileInputModel model, string userId);

        Task<EditProfileViewModel> GetUserInfo(string id);

        Task<User> GetUser(string userId);

        Task<bool> isUserWithUsername(string username);
        Task<bool> isUserWithEmail(string email);


        Task LogoutUser();
    }
}
