using Microsoft.EntityFrameworkCore;
using ServeIt.Data.Common.Repositories;
using ServeIt.Data.Models;
using ServeIt.Services.Data.Orders;
using ServeIt.Web.ViewModels.Cart;
using ServeIt.Web.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServeIt.Services.Data
{
  public  class CartService : ICartService
    {
        private readonly IDeletableEntityRepository<DishOrder> dishOrderRepository;
        private readonly IDeletableEntityRepository<Dish> dishesRepository;
        private readonly IDeletableEntityRepository<Restaurant> restaurantRepository;
        private readonly IDeletableEntityRepository<Order> ordersRepository;

        public CartService(IDeletableEntityRepository<DishOrder> dishOrderRepository, 
            IDeletableEntityRepository<Dish> dishesRepository,
            IDeletableEntityRepository<Restaurant> restaurantRepository,
            IDeletableEntityRepository<Order> ordersRepository)
        {
            this.dishOrderRepository = dishOrderRepository;
            this.dishesRepository = dishesRepository;
            this.restaurantRepository = restaurantRepository;
            this.ordersRepository = ordersRepository;
        }


        public async Task AddToCart(string dishId, string userId,AddToCartInputModel model)
        {
            var dish = dishesRepository.All().FirstOrDefault(x => x.Id == dishId);

            var dishOrder = new DishOrder
            {
                OwnerId = userId,
                DishId = dish.Id,
                Quantity = model.Quantity,
                Amount = model.Quantity * dish.Price,
                Status=false,
                RestaurantId=model.RestaurantId

            };

            await dishOrderRepository.AddAsync(dishOrder);
            await dishOrderRepository.SaveChangesAsync();

        }

        public async Task FinishOrder(string userId, FinishOrderInputModel model)
        {
            var orderList = new List<Order>();
            var items = this.dishOrderRepository.All().Where(x => x.OwnerId == userId && x.Status==false)
                .Include(x=>x.Restaurant)
                .Include(x=>x.Restaurant.Address)
                .ToArray();

            foreach (var item in items)
            {
                if (!orderList.Any(x=>x.restaurantId==item.RestaurantId))
                {
                    var newOrder = new Order
                    {
                        restaurantId = item.RestaurantId,
                        CityId = item.Restaurant.Address.CityId,
                        StreetName = model.StreetName,
                        TotalAmount = 0,
                        UserId=userId,
                        IsItPayed=false,

                    };

                    orderList.Add(newOrder);
                }

                var order = orderList.Where(x => x.restaurantId == item.RestaurantId).FirstOrDefault();
                order.TotalAmount += item.Amount;
                item.Status = true;
                order.DishOrders.Add(item);
            }

            foreach (var order in orderList)
            {
              await  this.ordersRepository.AddAsync(order);
            }

            await this.ordersRepository.SaveChangesAsync();

        }

        public async Task<FinishOrderViewModel> GetAllInfoAboutOrder(User user)
        {
            var items = this.dishOrderRepository.All().Where(x => x.OwnerId == user.Id && x.Status == false).ToArray();

            var model = new FinishOrderViewModel
            {
                FullName = user.FirstName + " " + user.LastName,
                Email = user.Email,
                Phone = user.PhoneNumber,
                TotalAmount = items.Sum(x => x.Amount),
            };

            foreach (var item in items )
            {
                var restaurant = restaurantRepository.All()
                    .Where(x => x.Id == item.RestaurantId)
                    .Include(x=>x.Address)
                    .Include(x=>x.Address.City)
                    .Include(x=>x.Address.City.Country)
                    .FirstOrDefault();
                var address = restaurant.Address.City.Country.CountryName + ", " + restaurant.Address.City.CityName + ", " + restaurant.Address.StreetName;
                if (!model.Restaurants.Any(x => x.Name == restaurant.Name))
                {
                    var newRestaurant = new FinishOrderRestaurantViewModel
                    {
                        Name = restaurant.Name,
                        Address = address,
                    };
                    model.Restaurants.Add(newRestaurant);
                }

            }

            return model;

        }

        public async Task<CartItemsViewModel> GetAllItemsForOrder(string userId)
        {
            var result = new CartItemsViewModel();

            var disheOrders = dishOrderRepository.All().Where(x => x.OwnerId == userId && x.Status == false)
                .ToArray();

            foreach (var dish in disheOrders)
            {
                var restaurantName = restaurantRepository.All().Where(x => x.Id == dish.RestaurantId).Select(x => x.Name).FirstOrDefault();
                var dishName=dishesRepository.All().Where(x => x.Id == dish.DishId).Select(x => x.Name).FirstOrDefault();
                if (!result.Restaurants.Any(x=>x.RestaurantName==restaurantName))
                {
                    var restaurant = new RestaurantOrders
                    {
                        RestaurantName=restaurantName,
                        TotalAmount=0,


                    };
                    result.Restaurants.Add(restaurant);
                }
                var item = new CartItems
                {
                    Name = dishName,
                    Amount = dish.Amount,
                    Quantity = dish.Quantity,
                    Id = dish.Id
                };
              var currentRestaurant = result.Restaurants.Where(x => x.RestaurantName == restaurantName)
                    .FirstOrDefault();
                currentRestaurant.Dishes.Add(item);

                currentRestaurant.TotalAmount += dish.Amount;

                result.TotalAmount+= dish.Amount; ;

            }


            return result;
        }

        public async Task RemoveItemFromCart(string itemId)
        {
            var itemToRemove = this.dishOrderRepository.All().Where(x => x.Id == itemId).FirstOrDefault();

            this.dishOrderRepository.Delete(itemToRemove);
            await this.dishOrderRepository.SaveChangesAsync();
        }
    }
}
