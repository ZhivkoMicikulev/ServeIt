using Moq;
using ServeIt.Data.Common.Repositories;
using ServeIt.Data.Models;
using ServeIt.Services.Data.Restaurants;
using ServeIt.Web.ViewModels.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ServeIt.Services.Data.Tests
{
    public class RestaurantsServiceTests
    {
        public static ICollection<Country> countryList;
        public static ICollection<City> cityList;
        public static ICollection<Address> addressesList;
        public static ICollection<Restaurant> restaurantsList;



        public static Mock<IDeletableEntityRepository<Country>> mockCountryRepo;
        public static Mock<IDeletableEntityRepository<City>> mockCityRepo;
        public static Mock<IRepository<Address>> mockAddressRepo;
        public static Mock<IDeletableEntityRepository<Restaurant>> mockRestaurantRepo;




        public static RestaurantsService service;



        public RestaurantsServiceTests()
        {
            countryList = new List<Country>();
            cityList = new List<City>();
            addressesList = new List<Address>();
            restaurantsList = new List<Restaurant>();



            mockCountryRepo = new Mock<IDeletableEntityRepository<Country>>();
            mockCountryRepo.Setup(x => x.All()).Returns(countryList.AsQueryable());
            mockCountryRepo.Setup(x => x.AddAsync(It.IsAny<Country>()))
                .Callback((Country c) => countryList.Add(c));

            mockCityRepo = new Mock<IDeletableEntityRepository<City>>();
            mockCityRepo.Setup(x => x.All()).Returns(cityList.AsQueryable());
            mockCityRepo.Setup(x => x.AddAsync(It.IsAny<City>()))
                .Callback((City c) => cityList.Add(c));

            mockAddressRepo = new Mock<IRepository<Address>>();
            mockAddressRepo.Setup(x => x.All()).Returns(addressesList.AsQueryable());
            mockAddressRepo.Setup(x => x.AddAsync(It.IsAny<Address>()))
                .Callback((Address a) => addressesList.Add(a));

            mockRestaurantRepo = new Mock<IDeletableEntityRepository<Restaurant>>();
            mockRestaurantRepo.Setup(x => x.All()).Returns(restaurantsList.AsQueryable());
            mockRestaurantRepo.Setup(x => x.AddAsync(It.IsAny<Restaurant>()))
                .Callback((Restaurant r) => restaurantsList.Add(r));

            service = new RestaurantsService(
             mockCountryRepo.Object,
             mockRestaurantRepo.Object,
             mockCityRepo.Object,
             mockAddressRepo.Object);
        }

        [Fact]
        public async void TestAddRestaurantShouldAddCorrectlyTHeGIvenRestaurant()
        {
            var model = new AddRestaurantInputModel
            {
                 CityId="p",
                  About="xa",
                    StreetName="Bivol",
                     Email="a@bv.bg",
                      Name="Happy",
                       Phone="00000"
            };

            var expectedResult = 1;

            service.AddRestaurant(model, "a");

            var result = restaurantsList.Count;

            Assert.Equal(expectedResult, result);


        }

        [Fact]
        public async void TestAreYouTheOwnerShouldReturnTrue()
        {
            var restaurant1 = new Restaurant
            {
                OwnerId="a",
                Id="b"
            };

            var restaurant2 = new Restaurant
            {
                OwnerId = "b",
                Id = "a"
            };

            restaurantsList.Add(restaurant1);
            restaurantsList.Add(restaurant2);

            var expectedResult = true;
            var result =await service.AreYouTheOwner("b", "a");

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async void TestAreYouTheOwnerShouldReturnFalse()
        {
            var restaurant1 = new Restaurant
            {
                OwnerId = "a",
                Id = "b"
            };

            var restaurant2 = new Restaurant
            {
                OwnerId = "b",
                Id = "a"
            };

            restaurantsList.Add(restaurant1);
            restaurantsList.Add(restaurant2);

            var expectedResult = false;
            var result = await service.AreYouTheOwner("a", "a");

            Assert.Equal(expectedResult, result);
        }



        [Fact]
        public async void TestEditRestaurantInfoShouldEditTheGivenInfoABoutTHeRestaurant()
        {
            var restaurant1 = new Restaurant
            {
                About="yes",
                Phone="00000",
                OwnerId = "a",
                Id = "b"
            };

            var restaurant2 = new Restaurant
            {
                OwnerId = "b",
                Id = "a"
            };

            restaurantsList.Add(restaurant1);
            restaurantsList.Add(restaurant2);

            var model = new AddRestaurantInputModel
            {
                 About="no",
                 Phone="11111",
                 CityId="a",
                  CountryId="b",
                   Email="a@abv.bg",
                    StreetName="bivol",
                     Name="Happy"

            };



            var expectedResultAbout = "no";
            var expectedResultPhone = "11111";

            await service.EditRestaurantInfo("b", model);

            var resultAbout = restaurantsList.Where(x => x.Id == "b").FirstOrDefault().About;
            var resultPhone = restaurantsList.Where(x => x.Id == "b").FirstOrDefault().Phone;


            Assert.Equal(expectedResultAbout, resultAbout);
            Assert.Equal(expectedResultPhone, resultPhone);

        }

        [Fact]
        public async void TestGetAllCountriesShouldReturnCorrectCount()
        {
            var country = new Country
            {
                Id="b",
                 CountryName="Bulgaria",
                 Cities=new List<City>()
            };

            var city = new City
            {
                CityName="Plovdiv"
            };

            country.Cities.Add(city);

            countryList.Add(country);

            var expectedResult = 1;
            var result = (await service.GetAllCountries()).Count;

            Assert.Equal(expectedResult, result);
        }


    }
}
