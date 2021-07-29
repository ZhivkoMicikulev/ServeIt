using System;
using System.Collections.Generic;
using System.Text;

namespace ServeIt.Web.ViewModels.Orders
{
  public  class OrdersViewModel
    {
        public string OrderId { get; set; }

        public string FullName { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }

        public string Street { get; set; }
        public string Date { get; set; }

        public string Hour { get; set; }

        public bool IsItPayed { get; set; }

        public decimal Amount { get; set; }





    }
}
