namespace EcommerceApp.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Clothes
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        [Required]
        public Category Category { get; set; } = null!;
        public decimal Price { get; set; }
        public string Color { get; set; } = null!;

        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }
        [Required]
        public Brand Brand { get; set; } = null!;
    }
}