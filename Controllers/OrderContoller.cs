using SCRINTest.Context;
using SCRINTest.Models.DB;

namespace SCRINTest.Controllers
{
    public static class OrderContoller
    {
        public static void AddOrders(List<BuyingProduct> orders, List<ProductsByuingProduct> productsByuingProduct)
        {
            using var db = new ScrintestContext();

            db.BuyingProducts.AddRange(orders);
            db.ProductsByuingProducts.AddRange(productsByuingProduct);

            db.SaveChanges();
        }
    }
}
