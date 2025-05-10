using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
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
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            
            await HttpContext.SignInAsync(CookieAuthentication.AuthenticationScheme, claimsPrincipal);
            
            return RedirectToPage("/Index");
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