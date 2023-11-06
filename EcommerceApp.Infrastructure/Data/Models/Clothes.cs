namespace EcommerceApp.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static EcommerceApp.GlobalConstants.EntityValidation.ClothesEntity;

    public class Clothes
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        [Required]
        public MainCategory Category { get; set; } = null!;
        [ForeignKey(nameof(SubCategory))]
        public int? SubCategoryId { get; set; }
        [Required]
        public SubCategory? SubCategory { get; set; }
        public decimal Price { get; set; }
        [Required]
        [MaxLength(ColorMaxLength)]
        public string Color { get; set; } = null!;
        public int StarRating { get; set; }

        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }
        [Required]
        public Brand Brand { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public string Gender { get; set; } = null!;
        public bool IsFeatured { get; set; }
    }
}