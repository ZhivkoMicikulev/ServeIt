using System.ComponentModel.DataAnnotations;

namespace ServeIt.Web.ViewModels.Cart
{
    public class FinishOrderInputModel
    {
        [Required]
        public string StreetName { get; set; }
    }
}
