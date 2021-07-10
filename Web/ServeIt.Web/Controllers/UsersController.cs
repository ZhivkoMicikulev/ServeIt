namespace ServeIt.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ServeIt.Services.Data.Users;
    using ServeIt.Web.ViewModels.User;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class UsersController : BaseController
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public async Task<IActionResult> Login()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserInputModel model)
        {
            var user = await usersService.IsThereAnyUser(model);

            if (user == null)
            {
                ViewData["Error"] = "Invalid Username or Password";
                return this.View();
            }
           var res= await this.usersService.LoginUser(model);
            if (res)
            {
                return this.Redirect("/");
            }
            else
            {
                return this.View(model);
            }
            
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View();
            }

            if (model.Password != model.ConfirmPassword)
            {
                return this.Redirect("/");
            }

            await this.usersService.RegisterUser(model);

            return this.Redirect("/Users/Login");

        }

        public async Task<IActionResult> Logout()
        {

            this.usersService.LogoutUser();
        return    this.Redirect("/");
        }
    }
}
