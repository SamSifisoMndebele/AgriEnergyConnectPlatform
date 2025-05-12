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
using Microsoft.AspNetCore.Authorization;

namespace AgriEnergyConnectPlatform.Pages.Employees;

[Authorize(Roles = nameof(UserRole.Employee))]
public class EditModel : PageModel
{
    private readonly AgriEnergyConnectPlatform.Data.ApplicationDbContext _context;

    public EditModel(AgriEnergyConnectPlatform.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public AppUser AppUser { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var appuser =  await _context.AppUsers.FirstOrDefaultAsync(m => m.Id == id);
        if (appuser == null)
        {
            return NotFound();
        }
        AppUser = appuser;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more information, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(AppUser).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AppUserExists(AppUser.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool AppUserExists(string id)
    {
        return _context.AppUsers.Any(e => e.Id == id);
    }
}
