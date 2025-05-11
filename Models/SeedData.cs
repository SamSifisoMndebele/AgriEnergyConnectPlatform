using AgriEnergyConnectPlatform.Data;
using Microsoft.EntityFrameworkCore;

namespace AgriEnergyConnectPlatform.Models;

public static class SeedData
{
    private static Farmer Former1 => new()
    {
        Names = "Sam",
        LastName = "Mndebele"
    };

    private static Farmer Former2 => new()
    {
        Names = "John",
        LastName = "Doe"
    };

    private static Farmer Former3 => new()
    {
        Names = "Jane",
        LastName = "Doe"
    };

    private static Farmer Former4 => new()
    {
        Names = "Sifiso",
        LastName = "Smith"
    };

    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context =
            new AgriEnergyConnectPlatformContext(serviceProvider
                .GetRequiredService<DbContextOptions<AgriEnergyConnectPlatformContext>>());
        if (context?.Product == null) throw new ArgumentNullException(nameof(serviceProvider));
        if (!context.Product.Any())
        {
            // DB is not seeded with Products
            context.Product.AddRange(
                new Product
                {
                    Name = "When Harry Met Sally",
                    ProductionDate = DateTime.Parse("1989-2-12"),
                    Category = "Romantic Comedy",
                    Price = 7.99M,
                    Rating = 2,
                    Farmer = Former2
                },
                new Product
                {
                    Name = "Ghostbusters ",
                    ProductionDate = DateTime.Parse("1984-3-13"),
                    Category = "Comedy",
                    Price = 8.99M,
                    Rating = 4,
                    Farmer = Former1
                },
                new Product
                {
                    Name = "Ghostbusters 2",
                    ProductionDate = DateTime.Parse("1986-2-23"),
                    Category = "Comedy",
                    Price = 9.99M,
                    Rating = 8,
                    Farmer = Former1
                },
                new Product
                {
                    Name = "Rio Bravo",
                    ProductionDate = DateTime.Parse("1959-4-15"),
                    Category = "Western",
                    Price = 3.99M,
                    Rating = 1,
                    Farmer = Former4
                }
            );
            context.SaveChanges();
        }
        else if (!context.Farmer.Any())
        {
            // DB is not seeded with Farmers
            context.Farmer.AddRange(
                Former1,
                Former2,
                Former3,
                Former4
            );
        }
    }
}