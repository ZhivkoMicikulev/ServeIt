using ServeIt.Web.ViewModels.Cart;
using ServeIt.Web.ViewModels.Orders;
using ServeIt.Data.Models;
using System.Threading.Tasks;

namespace ServeIt.Services.Data.Orders
{
    public interface ICartService
    {
        Task AddToCart(string dishId,string userId,AddToCartInputModel model);

        Task<CartItemsViewModel> GetAllItemsForOrder(string userId);

        Task RemoveItemFromCart(string itemId);

        Task<FinishOrderViewModel> GetAllInfoAboutOrder(User user);
      
    }
}
