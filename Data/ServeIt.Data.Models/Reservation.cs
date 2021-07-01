namespace ServeIt.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using ServeIt.Data.Common.Models;

    public class Reservation : BaseDeletableModel<string>
    {
        public Reservation()
        {
            this.Id = Guid.NewGuid().ToString();
            this.UserReservations = new HashSet<UserReservation>();
        }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public int SeatNumber { get; set; }

        [Required]
        public string RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }

        [Required]
        public string TableId { get; set; }

        public Table Table { get; set; }

        public virtual ICollection<UserReservation> UserReservations { get; set; }
    }
}
