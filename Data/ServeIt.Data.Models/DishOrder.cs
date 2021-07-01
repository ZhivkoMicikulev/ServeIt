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
        public string DishId { get; set; }

        public Dish Dish { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string OrderId { get; set; }

        public Order Order { get; set; }
    }
}
