using AgriEnergyConnectPlatform.Data;
using AgriEnergyConnectPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgriEnergyConnectPlatform.Pages.Employees;

public class CreateModel : PageModel
{
    private readonly AgriEnergyConnectPlatformContext _context;

    public CreateModel(AgriEnergyConnectPlatformContext context)
    {
        _context = context;
    }

    [BindProperty] public Farmer Farmer { get; set; } = default!;

    public IActionResult OnGet()
    {
        return Page();
    }

    // For more information, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Farmer.Add(Farmer);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}