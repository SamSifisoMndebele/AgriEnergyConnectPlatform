using AgriEnergyConnectPlatform.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgriEnergyConnectPlatform.Pages.Auth;

public class Logout : PageModel
{
    public async Task<IActionResult> OnPostAsync()
    {
        await HttpContext.SignOutAsync(CookieAuthentication.AuthenticationScheme);
        return RedirectToPage("/Index");
    }

    public async Task<IActionResult> OnGetAsync()
    {
        await HttpContext.SignOutAsync(CookieAuthentication.AuthenticationScheme);
        return RedirectToPage("/Index");
    }
}