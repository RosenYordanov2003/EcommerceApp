namespace EcommerceApp.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class ClothesSize
    {
        [ForeignKey(nameof(ClotheSize))]
        public int ClothesSizeId { get; set; }
        [Required]
        public ClotheSize ClotheSize { get; set; } = null!;
        [ForeignKey(nameof(Cloth))]
        public int ClothId { get; set; }
        [Required]
        public Clothes Cloth { get; set; } = null!;
        public string Gender { get; set; } = null!;
    }
}
