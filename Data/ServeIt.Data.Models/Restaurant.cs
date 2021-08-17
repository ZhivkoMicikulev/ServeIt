namespace ServeIt.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ServeIt.Data.Common.Models;

    public class Restaurant : BaseDeletableModel<string>
    {
        public Restaurant()
        {
            this.Id = Guid.NewGuid().ToString();
     

            this.Orders = new HashSet<Order>();
        }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public string OwnerId { get; set; }

        public User Owner { get; set; }

        public string AddressId { get; set; }

        [Required]
        public Address Address { get; set; }

        [Required]
        [MaxLength(15)]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;

        [Required]
        [MaxLength(200)]
        public string About { get; set; }

        public virtual ICollection<Order> Orders { get; set; }


        public string MenuId { get; set; }

        public Menu Menu { get; set; }
    }
}
