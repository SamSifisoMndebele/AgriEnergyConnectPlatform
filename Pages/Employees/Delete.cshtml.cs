using AgriEnergyConnectPlatform.Data;
using AgriEnergyConnectPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AgriEnergyConnectPlatform.Pages.Employees;

public class DeleteModel : PageModel
{
    private readonly AgriEnergyConnectPlatformContext _context;

    public DeleteModel(AgriEnergyConnectPlatformContext context)
    {
        _context = context;
    }

    [BindProperty] public Farmer Farmer { get; set; } = default!;

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

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null) return NotFound();

        var farmer = await _context.Farmer.FindAsync(id);
        if (farmer != null)
        {
            Farmer = farmer;
            _context.Farmer.Remove(Farmer);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}