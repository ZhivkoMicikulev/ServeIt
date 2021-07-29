using Microsoft.AspNetCore.Mvc;
using ServeIt.Services.Data.Orders;
using ServeIt.Services.Data.Users;
using ServeIt.Web.ViewModels.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ServeIt.Web.Controllers
{
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
