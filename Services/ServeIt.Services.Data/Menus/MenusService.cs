using ServeIt.Data.Common.Repositories;
using ServeIt.Data.Models;
using ServeIt.Services.Data.Helper;
using ServeIt.Web.ViewModels.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServeIt.Services.Data.Menus
{
    public class MenusService : IMenusService
    {
        private readonly IDeletableEntityRepository<Restaurant> restaurantRepository;
        private readonly IDeletableEntityRepository<Menu> menuRepository;
        private readonly IDeletableEntityRepository<FoodStyle> foodStylesRepository;
       
        private readonly IDeletableEntityRepository<Dish> dishesRepostory;
        private readonly IDeletableEntityRepository<Category> categoriesRepository;
      
        private readonly IHelperService helperService;

        public MenusService(IDeletableEntityRepository<Restaurant> restaurantRepository,
            IDeletableEntityRepository<Menu> menuRepository,
            IDeletableEntityRepository<FoodStyle> foodStylesRepository,
            IDeletableEntityRepository<Dish> dishesRepostory,
            IDeletableEntityRepository<Category> CategoriesRepository,
            IHelperService helperService

            )
        {
            this.restaurantRepository = restaurantRepository;
            this.menuRepository = menuRepository;
            this.foodStylesRepository = foodStylesRepository;
            this.dishesRepostory = dishesRepostory;
            this.categoriesRepository = CategoriesRepository;
            this.helperService = helperService;
        }

        public async Task AddDish(AddDishInputModel model,string menuId)
        {

            var menu = this.menuRepository.All().Where(x => x.Id == menuId).FirstOrDefault();
            var foodStyle = foodStylesRepository.All().FirstOrDefault(x => x.Name == model.FoodStyle.ToLower());

            var category = categoriesRepository.All().FirstOrDefault(x => x.Name == model.CategoryName.ToLower());


       

         
            var dish = new Dish
            {
                Name = model.Name,
                Price = model.Price,
                MenuId=menuId,
                Ingredients=model.Ingredients,
                Category = category != null ? category : new Category { Name = model.CategoryName.ToLower() },
            };

          



            await this.dishesRepostory.AddAsync(dish);
       

            await this.dishesRepostory.AddAsync(dish);
            await this.dishesRepostory.SaveChangesAsync();
           

        
         
            
         
          
         
          

        }

        public async Task<string> AddMenu(string restaurantId)
        {
            var menu = new Menu();

            var restaurant = this.restaurantRepository.All().Where(x => x.Id == restaurantId).FirstOrDefault();
          

            restaurant.MenuId = menu.Id;

            await this.menuRepository.AddAsync(menu);
            await this.menuRepository.SaveChangesAsync();
            await   this.restaurantRepository.SaveChangesAsync();

            return  menu.Id;

        }

     

        public async Task<string> EditDish(string dishId, AddDishInputModel model)
        {
            var dish = this.dishesRepostory.All().Where(x => x.Id == dishId).FirstOrDefault();
      
            var category = categoriesRepository.All().FirstOrDefault(x => x.Name == model.CategoryName.ToLower());
            dish.Name = model.Name;
            dish.Price = model.Price;
            dish.Ingredients = model.Ingredients;
            dish.Category = category != null ? category : new Category
            {
                Name = model.CategoryName.ToLower()
                
            };

            var menuId = dish.MenuId;

            var restaurantId = this.restaurantRepository.All().Where(x => x.MenuId == menuId).Select(x => x.Id).FirstOrDefault();
          

          

         await   this.dishesRepostory.SaveChangesAsync();

            

            return restaurantId;

        }

        public async Task<string> RemoveDish(string dishId)
        {
            var dish = this.dishesRepostory.All().Where(x => x.Id == dishId).FirstOrDefault();

            this.dishesRepostory.Delete(dish);
            await this.dishesRepostory.SaveChangesAsync();
            var restaurantId = this.restaurantRepository.All().Where(x => x.MenuId == dish.MenuId).Select(x => x.Id).FirstOrDefault();

            return restaurantId;
        }

        public async Task<string> RestaurantMenu(string restaurantId)
        {
            var menuId = restaurantRepository.All().Where(x => x.Id == restaurantId).Select(x=>x.MenuId).FirstOrDefault();
           
            return menuId;
        }


        public async Task<ICollection<string>> TakeAllCategoriesByMenu(string menuId)
        {
            var categories = this.dishesRepostory.All().Where(x => x.MenuId == menuId)
                 .Select(x => helperService.MakeFirstLetterCapital(x.Category.Name)).Distinct().ToList();





            return categories;
        }

        public async Task<ICollection<DishViewModel>> TakeAllDishes(string menuId)
        {


            var menu = this.dishesRepostory.All().Where(x => x.MenuId == menuId)
                .Select(x => new DishViewModel
                {
                    Name = helperService.MakeFirstLetterCapital(x.Name),
                    Price = x.Price,
                    Id = x.Id,
                    CategoryName =helperService.MakeFirstLetterCapital(x.Category.Name),
                    Ingredients =x.Ingredients,
                }).ToList();
           

            return menu;
        }

        public async Task<AddDishInputModel> TakeDish(string dishId)
        {
            var dish = this.dishesRepostory.All().Where(x => x.Id == dishId)
 .Select(x => new AddDishInputModel
 {
     Name = x.Name,
     Price = x.Price,
     CategoryName = x.Category.Name,
     Ingredients = x.Ingredients,
 }).FirstOrDefault();
            return dish;
        }

      
    }
}
