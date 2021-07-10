using ServeIt.Data.Models;
using ServeIt.Web.ViewModels.Restaurants;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServeIt.Services.Data.Restaurants
{
   public interface IRestaurantsService
    {
        Task<ICollection<CountriesAndCitiesViewModel>> GetAllCountries();

    }
}
