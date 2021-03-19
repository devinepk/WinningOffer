using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WinningOffer.Data;
using System;
using System.Linq;

namespace WinningOffer.Models
{
    public class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WinningOfferContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<WinningOfferContext>>()))
            {
                // Look for any movies.
                if (context.Contract.Any())
                {
                    return;   // DB has been seeded
                }

                context.Contract.AddRange(
                    new Contract
                    {
                        Title = "Childhood Home",
                        WrittenDate = DateTime.Parse("1989-2-12"),
                        Address = "715 Noble Court",
                        Rating = "5",
                        Price = 7.99M
                        
                    },

                    new Contract
                    {
                        Title = "Current Address",
                        WrittenDate = DateTime.Parse("1984-3-13"),
                        Address = "6921 Vigo Rd",
                        Rating = "5",
                        Price = 8.99M
                    },

                    new Contract
                    {
                        Title = "Second Apartment 2",
                        WrittenDate = DateTime.Parse("1986-2-23"),
                        Address = "1859 Washburn Ave",
                        Rating = "5",
                        Price = 9.99M
                    },

                    new Contract
                    {
                        Title = "Rio Bravo",
                        WrittenDate = DateTime.Parse("1959-4-15"),
                        Address = "Western",
                        Rating = "5",
                        Price = 3.99M
                    }
                );
                context.SaveChanges();
            }
        }

    }
}
