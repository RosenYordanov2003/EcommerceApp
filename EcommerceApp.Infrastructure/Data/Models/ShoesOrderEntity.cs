namespace EcommerceApp.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    public class ShoesOrderEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Shoes))]
        public int ShoesId { get; set; }
        public Shoes Shoes { get; set; } = null!;
        public int Quantity { get; set; }
        public int Size { get; set; }
        [ForeignKey(nameof(Order))]
        public Guid OrderId { get; set; }
        public Order Order { get; set; } = null!;
    }
}
