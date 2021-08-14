namespace ServeIt.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ServeIt.Services.Data.Menus;
    using ServeIt.Services.Data.Restaurants;
    using ServeIt.Web.ViewModels.Menu;

    [Authorize]

    public class MenusController : BaseController
    {
        private readonly IMenusService menusServices;

        public MenusController(IMenusService menusServices)
        {
            this.menusServices = menusServices;
        }

        public async Task<IActionResult> Add(string id)
        {
            var menuId = await this.menusServices.RestaurantMenu(id);

            if (menuId == null)
            {
                menuId = await this.menusServices.AddMenu(id);
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

            var menuId = await this.menusServices.RestaurantMenu(id);

            await this.menusServices.AddDish(model, menuId);

            return this.Redirect($"/Restaurants/Edit/{id}");
        }

        public async Task<IActionResult> RemoveDish(string id)
        {
           var restaurantId = await this.menusServices.RemoveDish(id);

           this.ViewData["DishId"] = id;

           return this.Redirect($"/Restaurants/Edit/{restaurantId}");
        }

        public async Task<IActionResult> Edit(string id)
        {
            var model = await this.menusServices.TakeDish(id);

            this.ViewData["DishId"] = id;

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, AddDishInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                this.ViewData["DishId"] = id;
                return this.View(model);
            }

            var restaurantId = await this.menusServices.EditDish(id, model);

            return this.Redirect($"/Restaurants/Edit/{restaurantId}");
        }
    }
}
