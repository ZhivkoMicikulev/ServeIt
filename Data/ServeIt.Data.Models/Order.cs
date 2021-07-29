namespace ServeIt.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using ServeIt.Data.Common.Models;
    using ServeIt.Data.Models.Enums;

    public class Order : BaseDeletableModel<string>
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();
            this.DishOrders = new HashSet<DishOrder>();
            this.UserOrders = new HashSet<UserOrder>();
        }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

  
        [Required]
        public string CityId { get; set; }
        public City City { get; set; }

        [Required]
        public string StreetName { get; set; }

        [Required]
        public string restaurantId { get; set; }

        public Restaurant Restaurant { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        [Required]
        public bool IsItPayed { get; set; }

        public virtual ICollection<DishOrder> DishOrders { get; set; }

        public virtual ICollection<UserOrder> UserOrders { get; set; }
    }
}
