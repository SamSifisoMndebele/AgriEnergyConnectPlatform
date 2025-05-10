using System.Threading.Tasks;
using AgriEnergyConnectPlatform.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgriEnergyConnectPlatform.Pages.Auth;

public class Logout : PageModel
{
    public IActionResult OnGet()
    {
        if (User.Identity is { IsAuthenticated: true })
        {
            // Redirect to the home page if the user is authenticated.
            return RedirectToPage("/Index");
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await HttpContext.SignOutAsync(CookieAuthentication.AuthenticationScheme);
        return RedirectToPage("/Index");
    }
}
