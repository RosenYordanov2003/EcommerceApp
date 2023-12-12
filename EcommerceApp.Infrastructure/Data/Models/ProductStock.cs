namespace EcommerceApp.Infrastructure.Data.Models
{

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static EcommerceApp.GlobalConstants.EntityValidation.ProductStockEntity;
    public class ProductStock
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        [MaxLength(SizeMaxLength)]
        public string Size { get; set; } = null!;
        public int Quantity { get; set; }

        public Product Product { get; set; } = null!;
    }
}
