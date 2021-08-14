namespace ServeIt.Web.ViewModels.Menu
{
    using System.ComponentModel.DataAnnotations;

    using ServeIt.Common;

    public class AddDishInputModel
    {
        [Required(ErrorMessage = GlobalConstants.ErrorMsgForField)]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "The field must be with a minimum length of 3 and a maximum length of 20.")]
        public string Name { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMsgForField)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMsgForField)]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "The field must be with a minimum length of 3 and a maximum length of 20.")]
        public string CategoryName { get; set; }

        [Required]
        public string Ingredients { get; set; }

        [StringLength(20, MinimumLength = 3, ErrorMessage = "The field must be with a minimum length of 3 and a maximum length of 20.")]
        public string FoodStyle { get; set; }
    }
}
