namespace EcommerceApp.Infrastructure.Data.Models
{
    public class Promotion
    {
        public Promotion()
        {
            Clothes = new List<Product>();
            Shoes = new List<Shoes>();
        }
        public Guid Id { get; set; }
        public decimal PercantageDiscount { get; set; }
        public DateTime ExpireTime { get; set; }
        public ICollection<Product> Clothes { get; set; }
        public ICollection<Shoes> Shoes { get; set; }
    }
}
