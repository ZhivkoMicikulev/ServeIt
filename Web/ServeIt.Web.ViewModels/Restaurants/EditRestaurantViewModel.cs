using ServeIt.Web.ViewModels.Menu;
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
    }
}
