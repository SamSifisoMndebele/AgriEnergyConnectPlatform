using System.Threading.Tasks;
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
}
