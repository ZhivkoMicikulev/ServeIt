using Microsoft.AspNetCore.Mvc;
using ServeIt.Services.Data.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServeIt.Web.Controllers
{
    public class RestaurantsController : BaseController
    {
        private readonly IRestaurantsService restaurantService;

        public RestaurantsController(IRestaurantsService restaurantService)
        {
            this.restaurantService = restaurantService;
        }

        public async Task<IActionResult> All()
        {
            return this.View();
        }

        public async Task<IActionResult> Add()
        {
            var model = await this.restaurantService.GetAllCountries();

            return this.View(model);
        
        
        }

    }
}
