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
        var users = from u in _context.AppUsers select u;
        var appUser = users.First(p => p.Id == thisFarmerId);

        _context.Products.Add(new Product()
        {
            Category = Product.Category,
            Name = Product.Name,
            Price = Product.Price,
            Quantity = Product.Quantity,
            Farmer = appUser,
            Availability = true,
            Description = Product.Description,
            ProductionDate = Product.ProductionDate,
            Rating = Product.Rating,
        });
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
