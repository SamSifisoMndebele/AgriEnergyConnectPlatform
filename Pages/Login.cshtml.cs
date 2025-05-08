using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace AgriEnergyConnectPlatform.Pages
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
            Page();
        }
    }
}
