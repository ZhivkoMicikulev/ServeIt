using System;
using System.Collections.Generic;
using System.Text;

namespace ServeIt.Web.ViewModels.Menu
{
  public  class DishViewModel
    {
        public string Name { get; set; }

        public string  Id { get; set; }

        public decimal Price { get; set; }

        public string Ingredients { get; set; }

        public string CategoryName { get; set; }
    }
}
