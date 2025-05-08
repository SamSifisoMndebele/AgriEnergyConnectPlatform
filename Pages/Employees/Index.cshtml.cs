using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AgriEnergyConnectPlatform.Data;
using AgriEnergyConnectPlatform.Models;

namespace AgriEnergyConnectPlatform.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly AgriEnergyConnectPlatform.Data.AgriEnergyConnectPlatformContext _context;

        public IndexModel(AgriEnergyConnectPlatform.Data.AgriEnergyConnectPlatformContext context)
        {
            _context = context;
        }

        public IList<Farmer> Farmer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Farmer = await _context.Farmer.ToListAsync();
        }
    }
}
