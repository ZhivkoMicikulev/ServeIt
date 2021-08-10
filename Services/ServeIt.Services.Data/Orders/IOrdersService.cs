using ServeIt.Data.Models;
using ServeIt.Web.ViewModels.Cart;
using ServeIt.Web.ViewModels.Orders;
using ServeIt.Web.ViewModels.Reservations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServeIt.Services.Data.Orders
{
 public   interface IOrdersService
    {
        Task<FinishOrderViewModel> GetAllInfoAboutOrder(User user);

        Task FinishOrder(string userId, FinishOrderInputModel model);

        Task<ICollection<OrdersViewModel>> TakeAllOrders(string restaurantId);

        Task<ICollection<MyOrdersViewModel>> TakeAllMyOrders(string id);


        Task<ICollection<ItemsViewModel>> TakeAllItemsFromOrder(string orderId);

        Task<string> DoneOrder(string orderId);
    }
}
