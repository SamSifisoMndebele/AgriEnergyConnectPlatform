using System.Security.Claims;
using AgriEnergyConnectPlatform.Data;
using AgriEnergyConnectPlatform.Models;
using AgriEnergyConnectPlatform.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static BCrypt.Net.BCrypt;

namespace AgriEnergyConnectPlatform.Pages.Auth;

public class Register(ApplicationDbContext context, ILogger<IndexModel> logger) : PageModel
{
    [BindProperty] public required CredentialRegister Credential { get; set; }

    public IActionResult OnGet()
    {
        if (User.Identity is { IsAuthenticated: true }) return RedirectToPage("/Products/Index");

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();
        if (Credential.Password != Credential.PasswordConfirm)
        {
            ModelState.AddModelError("Credential.PasswordConfirm", "Passwords do not match.");
            return Page();
        }

        if (!Credential.Terms)
        {
            ModelState.AddModelError("Credential.Terms", "You must agree to the terms and conditions.");
            return Page();
        }

        var users = from u in context.AppUsers select u;
        if (users.Any(p => p.Email == Credential.Email))
        {
            ModelState.AddModelError(
                string.Empty,
                "A user with that email address already exists.\n" +
                "Please enter a different email address or login to your account.");
            return Page();
        }

        var appUser = context.AppUsers.Add(new AppUser
        {
            Id = Guid.NewGuid().ToString(),
            Email = Credential.Email,
            PasswordHash = HashPassword(Credential.Password),
            UserRole = Credential.UserRole,
            Names = Credential.Names,
            Surname = Credential.Surname,
            PhoneNumber = Credential.PhoneNumber,
            StreetAddress = Credential.StreetAddress,
            City = Credential.City,
            Province = Credential.Province,
            PostalCode = Credential.PostalCode
        });
        await context.SaveChangesAsync();

        // Create Security Context
        var claims = new List<Claim>
        {
            new(MyClaimTypes.UserId, appUser.Entity.Id),
            new(ClaimTypes.Email, appUser.Entity.Email),
            new(ClaimTypes.Role, appUser.Entity.UserRole.ToString()),
            new(ClaimTypes.Name, appUser.Entity.Names),
            new(ClaimTypes.Surname, appUser.Entity.Surname),
            new(ClaimTypes.MobilePhone, appUser.Entity.PhoneNumber),
            new(ClaimTypes.StreetAddress, appUser.Entity.StreetAddress ?? string.Empty),
            new(ClaimTypes.StateOrProvince, appUser.Entity.Province ?? string.Empty),
            new(MyClaimTypes.City, appUser.Entity.City ?? string.Empty),
            new(ClaimTypes.PostalCode, appUser.Entity.PostalCode ?? string.Empty),
            new(ClaimTypes.IsPersistent, Credential.RememberMe.ToString())
        };

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthentication.AuthenticationScheme);
        var authProperties = new AuthenticationProperties
        {
            IsPersistent = Credential.RememberMe

            //AllowRefresh = <bool>,
            // Refreshing the authentication session should be allowed.

            //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
            // The time at which the authentication ticket expires. A 
            // value set here overrides the ExpireTimeSpan option of 
            // CookieAuthenticationOptions set with AddCookie.

            //IssuedUtc = <DateTimeOffset>,
            // The time at which the authentication ticket was issued.

            //RedirectUri = <string>
            // The full path or absolute URI to be used as an http 
            // redirect response value.
        };

        await HttpContext.SignInAsync(
            CookieAuthentication.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            authProperties);

        return RedirectToPage("/Products/Index");
    }
}