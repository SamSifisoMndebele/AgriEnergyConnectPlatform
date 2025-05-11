using AgriEnergyConnectPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace AgriEnergyConnectPlatform.Data;

public class AgriEnergyConnectPlatformContext : DbContext
{
    public AgriEnergyConnectPlatformContext(DbContextOptions<AgriEnergyConnectPlatformContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Product { get; set; } = default!;
    public DbSet<Farmer> Farmer { get; set; } = default!;
}