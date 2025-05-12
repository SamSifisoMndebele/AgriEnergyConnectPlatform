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
    public class DetailsModel : PageModel
    {
        private readonly AgriEnergyConnectPlatform.Data.ApplicationDbContext _context;

        public DetailsModel(AgriEnergyConnectPlatform.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public AppUser AppUser { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appuser = await _context.AppUsers.FirstOrDefaultAsync(m => m.Id == id);

            if (appuser is not null)
            {
                AppUser = appuser;

                return Page();
            }

            return NotFound();
        }
    }
}
