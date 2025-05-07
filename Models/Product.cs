using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgriEnergyConnectPlatform.Models;

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string Category { get; set; }
    [Display(Name = "Production Date")]
    [DataType(DataType.Date)]
    public DateTime ProductionDate { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }
    public string Rating { get; set; } = string.Empty;
}