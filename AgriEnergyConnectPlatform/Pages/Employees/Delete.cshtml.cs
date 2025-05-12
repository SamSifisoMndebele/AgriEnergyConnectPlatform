using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AgriEnergyConnectPlatform.Data;
using AgriEnergyConnectPlatform.Models;
using Microsoft.AspNetCore.Authorization;

namespace AgriEnergyConnectPlatform.Pages.Employees
{
    [Authorize(Roles = nameof(UserRole.Employee))]
    public class DeleteModel : PageModel
    {
        private readonly AgriEnergyConnectPlatform.Data.ApplicationDbContext _context;

        public DeleteModel(AgriEnergyConnectPlatform.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appuser = await _context.AppUsers.FindAsync(id);
            if (appuser != null)
            {
                AppUser = appuser;
                _context.AppUsers.Remove(AppUser);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
