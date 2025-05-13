using AgriEnergyConnectPlatform.Data;
using AgriEnergyConnectPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AgriEnergyConnectPlatform.Pages.Products;

public class DetailsModel(ApplicationDbContext context) : PageModel
{
    public Product Product { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        var product = await context.Products
            .Include(p => p.Farmer)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (product is not null)
        {
            Product = product;

            return Page();
        }

        return NotFound();
    }
}