namespace ServeIt.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using ServeIt.Services.Data.Menus;
    using ServeIt.Services.Data.Orders;
    using ServeIt.Services.Data.Restaurants;
    using ServeIt.Web.ViewModels.Restaurants;

    public class RestaurantsController : BaseController
    {
        private readonly IRestaurantsService restaurantService;
        private readonly IMenusService menusService;
        private readonly IOrdersService ordersService;

        public RestaurantsController(IRestaurantsService restaurantService,
            IMenusService menusService,
            IOrdersService ordersService)
        {
            this.restaurantService = restaurantService;
            this.menusService = menusService;
            this.ordersService = ordersService;
        }



        public async Task<IActionResult> Edit(string id)
        {
            var ownerId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!await restaurantService.AreYouTheOwner(id, ownerId))
            {
                return this.Redirect($"/Restaurants/Info/{id}");
            }

            var menuId = await this.menusService.RestaurantMenu(id);
            var menu = await menusService.TakeAllDishes(menuId);


            var restaurantInfo = await restaurantService.RestaurantInfo(id);
            var categories = await menusService.TakeAllCategoriesByMenu(menuId);
            var orders = await this.ordersService.TakeAllOrders(id);
            var model = new EditRestaurantViewModel
            {
                RestaurantId = id,
                Dishes = menu,
                MenuCategories = categories,
                RestaurantInfo = restaurantInfo,
                Orders=orders,
                
            };



            return this.View(model);
        }

        public async Task<IActionResult> EditInfo(string id)
        {
            var Info = await this.restaurantService.RestaurantInfo(id);
            var model = new AddRestaurantInputModel
            {
                Name = Info.RestaurantName,
                About = Info.About,
                CountryId = await this.restaurantService.TakeCountryId(Info.Address.Split(", ")[0]),
                CityId = await this.restaurantService.TakeCityId(Info.Address.Split(", ")[1]),
                Email = Info.Email,
                Phone = Info.PhoneNumber,
                StreetName= Info.Address.Split(", ")[2],
            };
                 await FillCountryAndCitiesSugestion();
            this.ViewData["RestaurantId"] = id;
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditInfo(string id,AddRestaurantInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                await FillCountryAndCitiesSugestion();
                this.ViewData["RestaurantId"] = id;
                return this.View(model);
            }

           await this.restaurantService.EditRestaurantInfo(id, model);

            return this.Redirect($"/Restaurants/Edit/{id}");
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
            var menuId = await this.menusService.RestaurantMenu(id);
            var menu = await this.menusService.TakeAllDishes(menuId);


            var restaurantInfo = await restaurantService.RestaurantInfo(id);
            var categories = await menusService.TakeAllCategoriesByMenu(menuId);

            var model = new EditRestaurantViewModel
            {
                RestaurantId = id,
                Dishes = menu,
                MenuCategories = categories,
                RestaurantInfo = restaurantInfo,

            };



            return this.View(model);

           
        
        }


        private async Task FillCountryAndCitiesSugestion() {
            var countries = await this.restaurantService.GetAllCountries();
  
            this.ViewData["Countries"] = countries;
            
        }




    }
}
