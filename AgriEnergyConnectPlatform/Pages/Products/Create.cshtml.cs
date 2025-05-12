using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AgriEnergyConnectPlatform.Data;
using AgriEnergyConnectPlatform.Models;
using AgriEnergyConnectPlatform.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace AgriEnergyConnectPlatform.Pages.Products;

[Authorize(Roles = nameof(UserRole.Farmer))]
public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;
    private static AppUser ThisFarmer;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    } 

    public async Task OnGetAsync()
    {
        var uid = User.Claims.First(claim => claim.Type == MyClaimTypes.UserId).Value;
        var users = from u in _context.AppUsers select u;
        users = users.Where(p => p.Id == uid);
        ThisFarmer = await users.FirstAsync();
    }
    
    [BindProperty] 
    public Product Product { get; set; } = default!;

    // For more information, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        // if (!ModelState.IsValid)
        // {
        //     return Page();
        // }

        _context.Products.Add(new Product
        {
            Name = Product.Name,
            Price = Product.Price,
            Category = Product.Category,
            ProductionDate = Product.ProductionDate,
            Rating = Product.Rating,
            Farmer = ThisFarmer,
        });
        Console.WriteLine(Product.ProductionDate);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
