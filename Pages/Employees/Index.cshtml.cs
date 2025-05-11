using AgriEnergyConnectPlatform.Data;
using AgriEnergyConnectPlatform.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AgriEnergyConnectPlatform.Pages.Employees;

public class IndexModel : PageModel
{
    private readonly AgriEnergyConnectPlatformContext _context;

    public IndexModel(AgriEnergyConnectPlatformContext context)
    {
        _context = context;
    }

    public IList<Farmer> Farmer { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Farmer = await _context.Farmer.ToListAsync();
    }
}