using Moq;
using ServeIt.Data.Common.Repositories;
using ServeIt.Data.Models;
using ServeIt.Web.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ServeIt.Services.Data.Tests
{
    public class CartServiceTests
    {
        [Fact]
        public async void TestGetAllItemsMethodShouldReturnCorrectTotal()
        {
            var dishOrderList = new List<DishOrder>();
            var dishList = new List<Dish>();       
            var restaurantList = new List<Restaurant>();

            var mockDishOrderRepo = new Mock<IDeletableEntityRepository<DishOrder>>();
            mockDishOrderRepo.Setup(x => x.All()).Returns(dishOrderList.AsQueryable());
            mockDishOrderRepo.Setup(x => x.AddAsync(It.IsAny<DishOrder>()))
                .Callback((DishOrder dishOrder) => dishOrderList.Add(dishOrder));

            var mockDishRepo = new Mock<IDeletableEntityRepository<Dish>>();
            mockDishRepo.Setup(x => x.All()).Returns(dishList.AsQueryable());
            mockDishRepo.Setup(x => x.AddAsync(It.IsAny<Dish>()))
                .Callback((Dish dish) => dishList.Add(dish));

            var mockRestaurantRepo = new Mock<IDeletableEntityRepository<Restaurant>>();
            mockRestaurantRepo.Setup(x => x.All()).Returns(restaurantList.AsQueryable());
            mockRestaurantRepo.Setup(x => x.AddAsync(It.IsAny<Restaurant>()))
                .Callback((Restaurant restaurant) => restaurantList.Add(restaurant));


            var service = new CartService(
                mockDishOrderRepo.Object,
                mockDishRepo.Object,
                mockRestaurantRepo.Object);

            var dish = new Dish
            {
                Name="Banica",
                Price=1,
                MenuId="a",
                Ingredients="asdas",
            };

            var restaurant = new Restaurant
            {
                Name = "Happy",
                AddressId = "a",
                OwnerId = "a",
                MenuId = dish.MenuId,

            };

            var dishorder = new DishOrder
            {
                OwnerId = "a",
                RestaurantId = restaurant.Id,
                Amount = dish.Price,

            };

            dishOrderList.Add(dishorder);
            restaurantList.Add(restaurant);
            dishList.Add(dish);

            var items = await service.GetAllItemsForOrder("a");

           
            Assert.Equal(1, items.TotalAmount);
        }

        [Fact]
        public async void TestGetAllItemsMethodShouldReturnCorrectRestaurantsCount()
        {
            var dishOrderList = new List<DishOrder>();
            var dishList = new List<Dish>();
            var restaurantList = new List<Restaurant>();

            var mockDishOrderRepo = new Mock<IDeletableEntityRepository<DishOrder>>();
            mockDishOrderRepo.Setup(x => x.All()).Returns(dishOrderList.AsQueryable());
            mockDishOrderRepo.Setup(x => x.AddAsync(It.IsAny<DishOrder>()))
                .Callback((DishOrder dishOrder) => dishOrderList.Add(dishOrder));

            var mockDishRepo = new Mock<IDeletableEntityRepository<Dish>>();
            mockDishRepo.Setup(x => x.All()).Returns(dishList.AsQueryable());
            mockDishRepo.Setup(x => x.AddAsync(It.IsAny<Dish>()))
                .Callback((Dish dish) => dishList.Add(dish));

            var mockRestaurantRepo = new Mock<IDeletableEntityRepository<Restaurant>>();
            mockRestaurantRepo.Setup(x => x.All()).Returns(restaurantList.AsQueryable());
            mockRestaurantRepo.Setup(x => x.AddAsync(It.IsAny<Restaurant>()))
                .Callback((Restaurant restaurant) => restaurantList.Add(restaurant));


            var service = new CartService(
                mockDishOrderRepo.Object,
                mockDishRepo.Object,
                mockRestaurantRepo.Object);

            var dish = new Dish
            {
                Name = "Banica",
                Price = 1,
                MenuId = "a",
                Ingredients = "asdas",
            };

            var restaurant = new Restaurant
            {
                Name = "Happy",
                AddressId = "a",
                OwnerId = "a",
                MenuId = dish.MenuId,

            };

            var dishorder = new DishOrder
            {
                OwnerId = "a",
                RestaurantId = restaurant.Id,
                Amount = dish.Price,

            };

            dishOrderList.Add(dishorder);
            restaurantList.Add(restaurant);
            dishList.Add(dish);

            var items = await service.GetAllItemsForOrder("a");

            Assert.Equal(1, items.Restaurants.Count);
        }

        [Fact]
        public async void TestGetAllItemsMethodShouldReturnCorrectRestaurantsName()
        {
            var dishOrderList = new List<DishOrder>();
            var dishList = new List<Dish>();
            var restaurantList = new List<Restaurant>();

            var mockDishOrderRepo = new Mock<IDeletableEntityRepository<DishOrder>>();
            mockDishOrderRepo.Setup(x => x.All()).Returns(dishOrderList.AsQueryable());
            mockDishOrderRepo.Setup(x => x.AddAsync(It.IsAny<DishOrder>()))
                .Callback((DishOrder dishOrder) => dishOrderList.Add(dishOrder));

            var mockDishRepo = new Mock<IDeletableEntityRepository<Dish>>();
            mockDishRepo.Setup(x => x.All()).Returns(dishList.AsQueryable());
            mockDishRepo.Setup(x => x.AddAsync(It.IsAny<Dish>()))
                .Callback((Dish dish) => dishList.Add(dish));

            var mockRestaurantRepo = new Mock<IDeletableEntityRepository<Restaurant>>();
            mockRestaurantRepo.Setup(x => x.All()).Returns(restaurantList.AsQueryable());
            mockRestaurantRepo.Setup(x => x.AddAsync(It.IsAny<Restaurant>()))
                .Callback((Restaurant restaurant) => restaurantList.Add(restaurant));


            var service = new CartService(
                mockDishOrderRepo.Object,
                mockDishRepo.Object,
                mockRestaurantRepo.Object);

            var dish = new Dish
            {
                Name = "Banica",
                Price = 1,
                MenuId = "a",
                Ingredients = "asdas",
            };

            var restaurant = new Restaurant
            {
                Name = "Happy",
                AddressId = "a",
                OwnerId = "a",
                MenuId = dish.MenuId,

            };

            var dishorder = new DishOrder
            {
                OwnerId = "a",
                RestaurantId = restaurant.Id,
                Amount = dish.Price,

            };

            dishOrderList.Add(dishorder);
            restaurantList.Add(restaurant);
            dishList.Add(dish);

            var items = await service.GetAllItemsForOrder("a");

            Assert.Equal(true, items.Restaurants.Any(x=>x.RestaurantName=="Happy"));
        }


        [Fact]
        public async void TestAddToCartShouldReturnCorrectCount()
        {
            var dishOrderList = new List<DishOrder>();
            var dishList = new List<Dish>();
            var restaurantList = new List<Restaurant>();

            var mockDishOrderRepo = new Mock<IDeletableEntityRepository<DishOrder>>();
            mockDishOrderRepo.Setup(x => x.All()).Returns(dishOrderList.AsQueryable());
            mockDishOrderRepo.Setup(x => x.AddAsync(It.IsAny<DishOrder>()))
                .Callback((DishOrder dishOrder) => dishOrderList.Add(dishOrder));

            var mockDishRepo = new Mock<IDeletableEntityRepository<Dish>>();
            mockDishRepo.Setup(x => x.All()).Returns(dishList.AsQueryable());
            mockDishRepo.Setup(x => x.AddAsync(It.IsAny<Dish>()))
                .Callback((Dish dish) => dishList.Add(dish));

            var mockRestaurantRepo = new Mock<IDeletableEntityRepository<Restaurant>>();
            mockRestaurantRepo.Setup(x => x.All()).Returns(restaurantList.AsQueryable());
            mockRestaurantRepo.Setup(x => x.AddAsync(It.IsAny<Restaurant>()))
                .Callback((Restaurant restaurant) => restaurantList.Add(restaurant));


            var service = new CartService(
                mockDishOrderRepo.Object,
                mockDishRepo.Object,
                mockRestaurantRepo.Object);

            var model = new AddToCartInputModel
            {
                Quantity = 1,
                RestaurantId = "a"

            };

            var dish = new Dish
            {
                Name = "Banica",
                Price = 1,
                MenuId = "a",
                Ingredients = "asdas",
            };

           
            dishList.Add(dish);

            await service.AddToCart(dish.Id, "a", model);

            Assert.Equal(1, dishOrderList.Count);
        }


        [Fact]
        public async void TestAddToCartShouldReturnCorrectDishOrder()
        {
            var dishOrderList = new List<DishOrder>();
            var dishList = new List<Dish>();
            var restaurantList = new List<Restaurant>();

            var mockDishOrderRepo = new Mock<IDeletableEntityRepository<DishOrder>>();
            mockDishOrderRepo.Setup(x => x.All()).Returns(dishOrderList.AsQueryable());
            mockDishOrderRepo.Setup(x => x.AddAsync(It.IsAny<DishOrder>()))
                .Callback((DishOrder dishOrder) => dishOrderList.Add(dishOrder));

            var mockDishRepo = new Mock<IDeletableEntityRepository<Dish>>();
            mockDishRepo.Setup(x => x.All()).Returns(dishList.AsQueryable());
            mockDishRepo.Setup(x => x.AddAsync(It.IsAny<Dish>()))
                .Callback((Dish dish) => dishList.Add(dish));

            var mockRestaurantRepo = new Mock<IDeletableEntityRepository<Restaurant>>();
            mockRestaurantRepo.Setup(x => x.All()).Returns(restaurantList.AsQueryable());
            mockRestaurantRepo.Setup(x => x.AddAsync(It.IsAny<Restaurant>()))
                .Callback((Restaurant restaurant) => restaurantList.Add(restaurant));


            var service = new CartService(
                mockDishOrderRepo.Object,
                mockDishRepo.Object,
                mockRestaurantRepo.Object);

            var model = new AddToCartInputModel
            {
                Quantity = 1,
                RestaurantId = "a"

            };

            var dish = new Dish
            {
                Name = "Banica",
                Price = 1,
                MenuId = "a",
                Ingredients = "asdas",
            };


            dishList.Add(dish);

            await service.AddToCart(dish.Id, "a", model);

            Assert.Equal(true, dishOrderList.Any(x=>x.OwnerId=="a" && x.DishId==dish.Id));
        }


        [Fact]
        public async void TestRemoveItemsFromCartShouldRemoveTheCorrectItem()
        {
            var dishOrderList = new List<DishOrder>();
            var dishList = new List<Dish>();
            var restaurantList = new List<Restaurant>();

            var mockDishOrderRepo = new Mock<IDeletableEntityRepository<DishOrder>>();
            mockDishOrderRepo.Setup(x => x.All()).Returns(dishOrderList.AsQueryable());
            mockDishOrderRepo.Setup(x => x.AddAsync(It.IsAny<DishOrder>()))
                .Callback((DishOrder dishOrder) => dishOrderList.Add(dishOrder));
            mockDishOrderRepo.Setup(x => x.Delete(It.IsAny<DishOrder>()))
               .Callback((DishOrder dishOrder) => dishOrderList.Remove(dishOrder));
            var mockDishRepo = new Mock<IDeletableEntityRepository<Dish>>();
            mockDishRepo.Setup(x => x.All()).Returns(dishList.AsQueryable());
            mockDishRepo.Setup(x => x.AddAsync(It.IsAny<Dish>()))
                .Callback((Dish dish) => dishList.Add(dish));

            var mockRestaurantRepo = new Mock<IDeletableEntityRepository<Restaurant>>();
            mockRestaurantRepo.Setup(x => x.All()).Returns(restaurantList.AsQueryable());
            mockRestaurantRepo.Setup(x => x.AddAsync(It.IsAny<Restaurant>()))
                .Callback((Restaurant restaurant) => restaurantList.Add(restaurant));


            var service = new CartService(
                mockDishOrderRepo.Object,
                mockDishRepo.Object,
                mockRestaurantRepo.Object);


            var dishorder = new DishOrder
            {
                OwnerId = "a",
                RestaurantId = "a",
                Amount = 1,

            };
            var dishorder2 = new DishOrder
            {
                OwnerId = "b",
                RestaurantId = "b",
                Amount = 1,

            };

            dishOrderList.Add(dishorder);
            dishOrderList.Add(dishorder2);



            await service.RemoveItemFromCart(dishorder2.Id);

            Assert.Equal(1, dishOrderList.Count());
        }

    }
}
