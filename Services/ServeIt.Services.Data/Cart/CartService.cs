namespace ServeIt.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using ServeIt.Data.Common.Repositories;
    using ServeIt.Data.Models;
    using ServeIt.Services.Data.Orders;
    using ServeIt.Web.ViewModels.Cart;
    using ServeIt.Web.ViewModels.Orders;

    public class CartService : ICartService
    {
        private readonly IDeletableEntityRepository<DishOrder> dishOrderRepository;
        private readonly IDeletableEntityRepository<Dish> dishesRepository;
        private readonly IDeletableEntityRepository<Restaurant> restaurantRepository;

        public CartService(
            IDeletableEntityRepository<DishOrder> dishOrderRepository,
            IDeletableEntityRepository<Dish> dishesRepository,
            IDeletableEntityRepository<Restaurant> restaurantRepository)
        {
            this.dishOrderRepository = dishOrderRepository;
            this.dishesRepository = dishesRepository;
            this.restaurantRepository = restaurantRepository;
        }

        public async Task<CartItemsViewModel> GetAllItemsForOrder(string userId)
        {
            var result = new CartItemsViewModel();

            var disheOrders = this.dishOrderRepository.All().Where(x => x.OwnerId == userId && x.Status == false)
                .ToArray();

            foreach (var dish in disheOrders)
            {
                var restaurantName = this.restaurantRepository.All().Where(x => x.Id == dish.RestaurantId).Select(x => x.Name).FirstOrDefault();
                var dishName = this.dishesRepository.All().Where(x => x.Id == dish.DishId).Select(x => x.Name).FirstOrDefault();
                if (!result.Restaurants.Any(x => x.RestaurantName == restaurantName))
                {
                    var restaurant = new RestaurantOrders
                    {
                        RestaurantName = restaurantName,
                        TotalAmount = 0,
                    };
                    result.Restaurants.Add(restaurant);
                }

                var item = new CartItems
                {
                    Name = dishName,
                    Amount = dish.Amount,
                    Quantity = dish.Quantity,
                    Id = dish.Id,
                };
                var currentRestaurant = result.Restaurants.Where(x => x.RestaurantName == restaurantName)
                      .FirstOrDefault();
                currentRestaurant.Dishes.Add(item);

                currentRestaurant.TotalAmount += dish.Amount;

                result.TotalAmount += dish.Amount;
            }

            return result;
        }

        public async Task AddToCart(string dishId, string userId, AddToCartInputModel model)
        {
            var dish = this.dishesRepository.All().FirstOrDefault(x => x.Id == dishId);

            var dishOrder = new DishOrder
            {
                OwnerId = userId,
                DishId = dish.Id,
                Quantity = model.Quantity,
                Amount = model.Quantity * dish.Price,
                Status = false,
                RestaurantId = model.RestaurantId,
            };

            await this.dishOrderRepository.AddAsync(dishOrder);
            await this.dishOrderRepository.SaveChangesAsync();
        }

        public async Task RemoveItemFromCart(string itemId)
        {
            var itemToRemove = this.dishOrderRepository.All().Where(x => x.Id == itemId).FirstOrDefault();

            this.dishOrderRepository.Delete(itemToRemove);
            await this.dishOrderRepository.SaveChangesAsync();
        }
    }
}
