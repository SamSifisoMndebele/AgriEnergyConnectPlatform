using System.ComponentModel.DataAnnotations;

namespace AgriEnergyConnectPlatform.Models;

public class Category
{
    public int Id { get; set; }

    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    [StringLength(30)]
    [Required]
    public string Name { get; set; }

    public string? ImageUrl { get; set; }
}