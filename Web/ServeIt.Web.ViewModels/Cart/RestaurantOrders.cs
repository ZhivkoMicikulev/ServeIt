using System;
using System.Collections.Generic;
using System.Text;

namespace ServeIt.Web.ViewModels.Cart
{
 public   class RestaurantOrders
    {
        public RestaurantOrders()
        {
            this.Dishes = new HashSet<CartItems>();
        }
        public string RestaurantName { get; set; }

        public decimal TotalAmount { get; set; }

        public ICollection<CartItems> Dishes { get; set; }
    }
}
