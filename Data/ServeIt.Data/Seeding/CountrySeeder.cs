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

            var countries = new List<string>
            {
                "Bulgaria",
                "Greece",
                "Romania",
                "Serbia",
                "Turkey",
            };

            foreach (var country in countries)
            {
                await dbContext.Countries.AddAsync(new Country
                {
                    CountryName = country,
                });
            }
        }
    }
}
