using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AgriEnergyConnectPlatform.Models;

namespace AgriEnergyConnectPlatform.Data
{
    public class AgriEnergyConnectPlatformContext : DbContext
    {
        public AgriEnergyConnectPlatformContext (DbContextOptions<AgriEnergyConnectPlatformContext> options)
            : base(options)
        {
        }

        public DbSet<AgriEnergyConnectPlatform.Models.Product> Product { get; set; } = default!;
        public DbSet<AgriEnergyConnectPlatform.Models.Farmer> Farmer { get; set; } = default!;
    }
}
