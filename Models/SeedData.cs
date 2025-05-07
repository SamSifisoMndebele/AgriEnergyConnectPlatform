using AgriEnergyConnectPlatform.Data;
using Microsoft.EntityFrameworkCore;

namespace AgriEnergyConnectPlatform.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new AgriEnergyConnectPlatformContext(serviceProvider.GetRequiredService<DbContextOptions<AgriEnergyConnectPlatformContext>>());
        if (context?.Product == null)
        {
            throw new ArgumentNullException(nameof(serviceProvider));
        }
        if (!context.Product.Any()) 
        {   // DB not seeded with Products
            context.Product.AddRange(
                new Product
                {
                    Name = "When Harry Met Sally",
                    ProductionDate = DateTime.Parse("1989-2-12"),
                    Category = "Romantic Comedy",
                    Price = 7.99M,
                    Rating = 2
                },
                new Product
                {
                    Name = "Ghostbusters ",
                    ProductionDate = DateTime.Parse("1984-3-13"),
                    Category = "Comedy",
                    Price = 8.99M,
                    Rating = 4
                },
                new Product
                {
                    Name = "Ghostbusters 2",
                    ProductionDate = DateTime.Parse("1986-2-23"),
                    Category = "Comedy",
                    Price = 9.99M,
                    Rating = 8
                },
                new Product
                {
                    Name = "Rio Bravo",
                    ProductionDate = DateTime.Parse("1959-4-15"),
                    Category = "Western",
                    Price = 3.99M,
                    Rating = 1
                }
            );
            context.SaveChanges();
        }
    }
}