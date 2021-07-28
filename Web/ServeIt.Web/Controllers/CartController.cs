using Microsoft.AspNetCore.Mvc;
using ServeIt.Services.Data.Menus;
using ServeIt.Services.Data.Orders;
using ServeIt.Services.Data.Restaurants;
using ServeIt.Web.ViewModels.Orders;

using System.Security.Claims;
using System.Threading.Tasks;

namespace ServeIt.Web.Controllers
{
    public class CartController:BaseController
    {
    
        private readonly ICartService cartService;
    

        public CartController(ICartService cartService,IMenusService menusService)
        {
            this.cartService = cartService;
           
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


        public async Task<IActionResult> Orders(string id)
        {
     var model=   await cartService.GetAllItemsForOrder(id);

            return this.View(model);
        }




        private string UserId()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }
    }
}
