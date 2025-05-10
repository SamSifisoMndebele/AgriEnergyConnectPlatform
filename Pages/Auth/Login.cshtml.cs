using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using AgriEnergyConnectPlatform.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgriEnergyConnectPlatform.Pages.Auth;

public class Login : PageModel
{
    [BindProperty]
    public Credential Credential { get; set; }
    
    public void OnGet()
    {
        
    }

    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid) return Page();
        // ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        
        // Verify the user credentials
        if (Credential is { Email: "user@mail.com", Password: "Password" })
        {
            // Create Security Context
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "user@mail.com"),
                new Claim(ClaimTypes.Email, "user@mail.com"),
                new Claim("FullName", "Sam Sifiso Mndebele"),
                new Claim(ClaimTypes.Role, "Administrator"),
            };
            
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthentication.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                //AllowRefresh = <bool>,
                // Refreshing the authentication session should be allowed.

                //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                // The time at which the authentication ticket expires. A 
                // value set here overrides the ExpireTimeSpan option of 
                // CookieAuthenticationOptions set with AddCookie.

                //IsPersistent = true,
                // Whether the authentication session is persisted across 
                // multiple requests. When used with cookies, controls
                // whether the cookie's lifetime is absolute (matching the
                // lifetime of the authentication ticket) or session-based.

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
        }

        // Something failed. Redisplay the form.
        return Page();
    }
}
    
public class Credential
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}