using SCRINTest.Context;
using SCRINTest.Models.DB;

namespace SCRINTest.Controllers
{
    public static class ProductController
    {
        public static int SearchOrAddProductAndGetId(Product product)
        {
            using var db = new ScrintestContext();

            int id = db.Products.Where(x => x.Name == product.Name).Select(x => x.Id).FirstOrDefault();

            if (id == 0)
            {
                db.Products.Add(product);
                db.SaveChanges();
                id = product.Id;
            }

            return id;
        }
    }
}
