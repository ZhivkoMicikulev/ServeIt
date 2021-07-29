using ServeIt.Web.ViewModels.Menu;
using ServeIt.Web.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServeIt.Web.ViewModels.Restaurants
{
   public class EditRestaurantViewModel
    {
        public string RestaurantId { get; set; }

        public ICollection<DishViewModel> Dishes { get; set; }

        public ICollection<string> MenuCategories { get; set; }

        public RestaurantInfoViewModel  RestaurantInfo { get; set; }

        public ICollection<OrdersViewModel> Orders { get; set; }
    }
}
