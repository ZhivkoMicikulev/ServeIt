using ServeIt.Data.Common.Repositories;
using ServeIt.Data.Models;
using ServeIt.Web.ViewModels.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServeIt.Services.Data.Restaurants
{
    public class RestaurantsService:IRestaurantsService
    {
        private readonly IRepository<Country> countriesRepository;

        public RestaurantsService(IRepository<Country> countriesRepository)
        {
            this.countriesRepository = countriesRepository;
        }

        public async Task<ICollection<CountriesAndCitiesViewModel>> GetAllCountries()
        {
            var result = countriesRepository.All()
                .Select(x => new CountriesAndCitiesViewModel
                {
                    CountryName = x.CountryName,
                    CountryId = x.Id,
                    Cities = x.Cities.Select(y => new CitiesViewModel
                    {
                        CityName = y.CityName,
                        CityId = y.Id

                    }).ToList(),

                }).OrderBy(x => x.CountryName).ToList();

            return result;
        }


    }
}
