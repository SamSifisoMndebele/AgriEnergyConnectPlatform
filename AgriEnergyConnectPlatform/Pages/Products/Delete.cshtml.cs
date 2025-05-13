using AgriEnergyConnectPlatform.Data;
using AgriEnergyConnectPlatform.Models;
using AgriEnergyConnectPlatform.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AgriEnergyConnectPlatform.Pages.Products;

[Authorize(Roles = nameof(UserRole.Farmer))]
public class DeleteModel(ApplicationDbContext context) : PageModel
{
    [BindProperty] public Product Product { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        var product = await context.Products
            .Include(product => product.Farmer)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (product is not null)
        {
            var thisFarmerId = User.Claims.First(claim => claim.Type == MyClaimTypes.UserId).Value;
            var appUser = context.AppUsers.First(p => p.Id == thisFarmerId);
            if (appUser.Id != product.Farmer.Id) return Unauthorized();
            Product = product;

            return Page();
        }

        return NotFound();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null) return NotFound();

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