﻿namespace ServeIt.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using ServeIt.Services.Data.Restaurants;
    using ServeIt.Web.ViewModels.Restaurants;

    public class RestaurantsController : BaseController
    {
        private readonly IRestaurantsService restaurantService;




        public RestaurantsController(IRestaurantsService restaurantService)
        {
            this.restaurantService = restaurantService;
        }


        public async Task<IActionResult> All()
        {
            var model = await restaurantService.GetAllRestaurants();


            return this.View(model);
        }

       
        public async Task<IActionResult> OwnedRestaurants(string id)
        {
            var model = await restaurantService.GetAllOwnedRestaurants(id);


            return this.View(model);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var ownerId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!await restaurantService.AreYouTheOwner(id,ownerId))
            {
                return this.Redirect($"/Restaurants/Info/{id}");
            }

            return this.View();
        }

        public async Task<IActionResult> Add()
        {
         
             await   FillCountryAndCitiesSugestion();
          

            return this.View();
        
        
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddRestaurantInputModel model)
        {
             await   FillCountryAndCitiesSugestion();

            if (!this.ModelState.IsValid)
            {
               
                return this.View(model);
            }

            var ownerId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

         await   restaurantService.AddRestaurant(model, ownerId);

            return this.Redirect("/Restaurants/All");

        }

        public async Task<IActionResult> Info(string id)
        {

            return this.View();
        
        }


        private async Task FillCountryAndCitiesSugestion() {
            var countries = await this.restaurantService.GetAllCountries();
  
            this.ViewData["Countries"] = countries;
            
        }




    }
}
