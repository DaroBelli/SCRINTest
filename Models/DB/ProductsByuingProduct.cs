namespace SCRINTest.Models.DB;

public partial class ProductsByuingProduct
{
    public int Id { get; set; }

    public int? IdProduct { get; set; }

    public int? IdByuingProduct { get; set; }

    public virtual BuyingProduct ByuingProductNavigation { get; set; } = new BuyingProduct();

    public virtual Product ProductNavigation { get; set; } = new Product();
}
