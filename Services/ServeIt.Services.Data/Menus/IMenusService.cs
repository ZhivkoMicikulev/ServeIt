namespace ServeIt.Services.Data.Menus
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ServeIt.Web.ViewModels.Menu;

    public interface IMenusService
    {
        Task<string> RestaurantMenu(string restaurantId);

        Task<string> AddMenu(string restaurantId);

        Task AddDish(AddDishInputModel model,string menuId);

        Task<ICollection<DishViewModel>> TakeAllDishes(string restaurantId);

        Task<ICollection<string>> TakeAllCategoriesByMenu(string restaurantId);

        Task<string> EditDish(string dishId,AddDishInputModel model);

        Task<AddDishInputModel> TakeDish(string dishId);

        Task<string> RemoveDish(string dishId);
    }
}
