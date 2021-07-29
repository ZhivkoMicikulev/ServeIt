using Microsoft.AspNetCore.Mvc;
using ServeIt.Services.Data.Menus;
using ServeIt.Services.Data.Orders;
using ServeIt.Services.Data.Restaurants;
using ServeIt.Services.Data.Users;
using ServeIt.Web.ViewModels.Orders;

using System.Security.Claims;
using System.Threading.Tasks;

namespace ServeIt.Web.Controllers
{
    public class CartController:BaseController
    {
    
        private readonly ICartService cartService;
        private readonly IUsersService usersService;

        public CartController(ICartService cartService,IUsersService usersService)
        {
            this.cartService = cartService;
            this.usersService = usersService;
        }

        [HttpPost]
         public async Task<IActionResult> AddToCart(string id,   AddToCartInputModel model)
        {       

            if (model.Quantity>0)
            {
                await this.cartService.AddToCart(id, UserId(),model);
            }
           return this.Redirect($"/Restaurants/Info/{model.RestaurantId}");
        }
        public async Task<IActionResult> ConfirmOrder(string id)
        {
            var user =await this.usersService.GetUser(UserId());

            var model = await this.cartService.GetAllInfoAboutOrder(user);

            return this.View(model);
        }

        public async Task<IActionResult> Orders(string id)
        {
     var model=   await cartService.GetAllItemsForOrder(id);

            return this.View(model);
        }

        public async Task<IActionResult> RemoveItem(string id)
        {
            await this.cartService.RemoveItemFromCart(id);

            return this.Redirect($"/Cart/Orders/{UserId()}");
        }



        private string UserId()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }
    }
}
