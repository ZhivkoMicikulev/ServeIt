namespace ServeIt.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using AspNetCore.ReCaptcha;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ServeIt.Services.Data.Orders;
    using ServeIt.Services.Data.Users;
    using ServeIt.Web.ViewModels.Orders;

    public class CartController : BaseController
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService, IUsersService usersService)
        {
            this.cartService = cartService;
        }

        [ValidateReCaptcha]
        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<IActionResult> AddToCart(string id,   AddToCartInputModel model)
        {
            if (model.Quantity > 0)
            {
                await this.cartService.AddToCart(id, this.UserId(), model);
            }

            return this.Redirect($"/Restaurants/Info/{model.RestaurantId}");
        }

        [Authorize(Roles = "User")]

        public async Task<IActionResult> Items(string id)
        {
            var model = await this.cartService.GetAllItemsForOrder(id);

            return this.View(model);
        }

        [Authorize(Roles = "User")]
        public async Task<IActionResult> RemoveItem(string id)
        {
            await this.cartService.RemoveItemFromCart(id);

            return this.Redirect($"/Cart/Items/{this.UserId()}");
        }

        private string UserId()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }
    }
}
