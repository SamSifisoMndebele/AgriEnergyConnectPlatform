using AgriEnergyConnectPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace AgriEnergyConnectPlatform.Data;

public class AgriEnergyConnectPlatformContext : DbContext
{
    public AgriEnergyConnectPlatformContext(DbContextOptions<AgriEnergyConnectPlatformContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; } = default!;
    public DbSet<AppUser> AppUsers { get; set; } = default!;
}