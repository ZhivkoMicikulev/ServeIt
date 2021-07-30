using Microsoft.AspNetCore.Mvc;
using ServeIt.Services.Data.Orders;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServeIt.Web.Controllers.Api
{
    [ApiController]
    [Route("api")]
    public class OrdersApiController : ControllerBase
    {
        private readonly IOrdersService ordersService;

        public OrdersApiController(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }

        [HttpGet]
        [Route("getOrders/{id}")]
       public async Task<IActionResult> GetOrders(string id)
        {
            var a= await this.ordersService.TakeAllOrders(id);
            return Ok(a);
        }


    }
}
