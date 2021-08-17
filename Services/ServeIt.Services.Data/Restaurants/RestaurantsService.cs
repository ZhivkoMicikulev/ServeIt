namespace ServeIt.Services.Data.Restaurants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using ServeIt.Data.Common.Repositories;
    using ServeIt.Data.Models;
    using ServeIt.Web.ViewModels.Restaurants;

    public class RestaurantsService : IRestaurantsService
    {
        private readonly IDeletableEntityRepository<Country> countriesRepository;
        private readonly IDeletableEntityRepository<Restaurant> restaurantRepository;
        private readonly IDeletableEntityRepository<City> citiesRepository;
        private readonly IRepository<Address> addresseRepository;
      

        public RestaurantsService(
            IDeletableEntityRepository<Country> countriesRepository,
            IDeletableEntityRepository<Restaurant> restaurantRepository,
            IDeletableEntityRepository<City> citiesRepository,
            IRepository<Address> addresseRepository)
         
        {
            this.countriesRepository = countriesRepository;
            this.restaurantRepository = restaurantRepository;
            this.citiesRepository = citiesRepository;
            this.addresseRepository = addresseRepository;
         
        }

        public async Task AddRestaurant(AddRestaurantInputModel model, string ownerId)
        {
            var adress = new Address
            {
                CityId = model.CityId,
                StreetName = model.StreetName,
            };
            await this.addresseRepository.AddAsync(adress);
            await this.addresseRepository.SaveChangesAsync();

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

            await this.restaurantRepository.AddAsync(restaurant);
            await this.restaurantRepository.SaveChangesAsync();
        }

        public async Task<bool> AreYouTheOwner(string restaurantId,string ownerId)
        {
            var result = this.restaurantRepository.All().Where(x => x.Id == restaurantId).Any(x => x.OwnerId == ownerId);

            return result;
        }

        public async Task EditRestaurantInfo(string restaurantId, AddRestaurantInputModel model)
        {
            var restaurant = this.restaurantRepository.All().Where(x => x.Id == restaurantId)
                .FirstOrDefault();

            restaurant.Name = model.Name;
            if (!await this.IsTheAddressChanged(model.CityId, model.StreetName))
            {
                var address = new Address
                {
                    CityId = model.CityId,
                    StreetName = model.StreetName,
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
            var result = this.countriesRepository.All()
                .Select(x => new CountriesViewModel
                {
                    CountryName = x.CountryName,
                    CountryId = x.Id,
                    Cities = x.Cities.Select(c => new CitiesViewModel
                    {
                        CityId = c.Id,
                        CityName = c.CityName,
                    }).OrderBy(c => c.CityName).ToList(),
                }).OrderBy(x => x.CountryName).ToList();

            return result;
        }

        public async Task<ICollection<AllRestaurantViewModel>> GetAllOwnedRestaurants(string id)
        {
            var restaurants = this.restaurantRepository.All().Where(x => x.OwnerId == id)
                .Select(x =>
                new AllRestaurantViewModel
                {
                    Name = x.Name,
                    Country = x.Address.City.Country.CountryName,
                    City = x.Address.City.CityName,
                    Street = x.Address.StreetName,
                    RestaurantId = x.Id,
                    Rating = x.Orders.Count(o => o.IsItRated == true) == 0 ? 0 : Convert.ToDecimal(x.Orders.Where(o => o.IsItRated == true).Sum(o => o.Rating)) / x.Orders.Count(o => o.IsItRated == true),
                }).OrderByDescending(x => x.Rating).ThenBy(x => x.Name).ToList();

            return restaurants;
        }

        public async Task<ICollection<AllRestaurantViewModel>> GetAllRestaurants()
        {

            var restaurants = this.restaurantRepository.All()
                .Include(x => x.Orders)
                .Select(x =>
                new AllRestaurantViewModel
                {
                    Name = x.Name,
                    Country = x.Address.City.Country.CountryName,
                    City = x.Address.City.CityName,
                    Street = x.Address.StreetName,
                    RestaurantId = x.Id,
                    Rating = x.Orders.Count(o => o.IsItRated == true) == 0 ? 0 : Convert.ToDecimal(x.Orders.Where(o => o.IsItRated).Sum(o => o.Rating)) / x.Orders.Count(o => o.IsItRated == true),
                }).OrderByDescending(x => x.Rating)
                .ThenBy(x => x.Country)
                .ThenBy(x => x.City)
                .ThenBy(x => x.Name).ToList();

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
                       Rating = x.Orders.Count(o => o.IsItRated == true) == 0 ? 0 : Convert.ToDecimal(x.Orders.Where(o => o.IsItRated == true).Sum(o => o.Rating)) / x.Orders.Count(o => o.IsItRated == true),
                   })
                   .OrderBy(x => x.Rating)
                   .ToList();

            return restaurants;
        }

        public async Task<bool> IsTheAddressChanged(string cityId, string streetName)
        {
            var result = this.addresseRepository.All().Any(x => x.CityId == cityId && x.StreetName == streetName);

            return result;
        }

        public async Task<RestaurantInfoViewModel> RestaurantInfo(string restaurantId)
        {
            var result = this.restaurantRepository.All().Where(x => x.Id == restaurantId)
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
            var result = this.citiesRepository.All().Where(x => x.CityName == cityName).Select(x => x.Id).FirstOrDefault();
            return result;
        }

        public async Task<string> TakeCountryId(string countryName)
        {
            var result = this.countriesRepository.All().Where(x => x.CountryName == countryName).Select(x => x.Id).FirstOrDefault();
            return result;
        }
    }
}
