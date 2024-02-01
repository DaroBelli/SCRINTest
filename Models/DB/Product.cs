using System.ComponentModel.DataAnnotations;

namespace SCRINTest.Models.DB;

public partial class Product
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public string? UnitMeasurement { get; set; }

    public decimal Price { get; set; }

    public float Count { get; set; }

    public virtual ICollection<ProductsByuingProduct> ProductsByuingProducts { get; set; } = new List<ProductsByuingProduct>();
}
