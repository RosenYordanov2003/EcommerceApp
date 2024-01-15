namespace EcommerceApp.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ProductCartEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public int Quantity { get; set; }
        [ForeignKey(nameof(Cart))]
        public Guid CartId { get; set; }
        public Cart Cart { get; set; } = null!;
        public string Size { get; set; } = null!;
    }
}
