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

namespace AgriEnergyConnectPlatform.Pages.Products;

[Authorize(Roles = nameof(UserRole.Farmer))]
public class DeleteModel(ApplicationDbContext context) : PageModel
{
    [BindProperty]
    public Product Product { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = await context.Products.FirstOrDefaultAsync(m => m.Id == id);

        if (product is not null)
        {
            Product = product;

            return Page();
        }

        return NotFound();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = await context.Products.FindAsync(id);
        if (product != null)
        {
            Product = product;
            context.Products.Remove(Product);
            await context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
