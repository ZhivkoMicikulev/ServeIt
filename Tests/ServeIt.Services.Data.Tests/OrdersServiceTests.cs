using Moq;
using ServeIt.Data.Common.Repositories;
using ServeIt.Data.Models;
using ServeIt.Services.Data.Orders;
using ServeIt.Web.ViewModels.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ServeIt.Services.Data.Tests
{
   public class OrdersServiceTests
    {
        public static ICollection<DishOrder> dishOrderList;
        public static ICollection<Order> orderList;       
        public static ICollection<Restaurant> restaurantList;

        public static Mock<IDeletableEntityRepository<DishOrder>> mockDishOrderRepo;
        public static Mock<IDeletableEntityRepository<Order>> mockOrdersRepo;
        public static Mock<IDeletableEntityRepository<Restaurant>> mockRestaurantRepo;

        public static OrdersService service;



        public OrdersServiceTests()
        {
            dishOrderList = new List<DishOrder>();
            orderList = new List<Order>();
            restaurantList = new List<Restaurant>();

            mockDishOrderRepo = new Mock<IDeletableEntityRepository<DishOrder>>();
            mockDishOrderRepo.Setup(x => x.All()).Returns(dishOrderList.AsQueryable());
            mockDishOrderRepo.Setup(x => x.AddAsync(It.IsAny<DishOrder>()))
                .Callback((DishOrder d) => dishOrderList.Add(d));


            mockOrdersRepo = new Mock<IDeletableEntityRepository<Order>>();
            mockOrdersRepo.Setup(x => x.All()).Returns(orderList.AsQueryable());
            mockOrdersRepo.Setup(x => x.AddAsync(It.IsAny<Order>()))
                .Callback((Order c) => orderList.Add(c));

       

            mockRestaurantRepo = new Mock<IDeletableEntityRepository<Restaurant>>();
            mockRestaurantRepo.Setup(x => x.All()).Returns(restaurantList.AsQueryable());
            mockRestaurantRepo.Setup(x => x.AddAsync(It.IsAny<Restaurant>()))
                .Callback((Restaurant restaurant) => restaurantList.Add(restaurant));

            service = new OrdersService(
        mockDishOrderRepo.Object,
        mockRestaurantRepo.Object,
        mockOrdersRepo.Object
              );
        }

        [Fact]
        public async void TestAddDishShouldReturnCorrectCountOfDishRepo()
        {
            var user = new User
            {
                FirstName = "Pesho",
                LastName = "Gosho",
                Email = "k@abv.bg",
                PhoneNumber = "00000"
            };

            var dish = new DishOrder
            {

                   OwnerId = user.Id,
                   Id = "a",
                   RestaurantId="b"
            };
            var country = new Country {
                CountryName = "Bulgaria",
                Id = "b"
            };

            var city = new City {
                CityName = "Plovdiv",
                Country = country
            };
            var address = new Address
            {
                StreetName = "Vitinq",
                City = city
            };



            var restaurant = new Restaurant
            {
                Name = "Happy",
                Address = address,
                Id="b"


            };

            restaurantList.Add(restaurant);
            dishOrderList.Add(dish);

           var expectedResult = "Pesho Gosho";

            var result = (await service.GetAllInfoAboutOrder(user)).FullName;

            Assert.Equal(expectedResult, result);



        }

        [Fact]
        public async void TestFinishOrderShouldReturnCorrectCountOfOrders()
        {
            var user = new User
            {
                FirstName = "Pesho",
                LastName = "Gosho",
                Email = "k@abv.bg",
                PhoneNumber = "00000"
            };

         
            var country = new Country
            {
                CountryName = "Bulgaria",
                Id = "b"
            };

            var city = new City
            {
                CityName = "Plovdiv",
                Country = country
            };
            var address = new Address
            {
                StreetName = "Vitinq",
                City = city
            };



            var restaurant = new Restaurant
            {
                Name = "Happy",
                Address = address,
                Id = "b"


            };
            var dish = new DishOrder
            {

                OwnerId = user.Id,
                Id = "a",
                RestaurantId = "b",
                Restaurant=restaurant
            };
            restaurantList.Add(restaurant);
            dishOrderList.Add(dish);

            var model = new FinishOrderInputModel
            {
                StreetName = "Vitinq"
            };

            var expectedResult = 1;

            await service.FinishOrder(user.Id, model);
            var result = orderList.Count;

            Assert.Equal(expectedResult, result);



        }

        [Fact]
        public async void TestTakeAllOrdersShouldReturnTheCorrectCountOfOrders()
        {
            var user = new User
            {
                FirstName = "Pesho",
                LastName = "Gosho",
                Email = "k@abv.bg",
                PhoneNumber = "00000"
            };


            var country = new Country
            {
                CountryName = "Bulgaria",
                Id = "b"
            };

            var city = new City
            {
                CityName = "Plovdiv",
                Country = country
            };
            var address = new Address
            {
                StreetName = "Vitinq",
                City = city
            };



            var restaurant = new Restaurant
            {
                Name = "Happy",
                Address = address,
                Id = "b"


            };
            var dish = new DishOrder
            {

                OwnerId = user.Id,
                Id = "a",
                RestaurantId = "b",
                Restaurant = restaurant
            };

            var model = new FinishOrderInputModel
            {
                StreetName = "Vitinq"
            };


            restaurantList.Add(restaurant);
            dishOrderList.Add(dish);

            await service.FinishOrder(user.Id, model);
            orderList.First().User = user;
            var expectedResult = orderList.Count;

            var result = (await service.TakeAllOrders(restaurant.Id)).Count;

            Assert.Equal(expectedResult, result);
        }


        [Fact]
        public async void TestDoneOrderShouldReturnCorrect()
        {
            var user = new User
            {
                FirstName = "Pesho",
                LastName = "Gosho",
                Email = "k@abv.bg",
                PhoneNumber = "00000"
            };


            var country = new Country
            {
                CountryName = "Bulgaria",
                Id = "b"
            };

            var city = new City
            {
                CityName = "Plovdiv",
                Country = country
            };
            var address = new Address
            {
                StreetName = "Vitinq",
                City = city
            };



            var restaurant = new Restaurant
            {
                Name = "Happy",
                Address = address,
                Id = "b"


            };
            var dish = new DishOrder
            {

                OwnerId = user.Id,
                Id = "a",
                RestaurantId = "b",
                Restaurant = restaurant
            };

            var model = new FinishOrderInputModel
            {
                StreetName = "Vitinq"
            };


            restaurantList.Add(restaurant);
            dishOrderList.Add(dish);

            await service.FinishOrder(user.Id, model);
            orderList.First().User = user;
            var expectedResult = true;
            await service.DoneOrder(orderList.First().Id);

            var result=orderList.First().IsItPayed;
          

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async void TestRateOrderShouldReturnCorrect()
        {
            var user = new User
            {
                FirstName = "Pesho",
                LastName = "Gosho",
                Email = "k@abv.bg",
                PhoneNumber = "00000"
            };


            var country = new Country
            {
                CountryName = "Bulgaria",
                Id = "b"
            };

            var city = new City
            {
                CityName = "Plovdiv",
                Country = country
            };
            var address = new Address
            {
                StreetName = "Vitinq",
                City = city
            };



            var restaurant = new Restaurant
            {
                Name = "Happy",
                Address = address,
                Id = "b"


            };
            var dish = new DishOrder
            {

                OwnerId = user.Id,
                Id = "a",
                RestaurantId = "b",
                Restaurant = restaurant
            };

            var model = new FinishOrderInputModel
            {
                StreetName = "Vitinq"
            };


            restaurantList.Add(restaurant);
            dishOrderList.Add(dish);

            await service.FinishOrder(user.Id, model);
            orderList.First().User = user;
            await service.RateOrder(orderList.First().Id, 5);
            var expectedBoolResult = true;
            var expectedRate = 5;


            var resultBool = orderList.First().IsItRated;
            var resultRate = orderList.First().Rating;



            Assert.Equal(expectedBoolResult, resultBool);
            Assert.Equal(expectedRate, resultRate);

        }

        [Fact]
        public async void TestIsItPayedShouldReturnFalse()
        {
            var user = new User
            {
                FirstName = "Pesho",
                LastName = "Gosho",
                Email = "k@abv.bg",
                PhoneNumber = "00000"
            };


            var country = new Country
            {
                CountryName = "Bulgaria",
                Id = "b"
            };

            var city = new City
            {
                CityName = "Plovdiv",
                Country = country
            };
            var address = new Address
            {
                StreetName = "Vitinq",
                City = city
            };



            var restaurant = new Restaurant
            {
                Name = "Happy",
                Address = address,
                Id = "b"


            };
            var dish = new DishOrder
            {

                OwnerId = user.Id,
                Id = "a",
                RestaurantId = "b",
                Restaurant = restaurant
            };

            var model = new FinishOrderInputModel
            {
                StreetName = "Vitinq"
            };


            restaurantList.Add(restaurant);
            dishOrderList.Add(dish);

            await service.FinishOrder(user.Id, model);
            orderList.First().User = user;
            await service.RateOrder(orderList.First().Id, 5);
            var expectedBoolResult = false;
            


            var resultBool = orderList.First().IsItPayed;




            Assert.Equal(expectedBoolResult, resultBool);
      

        }
    }
}
