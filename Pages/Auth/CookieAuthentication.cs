namespace AgriEnergyConnectPlatform.Pages.Auth;

/// <summary>
/// Default values related to cookie-based authentication handler
/// </summary>
public static class CookieAuthentication
{
    /// <summary>
    /// The default value used for CookieAuthenticationOptions.AuthenticationScheme
    /// </summary>
    public const string AuthenticationScheme = "Cookies";
    /// <summary>
    /// The prefix used to provide a default CookieAuthenticationOptions.CookieName
    /// </summary>
    public static readonly string CookiePrefix = ".Auth.";
    /// <summary>
    /// The default value used by CookieAuthenticationMiddleware for the
    /// CookieAuthenticationOptions.LoginPath
    /// </summary>
    public static readonly PathString LoginPath = new("/Auth/Login");
    /// <summary>
    /// The default value used by CookieAuthenticationMiddleware for the
    /// CookieAuthenticationOptions.LogoutPath
    /// </summary>
    public static readonly PathString LogoutPath = new("/Auth/Logout");
    /// <summary>
    /// The default value used by CookieAuthenticationMiddleware for the
    /// CookieAuthenticationOptions.AccessDeniedPath
    /// </summary>
    public static readonly PathString AccessDeniedPath = new("/Auth/AccessDenied");
    /// <summary>
    /// The default value of the CookieAuthenticationOptions.ReturnUrlParameter
    /// </summary>
    public static readonly string ReturnUrlParameter = "ReturnUrl";
}
