using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgriEnergyConnectPlatform.Models;

public class User
{
    public int Id { get; set; }
    
    [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
    [Required, Display(Name = "First Names")]
    public string Names { get; set; }
    
    [StringLength(50, ErrorMessage = "Last Name cannot be longer than 50 characters.")]
    [Required, Display(Name = "Last Name")]
    public string LastName { get; set; }
    
    [Display(Name = "Full Name")]
    public string FullName => Names + " " + LastName;
}