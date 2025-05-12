using System.Globalization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AgriEnergyConnectPlatform.Data;
using AgriEnergyConnectPlatform.Models;
using Microsoft.AspNetCore.Localization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connectionString));
// var connectionString = builder.Configuration.GetConnectionString("LocalDbConnection")
//                        ?? throw new InvalidOperationException("Connection string not found.");
// builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddAuthentication(CookieAuthentication.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.SlidingExpiration = true;
        options.Cookie.Name = CookieAuthentication.CookiePrefix + CookieAuthentication.AuthenticationScheme;
        options.LoginPath = CookieAuthentication.LoginPath;
        options.LogoutPath = CookieAuthentication.LogoutPath;
        options.AccessDeniedPath = CookieAuthentication.AccessDeniedPath;
        options.ReturnUrlParameter = CookieAuthentication.ReturnUrlParameter;
        // options.EventsType = typeof(CustomCookieAuthenticationEvents);
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(nameof(UserRole.Farmer), policy => policy.RequireRole(nameof(UserRole.Employee), nameof(UserRole.Farmer)));
    options.AddPolicy(nameof(UserRole.Employee), policy => policy.RequireRole(nameof(UserRole.Employee)));
});

builder.Services.AddRazorPages(options =>
{
    // options.Conventions.AuthorizeFolder("/Products");
    // options.Conventions.AuthorizeFolder("/Products", nameof(UserRole.Farmer));
    // options.Conventions.AuthorizeFolder("/Farmers", nameof(UserRole.Employee));
    // options.Conventions.AuthorizeFolder("/Farmers", nameof(UserRole.Employee));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages().WithStaticAssets();

var defaultCulture = new CultureInfo("en-US");
var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(defaultCulture),
    SupportedCultures = new List<CultureInfo> { defaultCulture },
    SupportedUICultures = new List<CultureInfo> { defaultCulture }
};
app.UseRequestLocalization(localizationOptions);

app.Run();