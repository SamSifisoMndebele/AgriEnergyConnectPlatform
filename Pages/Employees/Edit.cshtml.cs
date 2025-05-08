using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgriEnergyConnectPlatform.Data;
using AgriEnergyConnectPlatform.Models;

namespace AgriEnergyConnectPlatform.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly AgriEnergyConnectPlatform.Data.AgriEnergyConnectPlatformContext _context;

        public EditModel(AgriEnergyConnectPlatform.Data.AgriEnergyConnectPlatformContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Farmer Farmer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmer =  await _context.Farmer.FirstOrDefaultAsync(m => m.Id == id);
            if (farmer == null)
            {
                return NotFound();
            }
            Farmer = farmer;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Farmer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FarmerExists(Farmer.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FarmerExists(int id)
        {
            return _context.Farmer.Any(e => e.Id == id);
        }
    }
}
