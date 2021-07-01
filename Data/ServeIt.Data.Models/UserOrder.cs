namespace ServeIt.Data.Models
{
    public class UserOrder
    {

        public string UserId { get; set; }

        public User User { get; set; }

        public string OrderId { get; set; }

        public Order Order { get; set; }
    }
}
