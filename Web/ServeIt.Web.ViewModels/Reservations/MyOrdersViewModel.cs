using System;
using System.Collections.Generic;
using System.Text;

namespace ServeIt.Web.ViewModels.Orders
{
  public  class MyOrdersViewModel
    {
        public string OrderId { get; set; }

        public decimal Price { get; set; }

        public string RestaurantName { get; set; }

        public string Date { get; set; }
    }
}
