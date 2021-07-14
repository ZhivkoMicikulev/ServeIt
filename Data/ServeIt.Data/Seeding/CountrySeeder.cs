namespace ServeIt.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using ServeIt.Data.Models;

    public class CountrySeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Countries.Any())
            {
                return;
            }

            var countries = new List<(string countryName,string city)>
            {
               ( "Bulgaria","Sofiq"),
                ("Bulgaria","Plovdiv"),
                ("Bulgaria","Varna"),
                ("Bulgaria","Burgas"),
                ("Bulgaria","Ruse"),
                ( "Romania","Bucharest "),
                ( "Romania","Cluj-Napoca"),
                ( "Romania","Timisoara"),
                ("Greece","Athens"),
                ("Greece","Thessaloniki"),
                ("Greece","Patras "),
                ("Turkey","Istanbul"),
                ("Turkey","Ankara"),
                ( "Serbia","Belgrade"),
                ( "Serbia","Niš"),
                
               
               
                
            };

            foreach (var country in countries)
            {
                if (dbContext.Countries.Any(x=>x.CountryName==country.countryName))
                {
                    var thisCountry = dbContext.Countries.Where(x => x.CountryName == country.countryName).FirstOrDefault();
                    await dbContext.Cities.AddAsync(new City
                    {
                        Country = thisCountry,
                        CityName = country.city,
                    });
                }
                else
                {
                    var newCountry = new Country
                    {
                        CountryName = country.countryName,
                    };
                    await dbContext.Countries.AddAsync(newCountry);
                    await dbContext.Cities.AddAsync(new City
                    {
                        Country = newCountry,
                        CityName = country.city,
                    });
                }
               
            }
        }
    }
}
