namespace ServeIt.Services.Data.Orders
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ServeIt.Data.Models;
    using ServeIt.Web.ViewModels.Cart;
    using ServeIt.Web.ViewModels.Orders;

    public interface IOrdersService
    {
        Task<FinishOrderViewModel> GetAllInfoAboutOrder(User user);

        Task<bool> IsTheOrderPayed(string id);

        Task FinishOrder(string userId, FinishOrderInputModel model);

        Task<ICollection<OrdersViewModel>> TakeAllOrders(string restaurantId);

        Task<ICollection<MyOrdersViewModel>> TakeAllMyOrders(string id);

        Task<ICollection<ItemsViewModel>> TakeAllItemsFromOrder(string orderId);

        Task<string> DoneOrder(string orderId);

        Task RateOrder(string id, int rate);
    }
}
