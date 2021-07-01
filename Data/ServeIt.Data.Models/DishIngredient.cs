namespace ServeIt.Data.Models
{
    public class DishIngredient
    {
        public string DishId { get; set; }

        public Dish Dish { get; set; }

        public string IngredientId { get; set; }

        public Ingredient Ingredient { get; set; }
    }
}
