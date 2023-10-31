namespace EcommerceApp.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class ShoesSizes
    {
        [ForeignKey(nameof(ShoesSize))]
        public int ShoesSizeId { get; set; }
        [Required]
        public ShoesSize ShoesSize { get; set; } = null!;
        [ForeignKey(nameof(Shoes))]
        public int ShoesId { get; set; }
        [Required]
        public Shoes Shoes { get; set; } = null!;
    }
}
