namespace EcommerceApp.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    public class Promotion
    {
        public Guid Id { get; set; }
        public decimal PercantageDiscount { get; set; }
        public DateTime ExpireTime { get; set; }
        [ForeignKey(nameof(Product))]
        public int? ProductId { get; set; }
        public Product? Product { get; set; }

        [ForeignKey(nameof(Shoes))]
        public int? ShoesId { get; set; }
        public Shoes? Shoes { get; set; }
    }
}
