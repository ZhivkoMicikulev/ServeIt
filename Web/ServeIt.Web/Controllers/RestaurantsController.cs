namespace ServeIt.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ServeIt.Services.Data.Menus;
    using ServeIt.Services.Data.Orders;
    using ServeIt.Services.Data.Restaurants;
    using ServeIt.Services.Data.Users;
    using ServeIt.Web.ViewModels.Restaurants;

    public class RestaurantsController : BaseController
    {
        private readonly IRestaurantsService restaurantService;
        private readonly IMenusService menusService;
        private readonly IOrdersService ordersService;
        private readonly IUsersService usersService;

        public RestaurantsController(
            IRestaurantsService restaurantService,
            IMenusService menusService,
            IOrdersService ordersService,
            IUsersService usersService)
        {
            this.restaurantService = restaurantService;
            this.menusService = menusService;
            this.ordersService = ordersService;
            this.usersService = usersService;
        }

        [Authorize(Roles = "Restaurant")]
        public async Task<IActionResult> Edit(string id)
        {
            var ownerId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!await this.restaurantService.AreYouTheOwner(id, ownerId))
            {
                return this.Redirect($"/Restaurants/Info/{id}");
            }

            var menuId = await this.menusService.RestaurantMenu(id);
            var menu = await this.menusService.TakeAllDishes(menuId);

            var restaurantInfo = await this.restaurantService.RestaurantInfo(id);
            var categories = await this.menusService.TakeAllCategoriesByMenu(menuId);
            var orders = await this.ordersService.TakeAllOrders(id);
            var model = new EditRestaurantViewModel
            {
                RestaurantId = id,
                Dishes = menu,
                MenuCategories = categories,
                RestaurantInfo = restaurantInfo,
                Orders = orders,
            };

            return this.View(model);
        }

        [Authorize(Roles = "Restaurant")]
        public async Task<IActionResult> EditInfo(string id)
        {
            var ownerId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!await this.restaurantService.AreYouTheOwner(id, ownerId))
            {
                return this.Redirect($"/Restaurants/Info/{id}");
            }

            var info = await this.restaurantService.RestaurantInfo(id);
            var model = new AddRestaurantInputModel
            {
                Name = info.RestaurantName,
                About = info.About,
                CountryId = await this.restaurantService.TakeCountryId(info.Address.Split(", ")[0]),
                CityId = await this.restaurantService.TakeCityId(info.Address.Split(", ")[1]),
                Email = info.Email,
                Phone = info.PhoneNumber,
                StreetName = info.Address.Split(", ")[2],
            };
            await this.FillCountryAndCitiesSugestion();
            this.ViewData["RestaurantId"] = id;
            return this.View(model);
        }

        [Authorize(Roles = "Restaurant")]

        [HttpPost]
        public async Task<IActionResult> EditInfo(string id, AddRestaurantInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                await this.FillCountryAndCitiesSugestion();
                this.ViewData["RestaurantId"] = id;
                return this.View(model);
            }

            await this.restaurantService.EditRestaurantInfo(id, model);

            return this.Redirect($"/Restaurants/Edit/{id}");
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await this.restaurantService.GetAllRestaurants();

            return this.View(model);
        }

        [HttpGet("/Restaurants/All/{town}")]
        public async Task<IActionResult> All(string town)
        {
            var model = await this.restaurantService.GetAllRestaurants(town);
            if (model == null)
            {
                this.ViewData["town"] = town;
            }

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> FindRestaurant(string town)
        {

            if (string.IsNullOrEmpty(town))
            {
                return this.Redirect("/Restaurants/All");
            }

            return this.Redirect($"/Restaurants/All/{town}");
        }

        [Authorize(Roles = "Restaurant")]
        public async Task<IActionResult> OwnedRestaurants(string id)
        {
            var model = await this.restaurantService.GetAllOwnedRestaurants(id);

            return this.View(model);
        }

        [Authorize(Roles = "Restaurant")]
        public async Task<IActionResult> Add()
        {
             await this.FillCountryAndCitiesSugestion();

             return this.View();
        }

        [Authorize(Roles = "Restaurant")]
        [HttpPost]
        public async Task<IActionResult> Add(AddRestaurantInputModel model)
        {
             await this.FillCountryAndCitiesSugestion();

             if (!this.ModelState.IsValid)
            {
                return this.View(model);
           }

             var ownerId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

             await this.restaurantService.AddRestaurant(model, ownerId);

             return this.Redirect("/Restaurants/All");
        }

        public async Task<IActionResult> Info(string id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await this.usersService.GetUser(userId);
            if (user == null)
            {
                return this.Redirect("/Users/Login");
            }

            var menuId = await this.menusService.RestaurantMenu(id);
            var menu = await this.menusService.TakeAllDishes(menuId);

            var restaurantInfo = await this.restaurantService.RestaurantInfo(id);
            var categories = await this.menusService.TakeAllCategoriesByMenu(menuId);

            var model = new EditRestaurantViewModel
            {
                RestaurantId = id,
                Dishes = menu,
                MenuCategories = categories,
                RestaurantInfo = restaurantInfo,
                UserFullName = user.FirstName + " " + user.LastName,
                UserPhone = user.PhoneNumber,
                UserEmail = user.Email,
                UserId = user.Id,
            };

            return this.View(model);
        }

        private async Task FillCountryAndCitiesSugestion()
        {
            var countries = await this.restaurantService.GetAllCountries();

            this.ViewData["Countries"] = countries;
        }
    }
}
