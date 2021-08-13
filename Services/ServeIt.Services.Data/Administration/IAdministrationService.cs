using ServeIt.Web.ViewModels.Administration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServeIt.Services.Data.Administration
{
    public interface IAdministrationService
    {
        Task<ICollection<AllUserViewModel>> GetAllUsers();

        Task<ICollection<AllRestaurantsVIewModel>> GetAllRestaurants();

        Task<ICollection<AllCountriesViewModel>> GetAllCountries();

        Task CreateCountry(string countryName);

        Task AddCity(string countryId,string cityName);
        Task RemoveCountry(string countryId);
        Task RemoveCity(string cityId);


        Task BlockUser(string userId);

        Task BlockRestaurant(string restaurantId);


        Task UnblockUser(string userId);

    }
}
