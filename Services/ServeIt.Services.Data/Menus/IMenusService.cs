using ServeIt.Web.ViewModels.Menu;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServeIt.Services.Data.Menus
{
    public interface IMenusService
    {
        Task<string> RestaurantMenu(string restaurantId);

        Task<string> AddMenu(string restaurantId);

        Task AddDish(AddDishInputModel model,string menuId);



        Task<ICollection<DishViewModel>> TakeAllDishes(string restaurantId);
        Task<ICollection<string>> TakeAllCategoriesByMenu(string restaurantId);

        Task <string> EditDish(string dishId,AddDishInputModel model);

        Task<AddDishInputModel> TakeDish(string dishId);

        Task <string> RemoveDish(string dishId);






    }
}
