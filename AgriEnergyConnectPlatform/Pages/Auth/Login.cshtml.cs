using System.Security.Claims;
using AgriEnergyConnectPlatform.Data;
using AgriEnergyConnectPlatform.Models;
using AgriEnergyConnectPlatform.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgriEnergyConnectPlatform.Pages.Auth;

public class Login(ApplicationDbContext context, ILogger<IndexModel> logger) : PageModel
{
    [BindProperty] public required CredentialPasswordLogin Credential { get; set; }

    public IActionResult OnGet()
    {
        if (User.Identity is { IsAuthenticated: true })
        {
            return RedirectToPage("/Products/Index");
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();
        // ModelState.AddModelError(string.Empty, "Invalid login attempt.");

        // Verify the user credentials
        
        var users = from u in context.AppUsers select u;
        logger.LogDebug(users.ToString());
        var appUser = users.FirstOrDefault(p => p.Email == Credential.Email);
        logger.LogDebug(appUser?.ToString() ?? "null");
        if (appUser == null)
        {
            ModelState.AddModelError(
                "Credential.Email", 
                "No user with that email address.\n" +
                "Please enter a valid email address or register a new account.");
            return Page();
        }
        logger.LogInformation("User {Email} logged in.", appUser);
        if (appUser.PasswordHash != Credential.Password)
        {
            ModelState.AddModelError("Credential.Password", "Incorrect password.");
            return Page();
        }
        
        // Create Security Context
        var claims = new List<Claim>
        {
            new(MyClaimTypes.UserId, appUser.Id),
            new(ClaimTypes.Email, appUser.Email),
            new(ClaimTypes.Role, appUser.UserRole.ToString()),
            new(ClaimTypes.Name, appUser.Names),
            new(ClaimTypes.Surname, appUser.Surname),
            new(ClaimTypes.MobilePhone, appUser.PhoneNumber),
            new(ClaimTypes.StreetAddress, appUser.StreetAddress ?? string.Empty),
            new(ClaimTypes.StateOrProvince, appUser.Province ?? string.Empty),
            new(MyClaimTypes.City, appUser.City ?? string.Empty),
            new(ClaimTypes.PostalCode, appUser.PostalCode ?? string.Empty),
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

        // return LocalRedirect(Url.GetLocalUrl(returnUrl));

        // Something failed. Redisplay the form.
    }
}