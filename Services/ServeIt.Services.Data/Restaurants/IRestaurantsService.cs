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

        Task<ICollection<AllRestaurantViewModel>> GetAllOwnedRestaurants(string id);


        Task AddRestaurant(AddRestaurantInputModel model,string ownerId);

   

    }
}
