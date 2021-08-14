namespace ServeIt.Web.ViewModels.Cart
{
    using System.Collections.Generic;

    public class RestaurantOrders
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
