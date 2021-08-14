namespace ServeIt.Web.ViewModels.Restaurants
{
    using System.Collections.Generic;

    public class CountriesViewModel
    {
        public string CountryName { get; set; }

        public string CountryId { get; set; }

        public ICollection<CitiesViewModel> Cities { get; set; }
    }
}
