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
using AgriEnergyConnectPlatform.Utils;
using Microsoft.AspNetCore.Authorization;

namespace AgriEnergyConnectPlatform.Pages.Products;

[Authorize(Roles = nameof(UserRole.Farmer))]
public class EditModel(ApplicationDbContext context) : PageModel
{

    [BindProperty]
    public Product Product { get; set; } = default!;
    [BindProperty]
    public AppUser Farmer { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product =  await context.Products
            .Include(p => p.Farmer)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (product == null)
        {
            return NotFound();
        }
        var thisFarmerId = User.Claims.First(claim => claim.Type == MyClaimTypes.UserId).Value;
        var appUser = context.AppUsers.First(p => p.Id == thisFarmerId);
        if (appUser.Id != product.Farmer.Id)
        {
            return Unauthorized();
        }
        Product = product;
        Farmer = product.Farmer;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more information, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {

        context.Attach(Product).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductExists(Product.Id))
            {
                return NotFound();
            }

            throw;
        }

        return RedirectToPage("./Index");
    }

    private bool ProductExists(int id)
    {
        return context.Products.Any(e => e.Id == id);
    }
}
