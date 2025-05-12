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

namespace AgriEnergyConnectPlatform.Pages.Employees;

public class IndexModel : PageModel
{
    private readonly AgriEnergyConnectPlatform.Data.ApplicationDbContext _context;

    public IndexModel(AgriEnergyConnectPlatform.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<AppUser> AppUser { get;set; } = default!;

    public async Task OnGetAsync()
    {
        AppUser = await _context.AppUsers.ToListAsync();
    }
}
