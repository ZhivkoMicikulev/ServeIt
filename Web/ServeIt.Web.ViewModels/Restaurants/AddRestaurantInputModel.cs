using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ServeIt.Web.ViewModels.Restaurants
{
  public class AddRestaurantInputModel
    {
        [Required]
        [StringLength(10,MinimumLength =3)]
        public string Name { get; set; }


        [Required]
        public string CountryName { get; set; }

        [Required]
        public string CityName { get; set; }

        [Required]
        public string StreetName { get; set; }

        [Required]
        [StringLength(10,MinimumLength =5)]
        public  string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

[Required]
[StringLength(200 ,MinimumLength =3)]
        public string About { get; set; }

        public string ImageId { get; set; }

    }
}
