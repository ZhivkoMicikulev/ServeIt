namespace ServeIt.Web.ViewModels.Administration
{
    using System.Collections.Generic;

    public class AllCountriesViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<AllCitiesViewModel> Cities { get; set; }
    }
}
