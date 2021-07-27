namespace ServeIt.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ServeIt.Data.Common.Models;

    public class FoodStyle : BaseDeletableModel<string>
    {
        public FoodStyle()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public ICollection<Menu> Menus { get; set; }
    }
}
