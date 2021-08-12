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
        Task<ICollection<CountriesViewModel>> GetAllCountries();

       Task <ICollection<AllRestaurantViewModel>> GetAllRestaurants();

        Task<ICollection<AllRestaurantViewModel>> GetAllRestaurants(string townName);

        Task<ICollection<AllRestaurantViewModel>> GetAllOwnedRestaurants(string id);


        Task AddRestaurant(AddRestaurantInputModel model,string ownerId);

        Task <bool> AreYouTheOwner(string restaurantId,string ownerId);
        
        Task <RestaurantInfoViewModel> RestaurantInfo(string restaurantId);

        Task EditRestaurantInfo(string restaurantId, AddRestaurantInputModel model);

        Task<string> TakeCountryId(string countryName);

        Task<string> TakeCityId(string cityName);

        Task<bool> isTheAddressChanged(string cityId, string streetName);

        




    }
}
