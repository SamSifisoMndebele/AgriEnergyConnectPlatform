using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AgriEnergyConnectPlatform.Models;

public class AppUser
{
    public string Id { get; set; }

    [Required] public string Email { get; set; }

    [Required] public Role Role { get; set; }

    [StringLength(30, ErrorMessage = "First Names cannot be longer than 30 characters.")]
    [Required, DisplayName("First Names")]
    public string Names { get; set; }

    [StringLength(20, ErrorMessage = "Surname cannot be longer than 20 characters.")]
    [Required] public string Surname { get; set; }

    [RegularExpression(@"^(0|\\+?27[ -]?)[5-9]\\d[ -]?\\d{3}[ -]?\\d{4}$", ErrorMessage = "Phone number is not valid")]
    [Required, DisplayName("Phone Number")]
    public string PhoneNumber { get; set; }

    [DisplayName("Street Address")] public string? StreetAddress { get; set; } = null;
    
    public string? Province { get; set; } = null;

    public string? Country { get; set; } = null;

    [DisplayName("Postal Code")] public string? PostalCode { get; set; } = null;

    [DisplayName("Photo")] public Uri? PhotoUri { get; set; } = null;

    [DisplayName("Full Name")] public string FullName => Names.Trim() + " " + Surname.Trim();
}