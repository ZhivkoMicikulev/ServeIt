namespace ServeIt.Web.ViewModels.Restaurants
{
    using System.ComponentModel.DataAnnotations;

    public class AddRestaurantInputModel
    {
        [Required(ErrorMessage = "Restaurant name is required.")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "The field must be with a minimum length of 3 and a maximum length of 10.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        public string CountryId { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string CityId { get; set; }

        [Required(ErrorMessage = "Street is required.")]

        public string StreetName { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
        [StringLength(10, MinimumLength =5, ErrorMessage = "The field must be with a minimum length of 5 and a maximum length of 10.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email is required.")]

        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "About is required.")]

        [StringLength(200, MinimumLength =3, ErrorMessage = "The field must be with a minimum length of 3 and a maximum length of 200.")]
        public string About { get; set; }

        public string ImageUrl { get; set; }
    }
}
