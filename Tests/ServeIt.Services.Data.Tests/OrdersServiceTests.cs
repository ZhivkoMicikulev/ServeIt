using Moq;
using ServeIt.Data.Common.Repositories;
using ServeIt.Data.Models;
using ServeIt.Services.Data.Orders;
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
        public void TestAddDishShouldReturnCorrectCountOfDishRepo()
        {


        }


    }
}
