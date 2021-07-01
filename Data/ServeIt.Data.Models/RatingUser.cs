namespace ServeIt.Data.Models
{
    public class RatingUser
    {
        public string UserId { get; set; }

        public User User { get; set; }

        public int RatingId { get; set; }

        public Rating Rating { get; set; }
    }
}
