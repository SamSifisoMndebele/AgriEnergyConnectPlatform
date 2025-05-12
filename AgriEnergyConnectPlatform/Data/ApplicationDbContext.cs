using AgriEnergyConnectPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace AgriEnergyConnectPlatform.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; } = default!;
    public DbSet<AppUser> AppUsers { get; set; } = default!;
}