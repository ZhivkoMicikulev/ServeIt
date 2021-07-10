using System;
using System.Collections.Generic;
using System.Text;

namespace ServeIt.Web.ViewModels.Restaurants
{
  public  class CountriesAndCitiesViewModel
    {
        public string CountryName { get; set; }

        public string CountryId { get; set; }

        public ICollection<CitiesViewModel> Cities { get; set; }
    }
}
