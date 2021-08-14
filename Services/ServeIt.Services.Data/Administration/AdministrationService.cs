namespace ServeIt.Services.Data.Administration
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using ServeIt.Data.Common.Repositories;
    using ServeIt.Data.Models;
    using ServeIt.Web.ViewModels.Administration;

    public class AdministrationService : IAdministrationService
    {
        private readonly IDeletableEntityRepository<User> usersRepository;
        private readonly IDeletableEntityRepository<Restaurant> restaurantRepostiry;
        private readonly IDeletableEntityRepository<City> citiesRepository;
        private readonly IDeletableEntityRepository<Country> countriesRepositry;

        public AdministrationService(
            IDeletableEntityRepository<User> usersRepository,
            IDeletableEntityRepository<Restaurant> restaurantRepostiry,
            IDeletableEntityRepository<City> citiesRepository,
            IDeletableEntityRepository<Country> countriesRepositry)
        {
            this.usersRepository = usersRepository;
            this.restaurantRepostiry = restaurantRepostiry;
            this.citiesRepository = citiesRepository;
            this.countriesRepositry = countriesRepositry;
        }

        public async Task AddCity(string countryId, string cityName)
        {
            var city = new City
            {
                CountryId = countryId,
                CityName = cityName,
            };

            await this.citiesRepository.AddAsync(city);
            await this.citiesRepository.SaveChangesAsync();
        }

        public async Task BlockRestaurant(string restaurantId)
        {
            var restaurant = this.restaurantRepostiry.All().Where(x => x.Id == restaurantId).FirstOrDefault();

            restaurant.IsDeleted = true;
            await this.restaurantRepostiry.SaveChangesAsync();
        }

        public async Task BlockUser(string userId)
        {
            var user = this.usersRepository.All().Where(x => x.Id == userId).FirstOrDefault();

            user.IsDeleted = true;
            await this.usersRepository.SaveChangesAsync();
        }

        public async Task CreateCountry(string countryName)
        {
            if (this.countriesRepositry.All().Any(x=> x.CountryName.ToLower() == countryName.ToLower()))
            {
                var country = new Country
                {
                    CountryName = countryName,
                };

                await this.countriesRepositry.AddAsync(country);
            }
            else
            {
                var country = this.countriesRepositry.All().Where(x => x.CountryName.ToLower() == countryName.ToLower()).FirstOrDefault();
                country.IsDeleted = false;
            }

            await this.countriesRepositry.SaveChangesAsync();
        }

        public async Task<ICollection<AllCountriesViewModel>> GetAllCountries()
        {
            var countries = this.countriesRepositry.All()
                .Include(x => x.Cities)
                .Select(x =>
                new AllCountriesViewModel
                {
                    Name = x.CountryName,
                    Id = x.Id,
                    Cities = x.Cities.Select(c => new AllCitiesViewModel
                    {
                        Id = c.Id,
                        Name = c.CityName
                    }).OrderBy(c=>c.Name).ToList()

                }).OrderBy(x=>x.Name).ToList();

            return countries;
        }

        public async Task<ICollection<AllRestaurantsVIewModel>> GetAllRestaurants()
        {
            var restaurants = await this.restaurantRepostiry.All()
                 .Include(x => x.Owner)
                 .Include(x=>x.Address)
                 .Include(x => x.Address.City)
                 .Include(x => x.Address.City.Country)
                 .Select(x => new AllRestaurantsVIewModel
                 {
                     RestaurantId = x.Id,
                     Name = x.Name,
                     RegisterDate = x.CreatedOn.ToString("dd/MM/yyyy"),
                     Email = x.Email,
                     Phone = x.Phone,
                     Address = x.Address.City.Country.CountryName + ", " + x.Address.City.CityName + ", " + x.Address.StreetName,
                     OwnerName = x.Owner.FirstName + " " + x.Owner.LastName

                 }).ToListAsync();

            return restaurants;
        }

        public async Task<ICollection<AllUserViewModel>> GetAllUsers()
        {
            var users = this.usersRepository.All().Where(x=>x.UserName!="Admin")
                .Select(x => new AllUserViewModel
                {
                    UserId = x.Id,
                    Username = x.UserName,
                    Phone = x.PhoneNumber,
                    Email = x.Email,
                    FullName = x.FirstName + " " + x.LastName,
                    RegisterDate = x.CreatedOn.ToString("dd/MM/yyyy"),
                    IsDeleted = x.IsDeleted,
                    IsOwner = x.IsItOwnerOfRestaurant ? "YES" : "NO",

                }).ToList();

            return users;
        }

        public  async Task RemoveCity(string cityId)
        {
            var city = this.citiesRepository.All().Where(x => x.Id == cityId)
                .FirstOrDefault();

            city.IsDeleted = true;

            await this.citiesRepository.SaveChangesAsync();
        }

        public async Task RemoveCountry(string countryId)
        {
            var country = this.countriesRepositry.All().Where(x => x.Id == countryId).FirstOrDefault();
            country.IsDeleted = true;
            await this.countriesRepositry.SaveChangesAsync();
        }

        public async Task UnblockUser(string userId)
        {
            var user = this.usersRepository.All().Where(x => x.Id == userId).FirstOrDefault();

            user.IsDeleted = false;
            await this.usersRepository.SaveChangesAsync();
        }
    }
}
