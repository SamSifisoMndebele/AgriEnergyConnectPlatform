using AgriEnergyConnectPlatform.Data;
using AgriEnergyConnectPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AgriEnergyConnectPlatform.Pages.Employees;

public class DetailsModel : PageModel
{
    private readonly AgriEnergyConnectPlatformContext _context;

    public DetailsModel(AgriEnergyConnectPlatformContext context)
    {
        _context = context;
    }

    public Farmer Farmer { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        var farmer = await _context.Farmer.FirstOrDefaultAsync(m => m.Id == id);

        if (farmer is not null)
        {
            Farmer = farmer;

            return Page();
        }

        return NotFound();
    }
}