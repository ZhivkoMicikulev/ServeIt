using System;
using System.Collections.Generic;
using System.Text;

namespace ServeIt.Web.ViewModels.Orders
{
   public class AddToCartInputModel
    {
        public int Quantity { get; set; }
        public string RestaurantId { get; set; }
    }
}
