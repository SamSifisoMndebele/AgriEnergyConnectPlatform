using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgriEnergyConnectPlatform.Models;

public class Product
{
    public int Id { get; set; }

    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string? Name { get; set; }

    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    [StringLength(30)]
    [Required]
    public string Category { get; set; }

    // [Range(typeof(DateTime), "1/1/2000", "1/1/2050")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Display(Name = "Production Date")]
    [DataType(DataType.Date)]
    public DateTime ProductionDate { get; set; }

    [Range(0, 1000000)]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    [Range(0, 10)] public int Rating { get; set; } = 0;

    public DbUser Farmer { get; set; }
}