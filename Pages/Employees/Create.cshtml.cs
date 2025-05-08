using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AgriEnergyConnectPlatform.Data;
using AgriEnergyConnectPlatform.Models;

namespace AgriEnergyConnectPlatform.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly AgriEnergyConnectPlatform.Data.AgriEnergyConnectPlatformContext _context;

        public CreateModel(AgriEnergyConnectPlatform.Data.AgriEnergyConnectPlatformContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Farmer Farmer { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Farmer.Add(Farmer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
