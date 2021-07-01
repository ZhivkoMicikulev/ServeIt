namespace ServeIt.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using ServeIt.Data.Common.Models;

    public class Table : BaseDeletableModel<string>
    {
        public Table()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Orders = new HashSet<Order>();
            this.Reservations = new HashSet<Reservation>();
        }

        [Required]
        public string RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }

        [Required]
        [MaxLength(6)]
        public string TableIdentificator { get; set; }

        [Required]
        public int Seats { get; set; }

        [Required]
        public bool Vacant { get; set; }

        [Required]
        public bool Reserved { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
