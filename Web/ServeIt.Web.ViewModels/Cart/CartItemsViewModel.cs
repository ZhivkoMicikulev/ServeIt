namespace ServeIt.Web.ViewModels.Cart
{
    using System.Collections.Generic;

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
