namespace ServeIt.Services.Data.Tests
{
    using Moq;
    using ServeIt.Data.Common.Repositories;
    using ServeIt.Data.Models;
    using ServeIt.Services.Data.Administration;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;

 public class AdministrationServiceTests 
    {
        [Fact]
        public void TestAddCityMethodShouldReturnCorrect()
        {
            var cityList = new List<City>();
            var countryList = new List<Country>();
            var usersList = new List<User>();
            var restaurantList = new List<Restaurant>();

            var mockCityRepo = new Mock<IDeletableEntityRepository<City>>();
            mockCityRepo.Setup(x => x.All()).Returns(cityList.AsQueryable());
            mockCityRepo.Setup(x => x.AddAsync(It.IsAny<City>()))
                .Callback((City city) => cityList.Add(city));

            var mockCountryRepo = new Mock<IDeletableEntityRepository<Country>>();
            mockCountryRepo.Setup(x => x.All()).Returns(countryList.AsQueryable());
            mockCountryRepo.Setup(x => x.AddAsync(It.IsAny<Country>()))
                .Callback((Country country) => countryList.Add(country));

            var mockUsersRepo = new Mock<IDeletableEntityRepository<User>>();
            mockUsersRepo.Setup(x => x.All()).Returns(usersList.AsQueryable());
            mockUsersRepo.Setup(x => x.AddAsync(It.IsAny<User>()))
                .Callback((User user) => usersList.Add(user));

            var mockRestaurantRepo = new Mock<IDeletableEntityRepository<Restaurant>>();
            mockRestaurantRepo.Setup(x => x.All()).Returns(restaurantList.AsQueryable());
            mockRestaurantRepo.Setup(x => x.AddAsync(It.IsAny<Restaurant>()))
                .Callback((Restaurant restaurant) => restaurantList.Add(restaurant));

            var service = new AdministrationService(
              mockUsersRepo.Object,
              mockRestaurantRepo.Object,
              mockCityRepo.Object,
              mockCountryRepo.Object);

            service.AddCity("b", "Plovdiv");

            Assert.Equal(1, cityList.Count);
        }

        [Fact]
        public void TestAddCountryShouldAddCountry()
        {
            var cityList = new List<City>();
            var countryList = new List<Country>();
            var usersList = new List<User>();
            var restaurantList = new List<Restaurant>();

            var mockCityRepo = new Mock<IDeletableEntityRepository<City>>();
            mockCityRepo.Setup(x => x.All()).Returns(cityList.AsQueryable());
            mockCityRepo.Setup(x => x.AddAsync(It.IsAny<City>()))
                .Callback((City city) => cityList.Add(city));

            var mockCountryRepo = new Mock<IDeletableEntityRepository<Country>>();
            mockCountryRepo.Setup(x => x.All()).Returns(countryList.AsQueryable());
            mockCountryRepo.Setup(x => x.AddAsync(It.IsAny<Country>()))
                .Callback((Country country) => countryList.Add(country));

            var mockUsersRepo = new Mock<IDeletableEntityRepository<User>>();
            mockUsersRepo.Setup(x => x.All()).Returns(usersList.AsQueryable());
            mockUsersRepo.Setup(x => x.AddAsync(It.IsAny<User>()))
                .Callback((User user) => usersList.Add(user));

            var mockRestaurantRepo = new Mock<IDeletableEntityRepository<Restaurant>>();
            mockRestaurantRepo.Setup(x => x.All()).Returns(restaurantList.AsQueryable());
            mockRestaurantRepo.Setup(x => x.AddAsync(It.IsAny<Restaurant>()))
                .Callback((Restaurant restaurant) => restaurantList.Add(restaurant));

            var service = new AdministrationService(
              mockUsersRepo.Object,
              mockRestaurantRepo.Object,
              mockCityRepo.Object,
              mockCountryRepo.Object);

            service.CreateCountry("Bulgaria");
            

            Assert.Equal(1, countryList.Count);
        }

        [Fact]
        public async void TestGetAllCountriesMehtod()
        {
            var cityList = new List<City>();
            var countryList = new List<Country>();
            var usersList = new List<User>();
            var restaurantList = new List<Restaurant>();

            var mockCityRepo = new Mock<IDeletableEntityRepository<City>>();
            mockCityRepo.Setup(x => x.All()).Returns(cityList.AsQueryable());
            mockCityRepo.Setup(x => x.AddAsync(It.IsAny<City>()))
                .Callback((City city) => cityList.Add(city));

            var mockCountryRepo = new Mock<IDeletableEntityRepository<Country>>();
            mockCountryRepo.Setup(x => x.All()).Returns(countryList.AsQueryable());
            mockCountryRepo.Setup(x => x.AddAsync(It.IsAny<Country>()))
                .Callback((Country country) => countryList.Add(country));

            var mockUsersRepo = new Mock<IDeletableEntityRepository<User>>();
            mockUsersRepo.Setup(x => x.All()).Returns(usersList.AsQueryable());
            mockUsersRepo.Setup(x => x.AddAsync(It.IsAny<User>()))
                .Callback((User user) => usersList.Add(user));

            var mockRestaurantRepo = new Mock<IDeletableEntityRepository<Restaurant>>();
            mockRestaurantRepo.Setup(x => x.All()).Returns(restaurantList.AsQueryable());
            mockRestaurantRepo.Setup(x => x.AddAsync(It.IsAny<Restaurant>()))
                .Callback((Restaurant restaurant) => restaurantList.Add(restaurant));

            var service = new AdministrationService(
              mockUsersRepo.Object,
              mockRestaurantRepo.Object,
              mockCityRepo.Object,
              mockCountryRepo.Object);

            var country = new Country
            {
                Id = "b",
                CountryName = "Bulgaria",
                Cities=new List<City>()
            };

            var city = new City
            {
                CityName = "Plovdiv",
                CountryId = "b",  
                Country=country
            };
         
            country.Cities.Add(city);

            countryList.Add(country);


            var countries = await service.GetAllCountries();



            Assert.Equal(1, countries.Count);
        }





    }
}
