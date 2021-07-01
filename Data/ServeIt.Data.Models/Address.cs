namespace ServeIt.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using ServeIt.Data.Common.Models;

    public class Address : BaseModel<string>
    {
        public Address()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(50)]
        public string StreetName { get; set; }

        [Required]
        public string CityId { get; set; }

        public City City { get; set; }
    }
}
