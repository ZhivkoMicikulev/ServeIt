namespace ServeIt.Services.Data.Orders
{
    using System.Threading.Tasks;

    using ServeIt.Data.Models;
    using ServeIt.Web.ViewModels.Cart;
    using ServeIt.Web.ViewModels.Orders;

    public interface ICartService
    {
        Task AddToCart(string dishId, string userId, AddToCartInputModel model);

        Task<CartItemsViewModel> GetAllItemsForOrder(string userId);

        Task RemoveItemFromCart(string itemId);
    }
}
