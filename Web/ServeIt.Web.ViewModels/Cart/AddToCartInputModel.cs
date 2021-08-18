using System.ComponentModel.DataAnnotations;

namespace ServeIt.Web.ViewModels.Orders
{
    public class AddToCartInputModel
    {
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string RestaurantId { get; set; }
    }
}
