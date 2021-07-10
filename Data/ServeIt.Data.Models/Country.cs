namespace ServeIt.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ServeIt.Data.Common.Models;

    public class Country : BaseModel<string>
    {
        public Country()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(30)]
        public string CountryName { get; set; }

        public virtual ICollection<City> Cities { get; set; }
        public bool IsDeleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? DeletedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
