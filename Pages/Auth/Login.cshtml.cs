using System.Security.Claims;
using AgriEnergyConnectPlatform.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgriEnergyConnectPlatform.Pages.Auth;

public class Login : PageModel
{
    [BindProperty] public required PasswordCredential Credential { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();
        // ModelState.AddModelError(string.Empty, "Invalid login attempt.");

        // Verify the user credentials
        if (Credential is not { Email: "sams.mndebele@gmail.com", Password: "Password" }) return Page();
        var appUser = new AppUser
        {
            Uid = Guid.NewGuid().ToString(),
            Email = Credential.Email,
            Role = Role.Farmer,
            Names = "Sam Sifiso",
            Surname = "Mndebele",
            MobilePhone = "0721646430",
            StreetAddress = "Stand 104 Clau-Clau",
            StateOrProvince = "Mpumalanga",
            Country = "South Africa",
            PostalCode = "1245"
        };
        // Create Security Context
        var claims = new List<Claim>
        {
            new("UID", appUser.Uid),
            new(ClaimTypes.Email, appUser.Email),
            new(ClaimTypes.Role, appUser.Role.ToString()),
            new(ClaimTypes.Name, appUser.Names),
            new(ClaimTypes.Surname, appUser.Surname),
            new(ClaimTypes.MobilePhone, appUser.MobilePhone),
            new(ClaimTypes.StreetAddress, appUser.StreetAddress),
            new(ClaimTypes.StateOrProvince, appUser.StateOrProvince),
            new(ClaimTypes.Country, appUser.Country),
            new(ClaimTypes.PostalCode, appUser.PostalCode),
            new("PhotoUrl", appUser.PhotoUri?.ToString() ?? string.Empty),
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

        return RedirectToPage("/Index");

        // return LocalRedirect(Url.GetLocalUrl(returnUrl));

        // Something failed. Redisplay the form.
    }
}