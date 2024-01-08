namespace EcommerceApp.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    public class ShoesCartEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Shoes))]
        public int ShoesId { get; set; }
        public Shoes Shoes { get; set; } = null!;
        public int Quantity { get; set; }
        [ForeignKey(nameof(Cart))]
        public Guid CartId { get; set; }
        public Cart Cart { get; set; } = null!;
    }
}
