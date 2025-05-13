using AgriEnergyConnectPlatform.Data;
using AgriEnergyConnectPlatform.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AgriEnergyConnectPlatform.Pages.Farmers;

[Authorize(Roles = nameof(UserRole.Farmer) + "," + nameof(UserRole.Employee))]
public class EditModel(ApplicationDbContext context) : PageModel
{
    [BindProperty] public AppUser AppUser { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(string? id)
    {
        if (id == null) return NotFound();

        var appuser = await context.AppUsers.FirstOrDefaultAsync(m => m.Id == id);
        if (appuser == null) return NotFound();
        AppUser = appuser;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more information, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        context.Attach(AppUser).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AppUserExists(AppUser.Id)) return NotFound();

            throw;
        }

        return RedirectToPage("./Index");
    }

    private bool AppUserExists(string id)
    {
        return context.AppUsers.Any(e => e.Id == id);
    }
}