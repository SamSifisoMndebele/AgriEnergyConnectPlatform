using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AgriEnergyConnectPlatform.Models;

public class CredentialRegister
{
    [Required] [EmailAddress] public string Email { get; set; }

    [RegularExpression("^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[!@#$%^&*_|~`=+-]).{6,}$", 
        ErrorMessage = "Password must be at least 6 characters long, " +
                       "contain at least one uppercase letter, " +
                       "one lowercase letter, " +
                       "one number and one special character.")]
    [Required, DataType(DataType.Password)]
    public string Password { get; set; }
    
    [Required, DataType(DataType.Password)]
    public string PasswordConfirm { get; set; }

    [Required, DisplayName("User Role")] 
    public UserRole UserRole { get; set; } = UserRole.Farmer;

    [StringLength(128, ErrorMessage = "First Names cannot be longer than 128 characters.")]
    [Required, DisplayName("First Names")]
    public string Names { get; set; }

    [StringLength(64, ErrorMessage = "Surname cannot be longer than 64 characters.")]
    [Required] public string Surname { get; set; }

    [StringLength(16, ErrorMessage = "Phone number cannot be longer than 16 characters.")]
    // [RegularExpression(@"^(0|\+?27[ -]?)[5-9]\d[ -]?\d{3}[ -]?\d{4}$", ErrorMessage = "Phone number is not valid")]
    [Required, DisplayName("Phone Number"), DataType(DataType.PhoneNumber)]
    public string PhoneNumber { get; set; }

    [StringLength(128, ErrorMessage = "Street Address cannot be longer than 128 characters.")]
    [DisplayName("Street Address"), DataType(DataType.MultilineText)]
    public string? StreetAddress { get; set; } = null;

    [StringLength(128, ErrorMessage = "City cannot be longer than 128 characters.")]
    public string? City { get; set; } = null;
    
    [StringLength(16, ErrorMessage = "Province cannot be longer than 16 characters.")]
    public string? Province { get; set; } = null;

    [DisplayName("Postal Code"), DataType(DataType.PostalCode)] public string? PostalCode { get; set; } = null;
    
    [Required] public bool Terms { get; set; } = false;

    [Required, DisplayName("Remember Me")] public bool RememberMe { get; set; } = false;
}