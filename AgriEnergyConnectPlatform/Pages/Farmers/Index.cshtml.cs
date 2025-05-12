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
public class IndexModel(ApplicationDbContext context) : PageModel
{
    public IList<AppUser> AppUser { get;set; } = default!;

    public async Task OnGetAsync()
    {
        AppUser = await context.AppUsers.ToListAsync();
    }
}
