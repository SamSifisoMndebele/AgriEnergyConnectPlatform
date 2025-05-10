using System.ComponentModel.DataAnnotations;

namespace AgriEnergyConnectPlatform.Models;

public class PasswordCredential
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}