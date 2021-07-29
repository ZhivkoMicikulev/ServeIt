using System;
using System.Collections.Generic;
using System.Text;

namespace ServeIt.Web.ViewModels.Cart
{
   public class CartItemsViewModel
    {
        public CartItemsViewModel()
        {
            this.Restaurants = new HashSet<RestaurantOrders>();
        }

        public ICollection<RestaurantOrders> Restaurants { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
