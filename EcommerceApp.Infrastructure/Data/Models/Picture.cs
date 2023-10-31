namespace EcommerceApp.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Picture
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Cloth))]
        public int? ClothId { get; set; }
        public Clothes? Cloth { get; set; }
        [ForeignKey(nameof(Shoes))]
        public int? ShoesId { get; set; }
        public Shoes? Shoes { get; set; }
        [Required]
        public string ImgUrl { get; set; } = null!;
    }
}
