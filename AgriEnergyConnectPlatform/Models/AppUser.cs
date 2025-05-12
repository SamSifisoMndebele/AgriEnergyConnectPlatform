using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AgriEnergyConnectPlatform.Models;

[Index(nameof(Email), IsUnique = true)]
public class AppUser
{
    [Column(TypeName = "char(36)")]
    public string Id { get; set; }

    [Column(TypeName = "varchar(256)")]
    [Required]
    public string Email { get; set; }
    
    [Required] 
    public string PasswordHash { get; set; }

    [Required] 
    public UserRole UserRole { get; set; }

    [StringLength(128, ErrorMessage = "First Names cannot be longer than 128 characters.")]
    [Column(TypeName = "varchar(128)")]
    [Required, DisplayName("First Names")]
    public string Names { get; set; }

    [StringLength(64, ErrorMessage = "Surname cannot be longer than 64 characters.")]
    [Column(TypeName = "varchar(64)")]
    [Required] public string Surname { get; set; }

    [StringLength(16, ErrorMessage = "Phone number cannot be longer than 16 characters.")]
    [RegularExpression(@"^(0|\\+?27[ -]?)[5-9]\\d[ -]?\\d{3}[ -]?\\d{4}$", ErrorMessage = "Phone number is not valid")]
    [Column(TypeName = "varchar(16)")]
    [Required, DisplayName("Phone Number")]
    public string PhoneNumber { get; set; }

    [StringLength(128, ErrorMessage = "Street Address cannot be longer than 128 characters.")]
    [Column(TypeName = "varchar(128)")]
    [DisplayName("Street Address")]
    public string? StreetAddress { get; set; } = null;

    [StringLength(128, ErrorMessage = "City cannot be longer than 128 characters.")]
    [Column(TypeName = "varchar(128)")]
    public string? City { get; set; } = null;
    
    [StringLength(16, ErrorMessage = "Province cannot be longer than 16 characters.")]
    [Column(TypeName = "varchar(16)")]
    public string? Province { get; set; } = null;

    [DisplayName("Postal Code")] public string? PostalCode { get; set; } = null;

    [DisplayName("Full Name")] public string FullName => Names.Trim() + " " + Surname.Trim();
}