using AgriEnergyConnectPlatform.Data;
using AgriEnergyConnectPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AgriEnergyConnectPlatform.Pages.Farmers;

public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DetailsModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public Product Product { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        var product = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);

        if (product is not null)
        {
            Product = product;

            return Page();
        }

        return NotFound();
    }
}