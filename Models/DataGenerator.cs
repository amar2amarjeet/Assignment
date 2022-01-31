using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SampleAPI.Models
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SampleDBContext(
                serviceProvider.GetRequiredService<DbContextOptions<SampleDBContext>>()))
            {
                Country country = new Country() { country_code = "IN", name = "India" };
                context.Countries.Add(country);

                State state = new State() { name = "Rajasthan", state_code = "RJ", country_code = "IN" };
                context.States.Add(state);

                City city = new City() { name = "Jaipur", city_code = "JPI", state_code = "RJ", country_code = "IN" };
                context.Cities.Add(city);
                city = new City() { name = "Udaipur", city_code = "UDI", state_code = "RJ", country_code = "IN" };
                context.Cities.Add(city);
                city = new City() { name = "Ajmer", city_code = "AJM", state_code = "RJ", country_code = "IN" };
                context.Cities.Add(city);
                city = new City() { name = "Kota", city_code = "KOT", state_code = "RJ", country_code = "IN" };
                context.Cities.Add(city);
                context.SaveChanges();
            }

        }
    }
}