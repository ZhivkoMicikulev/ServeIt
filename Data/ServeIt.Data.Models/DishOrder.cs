namespace ServeIt.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using ServeIt.Data.Common.Models;

    public class DishOrder : BaseDeletableModel<string>
    {
        public DishOrder()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        [Required]
        public string OwnerId { get; set; }
        public User User { get; set; }

        [Required]
        public string DishId { get; set; }

        public Dish Dish { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public bool Status { get; set; }
      
        public string RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

    }
}
