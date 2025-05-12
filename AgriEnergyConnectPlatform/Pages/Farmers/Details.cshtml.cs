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

namespace AgriEnergyConnectPlatform.Pages.Farmers;

[Authorize(Roles = nameof(UserRole.Farmer) + "," + nameof(UserRole.Employee))]
public class DetailsModel(ApplicationDbContext context) : PageModel
{
    public AppUser AppUser { get; set; } = default!;
    public IList<Product> Products { get;set; } = default!;

    public async Task<IActionResult> OnGetAsync(string? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var appuser = await context.AppUsers.FirstOrDefaultAsync(m => m.Id == id);
        
        var products = from p in context.Products
            select p;
        products = products.Where(p => p.Farmer.Id == id);
        Products = await products.ToListAsync();

        if (appuser is not null)
        {
            AppUser = appuser;

            return Page();
        }

        return NotFound();
    }
}
