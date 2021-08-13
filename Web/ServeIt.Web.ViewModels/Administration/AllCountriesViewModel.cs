using System;
using System.Collections.Generic;
using System.Text;

namespace ServeIt.Web.ViewModels.Administration
{
 public   class AllCountriesViewModel
    {
        public string  Id { get; set; }

        public string Name { get; set; }

        public ICollection<AllCitiesViewModel> Cities { get; set; }
    }
}
