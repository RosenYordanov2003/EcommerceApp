namespace EcommerceApp.Infrastructure.Data.Models
{
    public class Promotion
    {
        public Guid Id { get; set; }
        public decimal PercantageDiscount { get; set; }
        public DateTime ExpireTime { get; set; }
        public Product? Product { get; set; }
        public Shoes? Shoes { get; set; }
    }
}
