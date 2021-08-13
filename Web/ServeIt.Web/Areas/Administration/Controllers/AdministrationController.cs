namespace ServeIt.Web.Areas.Administration.Controllers
{
    using ServeIt.Common;
    using ServeIt.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using ServeIt.Services.Data.Administration;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
        private readonly IAdministrationService administrationService;

        public AdministrationController(IAdministrationService administrationService)
        {
            this.administrationService = administrationService;
        }

        public async Task<IActionResult> Users()
        {
            var model = await this.administrationService.GetAllUsers();
            return this.View(model);
        }

        public async Task<IActionResult> BlockUser(string id)
        {
            await this.administrationService.BlockUser(id);

            return this.Redirect("/Administration/Administration/Users");
        }

        public async Task<IActionResult> UnblockUser(string userId)
        {
            await this.administrationService.UnblockUser(userId);

            return this.Redirect("/Administration/Administration/Users");
        }
    }
}
