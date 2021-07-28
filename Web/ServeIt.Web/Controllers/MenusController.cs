using Microsoft.AspNetCore.Mvc;
using ServeIt.Services.Data.Menus;
using ServeIt.Services.Data.Restaurants;
using ServeIt.Web.ViewModels.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServeIt.Web.Controllers
{
    public class MenusController:BaseController
    {
        private readonly IMenusService menusServices;
        private readonly IRestaurantsService restaurantsService;

        public MenusController(IMenusService menusServices, IRestaurantsService restaurantsService)
        {
            this.menusServices = menusServices;
            this.restaurantsService = restaurantsService;
        }

        public async Task<IActionResult> Add(string id)
        {
           

            

            var menuId = await menusServices.RestaurantMenu(id);

            if (menuId == null)
            {
                menuId = await menusServices.AddMenu(id);
            }
      
            this.ViewData["RestaurantId"] = id;
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(string id, AddDishInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
            
                this.ViewData["RestaurantId"] = id;
                return this.View(model);
            }
            var menuId = await menusServices.RestaurantMenu(id);
           
            await this.menusServices.AddDish(model, menuId);


            return this.Redirect($"/Restaurants/Edit/{id}");

        }

        public async Task<IActionResult> RemoveDish(string id)
        {
           var restaurantId= await this.menusServices.RemoveDish(id);

            this.ViewData["DishId"] = id;

            return this.Redirect($"/Restaurants/Edit/{restaurantId}");

        }


        public async Task<IActionResult> Edit(string id)
        {
            var model = await menusServices.TakeDish(id);

            this.ViewData["DishId"] = id;

            return this.View(model);
        
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id,AddDishInputModel model)
        {

            if (!ModelState.IsValid)
            {
                this.ViewData["DishId"] = id;
                return this.View(model);
            }

        var restaurantId=await  this.menusServices.EditDish(id, model);

           

            return this.Redirect($"/Restaurants/Edit/{restaurantId}");

        }



    }
}
