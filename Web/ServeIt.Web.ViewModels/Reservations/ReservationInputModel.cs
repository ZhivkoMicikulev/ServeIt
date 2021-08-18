namespace ServeIt.Web.ViewModels.Reservations
{
    using System.ComponentModel.DataAnnotations;

    public class ReservationInputModel
    {
        [Required]
        public string UserId { get; set; }
        [Required]

        public string RestaurantId { get; set; }

        public string Message { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string Time { get; set; }

        [Required]
       
        public int People { get; set; }
    }
}
