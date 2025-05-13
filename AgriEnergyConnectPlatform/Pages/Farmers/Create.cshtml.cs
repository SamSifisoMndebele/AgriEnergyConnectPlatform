using AgriEnergyConnectPlatform.Data;
using AgriEnergyConnectPlatform.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static BCrypt.Net.BCrypt;

namespace AgriEnergyConnectPlatform.Pages.Farmers;

[Authorize(Roles = nameof(UserRole.Employee))]
public class CreateModel(ApplicationDbContext context) : PageModel
{
    [BindProperty] public CredentialRegister Credential { get; set; } = default!;

    public IActionResult OnGet()
    {
        return Page();
    }

    // For more information, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();
        if (Credential.Password != Credential.PasswordConfirm)
        {
            ModelState.AddModelError("Credential.PasswordConfirm", "Passwords do not match.");
            return Page();
        }

        context.AppUsers.Add(new AppUser
        {
            Id = Guid.NewGuid().ToString(),
            Names = Credential.Names,
            City = Credential.City,
            Email = Credential.Email,
            PasswordHash = HashPassword(Credential.Password),
            PhoneNumber = Credential.PhoneNumber,
            PostalCode = Credential.PostalCode,
            Province = Credential.Province,
            StreetAddress = Credential.StreetAddress,
            Surname = Credential.Surname,
            UserRole = Credential.UserRole
        });
        await context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}