using System.ComponentModel.DataAnnotations.Schema;

namespace SCRINTest.Models.DB;

public partial class ProductsByuingProduct
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int? IdProduct { get; set; }

    public int? IdByuingProduct { get; set; }

    public virtual BuyingProduct? ByuingProductNavigation { get; set; }

    public virtual Product? ProductNavigation { get; set; }
}
