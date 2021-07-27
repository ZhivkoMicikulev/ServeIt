namespace ServeIt.Data.Models
{
    using System;
    using System.Collections.Generic;

    using ServeIt.Data.Common.Models;

    public class Menu : BaseDeletableModel<string>
    {
        public Menu()
        {
            this.Id = Guid.NewGuid().ToString();
            this.FoodStyles = new HashSet<FoodStyle>();
            this.Dishes = new HashSet<Dish>();
          

        }

        public virtual ICollection<FoodStyle> FoodStyles { get; set; }

        public virtual  ICollection<Dish> Dishes { get; set; }

      


    }
}
