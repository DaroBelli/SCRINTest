using SCRINTest.Context;
using SCRINTest.Models.DB;

namespace SCRINTest.Controllers
{
    public class ClientController
    {
        public static int SearchOrAddClientAndGetId (Client client)
        {
            using var db = new ScrintestContext();

            int id = db.Clients.Where(x => x.Email == client.Email).Select(x => x.Id).FirstOrDefault();

            if (id == 0)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                id = client.Id;
            }

            return id;
        }
    }
}
