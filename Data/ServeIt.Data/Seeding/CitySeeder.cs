using ServeIt.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServeIt.Data.Seeding
{
  public  class CitySeeder:ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Cities.Any())
            {
                return;
            }

            var cities = new List<(string name, string countryId)>
            {
                ("Sofiq","2d3965ac-a55c-439f-b578-01e536d5aedc"),
                ("Plovdiv","2d3965ac-a55c-439f-b578-01e536d5aedc"),
                ("Varna","2d3965ac-a55c-439f-b578-01e536d5aedc"),
                ("Burgas","2d3965ac-a55c-439f-b578-01e536d5aedc"),
                ("Ruse","2d3965ac-a55c-439f-b578-01e536d5aedc"),
                ("Bucharest ","233199c3-6c9a-4de4-82e9-fbdbe534827f"),
                ("Cluj-Napoca","233199c3-6c9a-4de4-82e9-fbdbe534827f"),
                ("Timisoara","233199c3-6c9a-4de4-82e9-fbdbe534827f"),
                ("Athens","9a4e40cc-7522-4c48-b61b-1bd50c0516b5"),
                ("Thessaloniki","9a4e40cc-7522-4c48-b61b-1bd50c0516b5"),
                ("Patras ","9a4e40cc-7522-4c48-b61b-1bd50c0516b5"),
                ("Istanbul","aed307f9-6f30-49be-ba41-609846f30ac3"),
                ("Ankara","aed307f9-6f30-49be-ba41-609846f30ac3"),
                ("Belgrade","c94cb2d1-37e1-43d7-b5a8-a3031f19c93f"),
                ("Niš","c94cb2d1-37e1-43d7-b5a8-a3031f19c93f"),



          };

            foreach (var city in cities)
            {
                await dbContext.Cities.AddAsync(new City
                {
                    CityName=city.name,
                    CountryId=city.countryId,
                });
            }
        }
    }
}
