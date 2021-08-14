using System.Collections.Generic;

namespace ServeIt.Web.ViewModels.Cart
{
    public class FinishOrderViewModel
    {
        public FinishOrderViewModel()
        {
            this.Restaurants = new HashSet<FinishOrderRestaurantViewModel>();
        }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public ICollection<FinishOrderRestaurantViewModel> Restaurants { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
