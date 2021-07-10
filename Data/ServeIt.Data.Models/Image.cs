using System;
using System.Collections.Generic;
using System.Text;
namespace ServeIt.Data.Models
   
{
 public class Image
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string ImagePath { get; set; }

        public string FileContentType { get; set; }
    }
}
