namespace ServeIt.Services.Data.Orders
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using ServeIt.Data.Common.Repositories;
    using ServeIt.Data.Models;
    using ServeIt.Web.ViewModels.Cart;
    using ServeIt.Web.ViewModels.Orders;

    public class OrdersService : IOrdersService
    {
        private readonly IDeletableEntityRepository<DishOrder> dishOrderRepository;
    
        private readonly IDeletableEntityRepository<Restaurant> restaurantRepository;
        private readonly IDeletableEntityRepository<Order> ordersRepository;

        public OrdersService(
            IDeletableEntityRepository<DishOrder> dishOrderRepository,       
            IDeletableEntityRepository<Restaurant> restaurantRepository,
            IDeletableEntityRepository<Order> ordersRepository)
        {
            this.dishOrderRepository = dishOrderRepository;
            this.restaurantRepository = restaurantRepository;
            this.ordersRepository = ordersRepository;
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

            foreach (var item in items)
            {
                var restaurant = this.restaurantRepository.All()
                    .Where(x => x.Id == item.RestaurantId)
                    .Include(x => x.Address)
                    .Include(x => x.Address.City)
                    .Include(x => x.Address.City.Country)
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

        public async Task FinishOrder(string userId, FinishOrderInputModel model)
        {
            var orderList = new List<Order>();
            var items = this.dishOrderRepository.All().Where(x => x.OwnerId == userId && x.Status == false)
                .Include(x => x.Restaurant)
                .Include(x => x.Restaurant.Address)
                .ToArray();

            foreach (var item in items)
            {
                if (!orderList.Any(x => x.RestaurantId == item.RestaurantId))
                {
                    var newOrder = new Order
                    {
                        RestaurantId = item.RestaurantId,
                        CityId = item.Restaurant.Address.CityId,
                        StreetName = model.StreetName,
                        TotalAmount = 0,
                        UserId = userId,
                        IsItPayed = false,
                        IsItRated = false,
                    };

                    orderList.Add(newOrder);
                }

                var order = orderList.Where(x => x.RestaurantId == item.RestaurantId).FirstOrDefault();
                order.TotalAmount += item.Amount;
                item.Status = true;
                order.DishOrders.Add(item);
            }

            foreach (var order in orderList)
            {
                await this.ordersRepository.AddAsync(order);
            }

            await this.ordersRepository.SaveChangesAsync();
        }

        public async Task<ICollection<OrdersViewModel>> TakeAllOrders(string restaurantId)
        {
            var orders = this.ordersRepository.All()
                .Where(x => x.RestaurantId == restaurantId)
                .Include(x => x.User)
                .OrderByDescending(x => x.CreatedOn)
                .Select(
                x => new OrdersViewModel
                {
                    OrderId = x.Id,
                    Street = x.StreetName,
                    Date = x.CreatedOn.ToShortDateString(),
                    Hour = x.CreatedOn.ToShortTimeString(),
                    FullName = x.User.FirstName + " " + x.User.LastName,
                    IsItPayed = x.IsItPayed,
                    Amount = x.TotalAmount,
                    Phone = x.User.PhoneNumber,
                    Email = x.User.Email,
                })
                .ToList();

            return orders;
        }

        public async Task<ICollection<ItemsViewModel>> TakeAllItemsFromOrder(string orderId)
        {
            var order = this.ordersRepository.All().Where(x => x.Id == orderId)
                .Include(x => x.DishOrders)
                .ThenInclude(x => x.Dish)
                .FirstOrDefault();

            var items = order.DishOrders
                .Select(x => new ItemsViewModel
                {
                    Name = x.Dish.Name,
                    Quantity = x.Quantity,
                }).OrderBy(x => x.Name).ToList();

            return items;
        }

        public async Task<string> DoneOrder(string orderId)
        {
            var order = this.ordersRepository.All().Where(x => x.Id == orderId).FirstOrDefault();

            var restaurantId = order.RestaurantId;

            order.IsItPayed = true;

            await this.ordersRepository.SaveChangesAsync();

            return restaurantId;
        }

        public async Task<ICollection<MyOrdersViewModel>> TakeAllMyOrders(string id)
        {

            return await this.ordersRepository.All().Where(x => x.UserId == id)
                .Include(x => x.Restaurant)
                .OrderByDescending(x => x.CreatedOn)
                .Select(x => new MyOrdersViewModel
                {
                    OrderId = x.Id,
                    Price = x.TotalAmount,
                    RestaurantName = x.Restaurant.Name,
                    Date = x.CreatedOn.ToString("dd/MM/yyyy"),
                    IsItRated = x.IsItRated,
                    Rating = x.Rating,
                }).ToListAsync();
        }

        public async Task RateOrder(string id, int rate)
        {
            var order = this.ordersRepository.All().Where(x => x.Id == id)
                 .FirstOrDefault();

            order.Rating = rate;
            order.IsItRated = true;

            await this.ordersRepository.SaveChangesAsync();
        }

        public async Task<bool> IsTheOrderPayed(string id)
        {
            var order = this.ordersRepository.All().Where(x => x.Id == id)
                  .FirstOrDefault();

            return order.IsItPayed;
        }
    }
}
