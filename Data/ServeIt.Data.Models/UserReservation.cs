namespace ServeIt.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using ServeIt.Data.Common.Models;

    public class UserReservation : BaseDeletableModel<string>
    {
        public UserReservation()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string ReservationId { get; set; }

        public Reservation Reservation { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
