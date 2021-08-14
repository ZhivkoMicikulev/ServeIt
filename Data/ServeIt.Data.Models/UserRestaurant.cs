namespace ServeIt.Data.Models
{
    public class UserRestaurant
    {
        public string UserId { get; set; }

        public User User { get; set; }

        public string RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }
    }
}
