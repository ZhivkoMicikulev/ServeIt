namespace ServeIt.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ServeIt.Data.Common.Models;

    public class Dish : BaseDeletableModel<string>
    {
        public Dish()
        {
            this.Id = Guid.NewGuid().ToString();
            this.DishIngredients = new HashSet<DishIngredient>();
            this.DishOrders = new HashSet<DishOrder>();
        }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public Category Category { get; set; }

        public virtual ICollection<DishIngredient> DishIngredients { get; set; }

        public virtual ICollection<DishOrder> DishOrders { get; set; }


    }
}
