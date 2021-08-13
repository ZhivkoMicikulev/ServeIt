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

        [HttpPost]
        public async Task<IActionResult> AddCountry(string countryName)
        {

            if (!string.IsNullOrEmpty(countryName))
            {
                await this.administrationService.CreateCountry(countryName);
            }
            return this.Redirect("/Administration/Administration/Destinations");
        }

        public async Task<IActionResult> RemoveCountry(string id)
        {
                await this.administrationService.RemoveCountry(id);
            
            return this.Redirect("/Administration/Administration/Destinations");
        }

        public async Task<IActionResult> RemoveCity(string id)
        {
            await this.administrationService.RemoveCity(id);

            return this.Redirect("/Administration/Administration/Destinations");
        }
        public async Task<IActionResult> AddCity(string id,string cityName)
        {
            if (!string.IsNullOrEmpty(cityName))
            {
                await this.administrationService.AddCity(id,cityName);
            }

            return this.Redirect("/Administration/Administration/Destinations");
        }

        public async Task<IActionResult> Restaurants()
        {
            var model = await this.administrationService.GetAllRestaurants();
            return this.View(model);
        }

        public async Task<IActionResult> Destinations()
        {
            var model = await this.administrationService.GetAllCountries();
            return this.View(model);
        }

        public async Task<IActionResult> BlockUser(string id)
        {
            await this.administrationService.BlockUser(id);

            return this.Redirect("/Administration/Administration/Users");
        }

        public async Task<IActionResult> BlockRestaurant(string id)
        {
            await this.administrationService.BlockRestaurant(id);

            return this.Redirect("/Administration/Administration/Restaurants");
        }

        public async Task<IActionResult> UnblockUser(string userId)
        {
            await this.administrationService.UnblockUser(userId);

            return this.Redirect("/Administration/Administration/Users");
        }
    }
}
