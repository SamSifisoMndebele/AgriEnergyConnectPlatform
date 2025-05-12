using AgriEnergyConnectPlatform.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using static Microsoft.Extensions.Options.Options;

namespace AgriEnergyConnectPlatform.Models;

public static class SeedData
{
    // private static PasswordHasher<AppUsers> PasswordHasher;
    private static AppUser Employee1 => new()
    {
        Id = Guid.NewGuid().ToString(),
        Email = "sams.mndebele@gmail.com",
        // PasswordHash = PasswordHasher.HashPassword(Former1, "Password"),
        PasswordHash = "Password",
        UserRole = UserRole.Employee,
        Names = "Sam Sifiso",
        Surname = "Mndebele",
        PhoneNumber = "0721646430",
        StreetAddress = "Stand 104 Clau-Clau",
        City = "Mbombela",
        Province = "Mpumalanga",
        PostalCode = "1245"
    };

    private static AppUser Farmer1 => new()
    {
        Id = Guid.NewGuid().ToString(),
        Email = "john.doe@example.com",
        // PasswordHash = PasswordHasher.HashPassword(Former2, "Password"),
        PasswordHash = "Password",
        UserRole = UserRole.Farmer,
        Names = "John",
        Surname = "Doe",
        PhoneNumber = "0721646430",
    };

    private static AppUser Employee2 => new()
    {
        Id = Guid.NewGuid().ToString(),
        Email = "jane.doe@example.com",
        // PasswordHash = PasswordHasher.HashPassword(Former3, "Password"),
        PasswordHash = "Password",
        UserRole = UserRole.Employee,
        Names = "Jane",
        Surname = "Doe",
        PhoneNumber = "0721646430",
    };

    private static AppUser Farmer2 => new()
    {
        Id = Guid.NewGuid().ToString(),
        Email = "sifiso.smith@example.com",
        // PasswordHash = PasswordHasher.HashPassword(Former4, "Password"),
        PasswordHash = "Password",
        UserRole = UserRole.Farmer,
        Names = "Sifiso",
        Surname = "Smith",
        PhoneNumber = "0721646430",
    };

    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context =
            new AgriEnergyConnectPlatformContext(serviceProvider
                .GetRequiredService<DbContextOptions<AgriEnergyConnectPlatformContext>>());
        // if (context.Products == null || context.AppUsers == null) throw new ArgumentNullException(nameof(serviceProvider));
        if (!context.AppUsers.Any())
        {
            // DB is not seeded with AppUsers
            context.AppUsers.AddRange(
                Employee1,
                Employee2,
                Farmer1,
                Farmer2
            );
        } 
        if (!context.Products.Any())
        {
            // DB is not seeded with Products
            context.Products.AddRange(
                new Product
                {
                    Name = "When Harry Met Sally",
                    ProductionDate = DateTime.Parse("1989-2-12"),
                    Category = "Romantic Comedy",
                    Price = 7.99M,
                    Rating = 2,
                    Farmer = Farmer1
                },
                new Product
                {
                    Name = "Ghostbusters ",
                    ProductionDate = DateTime.Parse("1984-3-13"),
                    Category = "Comedy",
                    Price = 8.99M,
                    Rating = 4,
                    Farmer = Farmer2
                },
                new Product
                {
                    Name = "Ghostbusters 2",
                    ProductionDate = DateTime.Parse("1986-2-23"),
                    Category = "Comedy",
                    Price = 9.99M,
                    Rating = 8,
                    Farmer = Farmer2
                },
                new Product
                {
                    Name = "Rio Bravo",
                    ProductionDate = DateTime.Parse("1959-4-15"),
                    Category = "Western",
                    Price = 3.99M,
                    Rating = 1,
                    Farmer = Farmer1
                }
            );
            context.SaveChanges();
        }
    }
}