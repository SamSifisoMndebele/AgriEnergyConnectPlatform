﻿using AgriEnergyConnectPlatform.Data;
using Microsoft.EntityFrameworkCore;
using static BCrypt.Net.BCrypt;

namespace AgriEnergyConnectPlatform.Models;

public static class SeedData
{
    private static readonly AppUser Admin = new()
    {
        Id = Guid.NewGuid().ToString(),
        Email = "admin@mail.com",
        PasswordHash = HashPassword("Admin@123"),
        UserRole = UserRole.Employee,
        Names = "A",
        Surname = "Admin",
        PhoneNumber = "0000000000"
    };

    private static readonly AppUser Farmer1 = new()
    {
        Id = Guid.NewGuid().ToString(),
        Email = "sam@mail.com",
        PasswordHash = HashPassword("Password@123"),
        UserRole = UserRole.Farmer,
        Names = "Sam",
        Surname = "Mndebele",
        PhoneNumber = "0721646430",
        StreetAddress = "Stand 111",
        City = "Mbombela",
        Province = "Mpumalanga",
        PostalCode = "0000"
    };

    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context =
            new ApplicationDbContext(serviceProvider
                .GetRequiredService<DbContextOptions<ApplicationDbContext>>());
        if (context.Products == null || context.AppUsers == null)
            throw new ArgumentNullException(nameof(serviceProvider));
        if (!context.AppUsers.Any())
            // DB is not seeded with AppUsers
            context.AppUsers.AddRange(
                Admin,
                Farmer1
            );
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
                    ProductionDate = DateTime.Today,
                    Rating = 4
                },
                new Product
                {
                    Name = "Premium Tomatoes",
                    Description = "Vine-ripened tomatoes grown in controlled conditions",
                    Price = 79.99m,
                    Quantity = 150,
                    Category = "Vegetables",
                    Farmer = Farmer1,
                    ProductionDate = DateTime.Today,
                    Rating = 3
                },
                new Product
                {
                    Name = "Organic Potatoes",
                    Description = "Chemical-free potatoes grown in rich soil",
                    Price = 89.99m,
                    Quantity = 300,
                    Category = "Root Vegetables",
                    Farmer = Farmer1,
                    ProductionDate = DateTime.Today,
                    Rating = 7
                },
                new Product
                {
                    Name = "Fresh Cabbage",
                    Description = "Large, crisp cabbage heads perfect for cooking",
                    Price = 34.99m,
                    Quantity = 100,
                    Category = "Leafy Greens",
                    Farmer = Farmer1,
                    ProductionDate = DateTime.Today,
                    Rating = 2
                },
                new Product
                {
                    Name = "Green Beans",
                    Description = "Tender, fresh green beans picked daily",
                    Price = 59.99m,
                    Quantity = 120,
                    Category = "Vegetables",
                    Farmer = Farmer1,
                    ProductionDate = DateTime.Today,
                    Rating = 1
                },
                new Product
                {
                    Name = "Butternut Squash",
                    Description = "Sweet and nutty butternut squash, locally grown",
                    Price = 44.99m,
                    Quantity = 80,
                    Category = "Vegetables",
                    Farmer = Farmer1,
                    ProductionDate = DateTime.Today,
                    Rating = 7
                }
            );
            context.SaveChanges();
        }
    }
}