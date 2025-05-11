using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AgriEnergyConnectPlatform.Models;

public class AppUser
{
    public string Uid { get; set; }
    
    [Required]
    public string Email { get; set; }
    [Required]
    public Role Role { get; set; }
    
    [Required, DisplayName("First Names")]
    public string Names { get; set; }
    
    [Required]
    public string Surname { get; set; }
    
    [Required, DisplayName("Phone Number")]
    public string MobilePhone { get; set; }
    
    [DisplayName("Street Address")]
    public string? StreetAddress { get; set; } = null;
    
    [DisplayName("State Or Province")]
    public string? StateOrProvince { get; set; } = null;
    
    public string? Country { get; set; } = null;
    
    [DisplayName("Postal Code")]
    public string? PostalCode { get; set; } = null;
    
    [DisplayName("Photo")]
    public Uri? PhotoUri { get; set; } = null;
    
    [DisplayName("Full Name")]
    public string FullName => Names.Trim() + " " + Surname.Trim();
}