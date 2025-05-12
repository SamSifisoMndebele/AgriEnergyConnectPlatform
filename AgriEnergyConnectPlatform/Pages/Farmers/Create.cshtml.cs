using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AgriEnergyConnectPlatform.Data;
using AgriEnergyConnectPlatform.Models;
using Microsoft.AspNetCore.Authorization;

namespace AgriEnergyConnectPlatform.Pages.Farmers;

[Authorize(Roles = nameof(UserRole.Employee))]
public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty] public CredentialRegister Credential { get; set; } = default!;

    // For more information, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();
        if (Credential.Password != Credential.PasswordConfirm)
        {
            ModelState.AddModelError("Credential.PasswordConfirm", "Passwords do not match.");
            return Page();
        }
        _context.AppUsers.Add(new AppUser()
        {
            Id = Guid.NewGuid().ToString(),
            Names = Credential.Names,
            City = Credential.City,
            Email = Credential.Email,
            PasswordHash = Credential.Password,
            PhoneNumber = Credential.PhoneNumber,
            PostalCode = Credential.PostalCode,
            Province = Credential.Province,
            StreetAddress = Credential.StreetAddress,
            Surname = Credential.Surname,
            UserRole = Credential.UserRole,
        });
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}