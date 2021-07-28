using ServeIt.Web.ViewModels.Cart;
using ServeIt.Web.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServeIt.Services.Data.Orders
{
    public interface ICartService
    {
        Task AddToCart(string dishId,string userId,AddToCartInputModel model);

        Task<CartItemsViewModel> GetAllItemsForOrder(string userId);

        Task RemoveItemFromCart(string itemId);
      
    }
}
