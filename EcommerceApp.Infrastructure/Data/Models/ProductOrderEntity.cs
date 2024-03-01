namespace EcommerceApp.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    public class ProductOrderEntity
    {

        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public int Quantity { get; set; }
        [ForeignKey(nameof(Cart))]
        public string Size { get; set; } = null!;

        [ForeignKey(nameof(Order))]
        public Guid OrderId { get; set; }
        public Order Order { get; set; } = null!;
    }
}
