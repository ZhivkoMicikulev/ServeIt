using ServeIt.Data.Common.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServeIt.Data.Models
{
    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Dishes = new HashSet<Dish>();
        }

        [Required]
        [MaxLength(30)]

        public string Name { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; }

    }
}