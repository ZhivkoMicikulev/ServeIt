namespace ServeIt.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ServeIt.Data.Common.Models;

    public class Ingredient : BaseDeletableModel<string>
    {
        public Ingredient()
        {
            this.Id = Guid.NewGuid().ToString();
            this.DishIngredients = new HashSet<DishIngredient>();
        }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public virtual ICollection<DishIngredient> DishIngredients { get; set; }
    }
}
