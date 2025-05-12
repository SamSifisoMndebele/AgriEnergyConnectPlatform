using System.Security.Authentication;
using AgriEnergyConnectPlatform.Data;
using AgriEnergyConnectPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using AgriEnergyConnectPlatform.Utils;

namespace AgriEnergyConnectPlatform.Pages.Farmers;

public class CreateModel : PageModel
{
    private readonly AgriEnergyConnectPlatformContext _context;

    public CreateModel(AgriEnergyConnectPlatformContext context)
    {
        _context = context;
    }

    [BindProperty] public Product Product { get; set; } = default!;

    public IActionResult OnGet()
    {
        return Page();
    }

    // For more information, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();
        
        var users = from u in _context.AppUsers select u;
        var farmerId = User.FindFirstValue(MyClaimTypes.UserId) ?? throw new InvalidCredentialException();
        var appUser = users.First(p => p.Id == farmerId);
        Product.Farmer = appUser;
        _context.Products.Add(Product);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}