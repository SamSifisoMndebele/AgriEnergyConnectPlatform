using AgriEnergyConnectPlatform.Data;
using AgriEnergyConnectPlatform.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AgriEnergyConnectPlatform.Pages.Farmers;

[Authorize(Roles = nameof(UserRole.Employee))]
public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public AppUser AppUser { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(string id)
    {
        if (id == null) return NotFound();

        var appuser = await _context.AppUsers.FirstOrDefaultAsync(m => m.Id == id);

        if (appuser is not null)
        {
            AppUser = appuser;

            return Page();
        }

        return NotFound();
    }

    public async Task<IActionResult> OnPostAsync(string? id)
    {
        if (id == null) return NotFound();

        var appuser = await _context.AppUsers.FindAsync(id);
        if (appuser != null)
        {
            AppUser = appuser;
            _context.AppUsers.Remove(AppUser);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}