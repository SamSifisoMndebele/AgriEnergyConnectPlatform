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

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    } 

    public void OnGet()
    {
        
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
        
        var thisFarmerId = User.Claims.First(claim => claim.Type == MyClaimTypes.UserId).Value;

        await _context.Database.ExecuteSqlRawAsync(
            "INSERT INTO Products (Name, Category, Price, ProductionDate, Rating, FarmerId) VALUES ({0}, {1}, {2}, {3}, {4}, {5})", 
            Product.Name, Product.Category, Product.Price, Product.ProductionDate, Product.Rating, thisFarmerId);

        return RedirectToPage("./Index");
    }
}
