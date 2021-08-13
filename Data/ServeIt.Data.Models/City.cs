namespace ServeIt.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ServeIt.Data.Common.Models;

    public class City : BaseDeletableModel<string>
    {
        public City()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Addresses = new HashSet<Address>();
        }

        [Required]
        [MaxLength(30)]
        public string CityName { get; set; }

        [Required]
        public string CountryId { get; set; }

        public Country Country { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
