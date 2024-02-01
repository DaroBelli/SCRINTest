using SCRINTest.Models.DB;
using System.Xml;


namespace SCRINTest.Controllers
{
    public static class XmlFileReader
    {
        public static void ReadAndWriteInDB()
        {
            XmlDocument xDoc = new();
            xDoc.Load(@"..\..\..\TestData.xml");

            List<BuyingProduct> orders = [];
            List<ProductsByuingProduct> productsByuingProducts = [];

            XmlNode? xRoot = xDoc.DocumentElement;
            if (xRoot != null)
            {
                ReadAndWriteInDBChildNodes(xRoot, orders, productsByuingProducts);
            }

            OrderContoller.AddOrders(orders, productsByuingProducts);
        }

        private static void ReadAndWriteInDBChildNodes(XmlNode node, List<BuyingProduct> orders, List<ProductsByuingProduct> productsByuingProducts)
        {
            foreach (XmlNode childnode in node.ChildNodes)
            {
                ActionWithNode(childnode, orders, productsByuingProducts);
            }
        }

        private static void ActionWithNode(XmlNode node, List<BuyingProduct> orders, List<ProductsByuingProduct> productsByuingProducts)
        {
            switch(node.Name)
            {
                case "order":
                    orders.Add(new BuyingProduct());
                    ReadAndWriteInDBChildNodes(node, orders, productsByuingProducts);
                    break;

                case "no":
                    orders[^1].Id = int.Parse(node.InnerText);
                    break;

                case "reg_date":
                    orders[^1].PlacementDate = DateOnly.Parse(node.InnerText);
                    break;

                case "product":
                    productsByuingProducts.Add(new ProductsByuingProduct());
                    productsByuingProducts[^1].IdProduct = ProductController.SearchOrAddProductAndGetId(GetProduct(node));
                    productsByuingProducts[^1].IdByuingProduct = orders[^1].Id;
                    break;

                case "user":
                    orders[^1].IdClient = ClientController.SearchOrAddClientAndGetId(GetClient(node));
                    break;

                default:
                    break;
            }
        }

        private static Product GetProduct(XmlNode node)
        {
            Product product = new();

            foreach (XmlNode childnode in node.ChildNodes)
            {
                switch (childnode.Name)
                {
                    case "quantity":
                        product.Count = int.Parse(childnode.InnerText);
                        break;

                    case "name":
                        product.Name = childnode.InnerText;
                        break;

                    case "price":
                        product.Price = decimal.Parse(childnode.InnerText.Replace('.',','));
                        break;

                    default:
                        break;
                }
            }

            return product;
        }

        private static Client GetClient(XmlNode node) 
        {
            Client client = new();

            foreach (XmlNode childnode in node.ChildNodes)
            {
                switch (childnode.Name)
                {
                    case "email":
                        client.Email = childnode.InnerText;
                        break;

                    case "fio":
                        client.Name = childnode.InnerText;
                        break;

                    default:
                        break;
                }
            }

            return client;
        }
    }
}
