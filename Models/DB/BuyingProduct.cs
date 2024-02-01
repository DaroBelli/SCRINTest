using System.ComponentModel.DataAnnotations.Schema;

namespace SCRINTest.Models.DB;

public partial class BuyingProduct
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }

    public int? Count { get; set; }

    public DateOnly? PlacementDate { get; set; }

    public int IdClient { get; set; }

    public virtual Client ClientNavigation { get; set; } = new Client();

    public virtual ICollection<ProductsByuingProduct> ProductsByuingProducts { get; set; } = new List<ProductsByuingProduct>();
}
