

namespace ServeIt.Web.ViewModels.Orders
{
  public  class MyOrdersViewModel
    {
        public string OrderId { get; set; }

        public decimal Price { get; set; }

        public string RestaurantName { get; set; }

        public string Date { get; set; }

        public bool IsItRated { get; set; }

        public int Rating { get; set; }
    }
}
