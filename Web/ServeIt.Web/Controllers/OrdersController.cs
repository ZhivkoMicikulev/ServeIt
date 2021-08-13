using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using ServeIt.Services.Data.Orders;
using ServeIt.Services.Data.Users;
using ServeIt.Web.ViewModels.Cart;

using System.Security.Claims;
using System.Threading.Tasks;

namespace ServeIt.Web.Controllers
{
    [Authorize]

    public class OrdersController:BaseController
    {
        private readonly IOrdersService ordersService;
        private readonly IUsersService usersService;
    

        public OrdersController(IOrdersService ordersService,
            IUsersService usersService)
         
        {
            this.ordersService = ordersService;
            this.usersService = usersService;
    
        }

        public async Task<IActionResult> OrderedItems(string id)
        {
            var model = await this.ordersService.TakeAllItemsFromOrder(id);
            this.ViewData["OrderId"] = id;
            return this.View(model);
        }
    
        public async Task<IActionResult> DoneOrder(string id)
        {
            var restaurantId = await this.ordersService.DoneOrder(id);

            return this.Redirect($"/Restaurants/Edit/{restaurantId}");

        }
        public async Task<IActionResult> MyOrders(string id)
        {
            var model = await this.ordersService.TakeAllMyOrders(id);

            return this.View(model);

        }

        [HttpPost]
        public async Task<IActionResult> RateOrder(string id,int rate)
        {
            await this.ordersService.RateOrder(id, rate);

            return this.Redirect($"/Orders/MyOrders/{UserId()}");

        }



        [HttpPost]
        public async Task<IActionResult> FinishOrder(string id, FinishOrderInputModel model)
        {
            if (string.IsNullOrEmpty(model.StreetName))
            {
                return this.Redirect("/Cart/ConfirmOrder");
            }



            await this.ordersService.FinishOrder(id, model);

            return this.Redirect($"/");
        }

        public async Task<IActionResult> ConfirmOrder(string id)
        {
            var user = await this.usersService.GetUser(UserId());

            var model = await this.ordersService.GetAllInfoAboutOrder(user);
            this.ViewData["UserId"] = UserId();

            return this.View(model);
        }
        private string UserId()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }
    }
}
