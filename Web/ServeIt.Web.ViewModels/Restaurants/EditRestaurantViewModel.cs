﻿namespace ServeIt.Web.ViewModels.Restaurants
{
    using System.Collections.Generic;

    using ServeIt.Web.ViewModels.Menu;
    using ServeIt.Web.ViewModels.Orders;

    public class EditRestaurantViewModel
    {
        public string RestaurantId { get; set; }

        public ICollection<DishViewModel> Dishes { get; set; }

        public ICollection<string> MenuCategories { get; set; }

        public RestaurantInfoViewModel RestaurantInfo { get; set; }

        public ICollection<OrdersViewModel> Orders { get; set; }

        public string UserFullName { get; set; }

        public string UserPhone { get; set; }

        public string UserEmail { get; set; }

        public string UserId { get; set; }
    }
}
