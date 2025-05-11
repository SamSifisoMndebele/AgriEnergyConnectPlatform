using AgriEnergyConnectPlatform.Data;
using AgriEnergyConnectPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AgriEnergyConnectPlatform.Pages.Farmers;

public class IndexModel : PageModel
{
    private readonly AgriEnergyConnectPlatformContext _context;

    public IndexModel(AgriEnergyConnectPlatformContext context)
    {
        _context = context;
    }

    public IList<Product> Product { get; set; } = default!;

    [BindProperty(SupportsGet = true)] public string? Search { get; set; }

    public SelectList? Categories { get; set; }

    [BindProperty(SupportsGet = true)] public string? Category { get; set; }

    public async Task OnGetAsync()
    {
        var categoryQuery = from p in _context.Product
            orderby p.Category
            select p.Category;

        var products = from p in _context.Product
            select p;

        if (!string.IsNullOrEmpty(Category)) products = products.Where(p => p.Category == Category);

        if (!string.IsNullOrEmpty(Search)) products = products.Where(p => p.Name != null && p.Name.Contains(Search));

        Categories = new SelectList(await categoryQuery.Distinct().ToListAsync());

        Product = await products.ToListAsync();
    }
}