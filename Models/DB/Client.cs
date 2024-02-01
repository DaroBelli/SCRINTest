using System.ComponentModel.DataAnnotations;

namespace SCRINTest.Models.DB
{
    public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; } = string.Empty;

        public string? Address {  get; set; }

        public string? PaymentDetails { get; set; }

        public virtual ICollection<BuyingProduct> BuyingProducts { get; set; } = new List<BuyingProduct>();
    }
}
