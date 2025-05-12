using AgriEnergyConnectPlatform.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using static Microsoft.Extensions.Options.Options;

namespace AgriEnergyConnectPlatform.Models;

public static class SeedData
{
    private static readonly PasswordHasher<AppUser> PasswordHasher = new();

    private static readonly AppUser Admin = new()
    {
        Id = Guid.NewGuid().ToString(),
        Email = "admin@mail.com",
        PasswordHash = PasswordHasher.HashPassword(null, "Admin@123"),
        UserRole = UserRole.Employee,
        Names = "A",
        Surname = "Admin",
        PhoneNumber = "0000000000",
    };

    private static readonly AppUser Farmer1 = new()
    {
        Id = Guid.NewGuid().ToString(),
        Email = "jane.doe@example.com",
        PasswordHash = PasswordHasher.HashPassword(null, "Password@123"),
        UserRole = UserRole.Farmer,
        Names = "Jane",
        Surname = "Doe",
        PhoneNumber = "0721646430",
    };

    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context =
            new ApplicationDbContext(serviceProvider
                .GetRequiredService<DbContextOptions<ApplicationDbContext>>());
        if (context.Products == null || context.AppUsers == null) throw new ArgumentNullException(nameof(serviceProvider));
        if (!context.AppUsers.Any())
        {
            // DB is not seeded with AppUsers
            context.AppUsers.AddRange(
                Admin,
                Farmer1
            );
        } 
        if (!context.Products.Any())
        {
            // DB is not seeded with Products
            context.Products.AddRange(
                new Product
                {
                    Name = "Fresh Sweet Corn",
                    Description = "Locally grown sweet corn, picked at peak ripeness",
                    Price = 49.99m,
                    Quantity = 200,
                    Category = "Vegetables",
                    Farmer = Farmer1,
                },
                new Product
                {
                    Name = "Premium Tomatoes",
                    Description = "Vine-ripened tomatoes grown in controlled conditions",
                    Price = 79.99m,
                    Quantity = 150,
                    Category = "Vegetables",
                    Farmer = Farmer1,
                },
                new Product
                {
                    Name = "Organic Potatoes",
                    Description = "Chemical-free potatoes grown in rich soil",
                    Price = 89.99m,
                    Quantity = 300,
                    Category = "Root Vegetables",
                    Farmer = Farmer1,
                },
                new Product
                {
                    Name = "Fresh Cabbage",
                    Description = "Large, crisp cabbage heads perfect for cooking",
                    Price = 34.99m,
                    Quantity = 100,
                    Category = "Leafy Greens",
                    Farmer = Farmer1,
                },
                new Product
                {
                    Name = "Green Beans",
                    Description = "Tender, fresh green beans picked daily",
                    Price = 59.99m,
                    Quantity = 120,
                    Category = "Vegetables",
                    Farmer = Farmer1,
                },
                new Product
                {
                    Name = "Butternut Squash",
                    Description = "Sweet and nutty butternut squash, locally grown",
                    Price = 44.99m,
                    Quantity = 80,
                    Category = "Vegetables",
                    Farmer = Farmer1,
                }
            );
            context.SaveChanges();
        }
    }
}