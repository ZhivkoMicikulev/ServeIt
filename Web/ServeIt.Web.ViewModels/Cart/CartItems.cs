using System;
using System.Collections.Generic;
using System.Text;

namespace ServeIt.Web.ViewModels.Cart
{
   public class CartItems
    {
        public string Name { get; set; }

        public decimal Amount { get; set; }

        public int Quantity { get; set; }

        public string Id { get; set; }
    }
}
