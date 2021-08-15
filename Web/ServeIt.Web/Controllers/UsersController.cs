namespace ServeIt.Web.Controllers
{
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using AspNetCore.ReCaptcha;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ServeIt.Services.Data.Users;
    using ServeIt.Web.ViewModels.User;

    public class UsersController : BaseController
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [Authorize]
        public async Task<IActionResult> Profile(string id)
        {
            var model = await this.usersService.GetUserInfo(id);

            return this.View(model);
        }

        [HttpPost]
        [Authorize]

        public async Task<IActionResult> EditUsername(EditProfileInputModel model)
        {
            if (model.Input.Length <= 20 &&
                model.Input.Length >= 3
                && !string.IsNullOrEmpty(model.Input))
            {
                await this.usersService.EditUsername(model, this.UserId());
            }

            return this.Redirect($"/Users/Profile/{this.UserId()}");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditPhone(EditProfileInputModel model)
        {
            if (model.Input.Length <= 10 &&
                model.Input.Length >= 5 &&
                !string.IsNullOrEmpty(model.Input))
            {
                await this.usersService.EditPhoneNumber(model, this.UserId());
            }

            return this.Redirect($"/Users/Profile/{this.UserId()}");
        }

        [Authorize]

        [HttpPost]

        public async Task<IActionResult> EditEmail(EditProfileInputModel model)
        {
            var emailValidator = new EmailAddressAttribute();
            if (!string.IsNullOrEmpty(model.Input) && emailValidator.IsValid(model.Input))
            {
             await this.usersService.EditEmail(model, this.UserId());
            }

            return this.Redirect($"/Users/Profile/{this.UserId()}");
        }

        [Authorize]
        [HttpPost]

        public async Task<IActionResult> EditPassword(EditProfileInputModel model)
        {
            if (model.Input.Length <= 10 &&
                model.Input.Length >= 5 &&
                    model.Input == model.ReInput &&
                    !string.IsNullOrEmpty(model.Input) &&
                    !string.IsNullOrEmpty(model.ReInput))
            {
                await this.usersService.EditPassword(model, this.UserId());
            }

            await this.usersService.LogoutUser();
            return this.Redirect($"/Users/Login");
        }

        public async Task<IActionResult> Login()
        {
            return this.View();
        }

        [ValidateReCaptcha]
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserInputModel model)
        {

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var user = await this.usersService.IsThereAnyUser(model);

            if (user == null )
            {
                this.ViewData["Error"] = "Invalid Username or Password";
                return this.View();
            }

            var res = await this.usersService.LoginUser(model);
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

        [ValidateReCaptcha]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            if (model.Password != model.ConfirmPassword)
            {
                return this.Redirect("/");
            }

            await this.usersService.RegisterUser(model);

            return this.Redirect("/Users/Login");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await this.usersService.LogoutUser();
            return this.Redirect("/");
        }

        private string UserId()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }
    }
}
