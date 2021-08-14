namespace ServeIt.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ServeIt.Data.Common.Models;

    public class Comment : BaseDeletableModel<string>
    {
        public Comment()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(200)]
        public string Content { get; set; }
    }
}
