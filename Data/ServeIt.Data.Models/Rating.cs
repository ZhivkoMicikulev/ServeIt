namespace ServeIt.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ServeIt.Data.Common.Models;

    public class Rating : BaseDeletableModel<int>
    {
        public Rating()
        {
            this.RatingUsers = new HashSet<RatingUser>();
        }

        [Required]
        public decimal RatingScore { get; set; }

        [Required]
        public string RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }

        public virtual ICollection<RatingUser> RatingUsers { get; set; }
    }
}
