using Moq;
using ServeIt.Data.Common.Repositories;
using ServeIt.Data.Models;
using ServeIt.Services.Data.Helper;
using ServeIt.Services.Data.Menus;
using ServeIt.Web.ViewModels.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ServeIt.Services.Data.Tests
{
   public class MenuesServiceTests
    {
        public static ICollection<Dish> dishList;
        public static ICollection<Category> categoryList;
        public static ICollection<Menu> menuList;
        public static ICollection<FoodStyle> foodStylesList;
        public static ICollection<Restaurant> restaurantList;
        public static MenusService service;

        public static Mock<IDeletableEntityRepository<Dish>> mockDishRepo;
        public static Mock<IDeletableEntityRepository<Category>> mockCategoryRepo;
        public static Mock<IDeletableEntityRepository<FoodStyle>> mockFoodStylesRepo;
        public static Mock<IDeletableEntityRepository<Menu>> mockMenuRepo;
        public static Mock<IDeletableEntityRepository<Restaurant>> mockRestaurantRepo;

        


        public MenuesServiceTests()
        {
             dishList = new List<Dish>();
             categoryList = new List<Category>();
             menuList = new List<Menu>();
             foodStylesList = new List<FoodStyle>();
             restaurantList = new List<Restaurant>();

             mockDishRepo = new Mock<IDeletableEntityRepository<Dish>>();
            mockDishRepo.Setup(x => x.All()).Returns(dishList.AsQueryable());
            mockDishRepo.Setup(x => x.AddAsync(It.IsAny<Dish>()))
                .Callback((Dish d) => dishList.Add(d));
            mockDishRepo.Setup(x => x.Delete(It.IsAny<Dish>()))
               .Callback((Dish d) => dishList.Remove(d));

            mockCategoryRepo = new Mock<IDeletableEntityRepository<Category>>();
            mockCategoryRepo.Setup(x => x.All()).Returns(categoryList.AsQueryable());
            mockCategoryRepo.Setup(x => x.AddAsync(It.IsAny<Category>()))
                .Callback((Category c) => categoryList.Add(c));

            mockFoodStylesRepo = new Mock<IDeletableEntityRepository<FoodStyle>>();
            mockFoodStylesRepo.Setup(x => x.All()).Returns(foodStylesList.AsQueryable());
            mockFoodStylesRepo.Setup(x => x.AddAsync(It.IsAny<FoodStyle>()))
                .Callback((FoodStyle fs) => foodStylesList.Add(fs));

            mockMenuRepo = new Mock<IDeletableEntityRepository<Menu>>();
            mockMenuRepo.Setup(x => x.All()).Returns(menuList.AsQueryable());
            mockMenuRepo.Setup(x => x.AddAsync(It.IsAny<Menu>()))
                .Callback((Menu m) => menuList.Add(m));

            mockRestaurantRepo = new Mock<IDeletableEntityRepository<Restaurant>>();
            mockRestaurantRepo.Setup(x => x.All()).Returns(restaurantList.AsQueryable());
            mockRestaurantRepo.Setup(x => x.AddAsync(It.IsAny<Restaurant>()))
                .Callback((Restaurant restaurant) => restaurantList.Add(restaurant));
            var helperService = new HelperService();

            service = new MenusService(
        mockRestaurantRepo.Object,
        mockMenuRepo.Object,
        mockFoodStylesRepo.Object,
        mockDishRepo.Object,
        mockCategoryRepo.Object,
        helperService
              );
        }

        [Fact]
        public void TestAddDishShouldReturnCorrectCountOfDishRepo()
        {
    

            var dish = new AddDishInputModel
            {
                CategoryName = "bread",
                Ingredients = "ad",
                 Name="Banica",
                 FoodStyle="bulgarian",
                  Price=1   
            };


            service.AddDish(dish, "a");

            Assert.Equal(1, dishList.Count);
        }

        [Fact]
        public void TestAddDishShouldAddTheCorrectDish()
        {
  
       

            var dish = new AddDishInputModel
            {
                CategoryName = "bread",
                Ingredients = "ad",
                Name = "Banica",
                FoodStyle = "bulgarian",
                Price = 1
            };


            service.AddDish(dish, "a");

            Assert.Equal(true, dishList.Any(x=>x.Name==dish.Name));
        }

        [Fact]
        public void TestAddMenuShouldReturnThecorectCountOfMenues()
        {



            var restaurant = new Restaurant
            {
                Name="Happy",
                Id="a",
                 AddressId="a",
                  Email="a",
                  Phone="00",

            };

            restaurantList.Add(restaurant);

            service.AddMenu("a");

            Assert.Equal(1, menuList.Count);
        }

        [Fact]
        public async void TestAddMenuShouldBeAddedInTheGiveRestaurant()
        {


            var restaurant = new Restaurant
            {
                Name = "Happy",
                Id = "a",
                AddressId = "a",
                Email = "a",
                Phone = "00",

            };

            restaurantList.Add(restaurant);

          var menu=await  service.AddMenu("a");

            Assert.Equal(true, restaurantList.Any(x=>x.MenuId==menu));
        }

        [Fact]
        public async void TestEditDishShouldEditTheGiveDish()
        {
 
            var dish = new AddDishInputModel
            {
                CategoryName = "bread",
                Ingredients = "ad",
                Name = "Banica",
                FoodStyle = "bulgarian",
                Price = 1
            };

            service.AddDish(dish,"a");

            var model = new AddDishInputModel
            {
                 CategoryName="bread",
                  FoodStyle="Bulgarian",
                   Ingredients="cheese",
                    Name="Tutmanik",
                     Price=1
            };


            var currDish = dishList.First();
            await service.EditDish(currDish.Id,model);

            Assert.Equal("bread", currDish.Category.Name);

            Assert.NotEqual("ad", currDish.Ingredients);
            Assert.Equal("cheese", currDish.Ingredients);

            Assert.NotEqual("Banica",currDish.Name);
            Assert.Equal("Tutmanik", currDish.Name);

            Assert.Equal(1, currDish.Price);

        }


        [Fact]
        public async void TestRemoveDishShouldRemoveTheGivenDish()
        {

            var dish = new AddDishInputModel
            {
               
                CategoryName = "bread",
                Ingredients = "ad",
                Name = "Banica",
                FoodStyle = "bulgarian",
                Price = 1
            };
            var dish2 = new AddDishInputModel
            {

                CategoryName = "bread",
                Ingredients = "ad",
                Name = "Tutmanik",
                FoodStyle = "bulgarian",
                Price = 1
            };

            service.AddDish(dish, "a");
            service.AddDish(dish2, "a");




            var currDish = dishList.First();
            await service.RemoveDish(currDish.Id);

            Assert.Equal(1, dishList.Count);


        }

        [Fact]
        public async void TestRestaurantMenuShouldReturnTheCorrectMenuId()
        {

            var restraurant = new Restaurant
            {
                Name = "Happy",
                MenuId = "true",
                Id = "a"

            };

            restaurantList.Add(restraurant);


            var expected = "true";

            var result = await service.RestaurantMenu("a");

            Assert.Equal(expected, result);
            Assert.NotEqual("a", result);
        }

        [Fact]
        public async void TestTakeAllCategoriesByMenuShouldReturnTheCorrectCountOfCategories()
        {

            var category = new Category
            {
                 Name="Bread"
            };
            var category2 = new Category
            {
                Name = "BBQ"
            };

            var dish = new Dish
            {
                Name="Banica",
                Category=category,
                MenuId="a"
            };

            var dish2 = new Dish
            {
                Name="Steak",
                Category=category2,
                MenuId="a"
            };


            dishList.Add(dish);
            dishList.Add(dish2);




            var expected = 2;

            var result = (await service.TakeAllCategoriesByMenu("a")).Count;

            Assert.Equal(expected, result);
            
        }
        [Fact]
        public async void TestTakeAllCategoriesByMenuShouldReturnTheCorrectNamesOfCategories()
        {

            var category = new Category
            {
                Name = "Bread"
            };
            var category2 = new Category
            {
                Name = "BBQ"
            };

            var dish = new Dish
            {
                Name = "Banica",
                Category = category,
                MenuId = "a"
            };

            var dish2 = new Dish
            {
                Name = "Steak",
                Category = category2,
                MenuId = "a"
            };


            dishList.Add(dish);
            dishList.Add(dish2);
            var expectedName1 = "Bread";
            var expectedName2 = "BBQ";

            var result = await service.TakeAllCategoriesByMenu("a");
       
            Assert.Equal(true, result.Contains(expectedName1));
            Assert.Equal(true, result.Contains(expectedName2));


        }


        [Fact]
        public async void TestTakeAllDishesShouldReturnTheCorrectCount()
        {
            var category = new Category
            {
                 Name="Something"

            };
           
            var dish = new Dish
            {
                Name = "Banica",
                MenuId = "a",
                Ingredients = "aaa",
                Price = 1,
                Category = category,
            };

            var dish2 = new Dish
            {
                Name = "Steak",
                Ingredients = "aaa",
                Price = 1,
                Category = category,
                MenuId = "a"
            };

            var dish3 = new Dish
            {
                Name = "Steak",
                Ingredients = "aaa",
                Price = 1,
                Category = category,
                MenuId = "b"
            };


            dishList.Add(dish);
            dishList.Add(dish2);
            dishList.Add(dish3);

            var expectedResult = 2;
            var expectedResult2 = 1;
            var expectedResult3 = 0;



            var result1 = (await service.TakeAllDishes("a")).Count;
            var result2 = (await service.TakeAllDishes("b")).Count;
            var result3 = (await service.TakeAllDishes("c")).Count;



            Assert.Equal(expectedResult, result1);
            Assert.Equal(expectedResult2, result2);
            Assert.Equal(expectedResult3, result3);
        }
        [Fact]
        public async void TestTakeDishShouldReturnTheCorrectDishByTheGivenId()
        {

            var category = new Category
            {
                Name = "Something"

            };

            var dish = new Dish
            {
                Name = "Banica",
                MenuId = "a",
                Ingredients = "aaa",
                Price = 1,
                Category = category,
            };

            var dish2 = new Dish
            {
                Name = "Steak",
                Ingredients = "aaa",
                Price = 1,
                Category = category,
                MenuId = "a"
            };

            var dish3 = new Dish
            {
                Name = "Steak",
                Ingredients = "aaa",
                Price = 1,
                Category = category,
                MenuId = "b"
            };


            dishList.Add(dish);
            dishList.Add(dish2);
            dishList.Add(dish3);

            var expectedResult = dish;

            var result =await service.TakeDish(dish.Id);


        



            Assert.Equal(expectedResult.Name, result.Name);
            Assert.Equal(expectedResult.Price, result.Price);
            Assert.Equal(expectedResult.Category.Name, result.CategoryName);
            Assert.Equal(expectedResult.Ingredients, result.Ingredients);


        }
    }


  
}

