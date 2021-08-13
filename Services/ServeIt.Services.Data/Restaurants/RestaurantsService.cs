using Microsoft.EntityFrameworkCore;
using ServeIt.Data.Common.Repositories;
using ServeIt.Data.Models;
using ServeIt.Web.ViewModels.Restaurants;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServeIt.Services.Data.Restaurants
{
    public class RestaurantsService:IRestaurantsService
    {
        private readonly IRepository<Country> countriesRepository;
        private readonly IDeletableEntityRepository<Restaurant> restaurantRepository;
        private readonly IRepository<City> citiesRepository;
        private readonly IRepository<Address> addresseRepository;
        private readonly IDeletableEntityRepository<Order> ordersRepository;

        public RestaurantsService(IRepository<Country> countriesRepository,IDeletableEntityRepository<Restaurant> restaurantRepository,
            IRepository<City> citiesRepository,
            IRepository<Address> addresseRepository,
            IDeletableEntityRepository<Order> ordersRepository


            )
        {
            this.countriesRepository = countriesRepository;
            this.restaurantRepository = restaurantRepository;
            this.citiesRepository = citiesRepository;
            this.addresseRepository = addresseRepository;
            this.ordersRepository = ordersRepository;
        }

        public async Task AddRestaurant(AddRestaurantInputModel model,string ownerId)
        {
            var adress = new Address
            {
                CityId = model.CityId,
                StreetName = model.StreetName
            };
            var restaurant = new Restaurant
            {
                Name = model.Name,
                AddressId = adress.Id,
                Email = model.Email,
                Phone = model.Phone,
                OwnerId = ownerId,
                RegisteredAt = DateTime.UtcNow,
                About = model.About,

            };

            await restaurantRepository.AddAsync(restaurant);
            await restaurantRepository.SaveChangesAsync();
            

        }

        public async Task<bool> AreYouTheOwner(string restaurantId,string ownerId)
        {
            var result = restaurantRepository.All().Where(x => x.Id == restaurantId).Any(x => x.OwnerId == ownerId);

            return result;
        }

        public async Task EditRestaurantInfo(string restaurantId, AddRestaurantInputModel model)
        {
            var restaurant = restaurantRepository.All().Where(x => x.Id == restaurantId)
                .FirstOrDefault();

            restaurant.Name = model.Name;
            if ( !await isTheAddressChanged(model.CityId,model.StreetName))
            {
                var address = new Address
                {
                    CityId = model.CityId,
                    StreetName = model.StreetName
                };

                restaurant.Address = address;
            }
            

            restaurant.About = model.About;

            restaurant.Email = model.Email;

            restaurant.Phone = model.Phone;

             await this.restaurantRepository.SaveChangesAsync();
        }

        public async Task<ICollection<CountriesViewModel>> GetAllCountries()
        {
            var result = countriesRepository.All()
                .Select(x => new CountriesViewModel
                {
                    CountryName = x.CountryName,
                    CountryId=x.Id,
                    Cities = x.Cities.Select(c => new CitiesViewModel
                    {
                        CityId=c.Id,
                        CityName = c.CityName,
                    }).OrderBy(c => c.CityName).ToList(),

                }).OrderBy(x => x.CountryName).ToList();

            return result;
        }

        public async Task<ICollection<AllRestaurantViewModel>> GetAllOwnedRestaurants(string id)
        {


            var restaurants = restaurantRepository.All().Where(x => x.OwnerId == id)
                .Select(x =>
                new AllRestaurantViewModel
                {
                    Name = x.Name,
                    Country = x.Address.City.Country.CountryName,
                    City = x.Address.City.CityName,
                    Street = x.Address.StreetName,
                    RestaurantId = x.Id,
                    Rating = x.Orders.Count(o => o.IsItRated == true) == 0 ? 0 : Convert.ToDecimal(x.Orders.Where(o => o.IsItRated == true).Sum(o => o.Rating)) / (x.Orders.Count(o => o.IsItRated == true))

                }).OrderBy(x => x.Rating).ToList();

            return restaurants;
        }

        public async Task <ICollection<AllRestaurantViewModel>> GetAllRestaurants()
        {

            var restaurants = restaurantRepository.All()
                .Include(x=>x.Orders)
                .Select(x =>                
                new AllRestaurantViewModel
                {
                    Name = x.Name,
                    Country = x.Address.City.Country.CountryName,
                    City = x.Address.City.CityName,
                    Street = x.Address.StreetName,
                    RestaurantId = x.Id,
                    Rating = x.Orders.Count(o => o.IsItRated == true) == 0 ? 0 : Convert.ToDecimal(x.Orders.Where(o => o.IsItRated == true).Sum(o => o.Rating)) / (x.Orders.Count(o => o.IsItRated == true))


                }).OrderByDescending(x => x.Rating).ToList();

            return restaurants;
        }

        public async Task<ICollection<AllRestaurantViewModel>> GetAllRestaurants(string townName)
        {
            var city = this.citiesRepository.All().Where(x => x.CityName.ToLower() == townName.ToLower()).Select(x => x.Id).FirstOrDefault();
            if (city == null)
            {
                return null;
            }
            var restaurants = this.restaurantRepository.All()
                .Include(x => x.Address)
                .Where(x => x.Address.CityId == city)
                   .Select(x => new AllRestaurantViewModel
                   {
                       Name = x.Name,
                       Country = x.Address.City.Country.CountryName,
                       City = x.Address.City.CityName,
                       Street = x.Address.StreetName,
                       RestaurantId = x.Id,
                       Rating = x.Orders.Count(o => o.IsItRated == true) == 0 ? 0 : Convert.ToDecimal(x.Orders.Where(o => o.IsItRated == true).Sum(o => o.Rating)) / (x.Orders.Count(o => o.IsItRated == true))

                   })
                   .OrderBy(x => x.Rating)
                   .ToList();

            return restaurants;
        }

        public async Task<bool> isTheAddressChanged(string cityId, string streetName)
        {
            var result = this.addresseRepository.All().Any(x => x.CityId == cityId && x.StreetName == streetName);

            return result;

        }

        public async Task<RestaurantInfoViewModel> RestaurantInfo(string restaurantId)
        {
            var result = restaurantRepository.All().Where(x => x.Id == restaurantId)
                 .Select(x => new RestaurantInfoViewModel
                 {
                     
                     RestaurantName = x.Name,
                     Address = x.Address.City.Country.CountryName + ", " + x.Address.City.CityName + ", " + x.Address.StreetName,
                     About = x.About,
                     Email = x.Email,
                     PhoneNumber = x.Phone,
                 

                 }).FirstOrDefault();

            return result;
        }

        public async Task<string> TakeCityId(string cityName)
        {
            var result = citiesRepository.All().Where(x => x.CityName == cityName).Select(x => x.Id).FirstOrDefault();
            return result;
        }

        public async Task<string> TakeCountryId(string countryName)
        {
            var result = countriesRepository.All().Where(x => x.CountryName == countryName).Select(x => x.Id).FirstOrDefault();
            return result;
        }
    }

        
}
