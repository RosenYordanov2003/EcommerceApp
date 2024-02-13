namespace EcommerceApp.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static EcommerceApp.GlobalConstants.EntityValidation.ClothesEntity;
    public class Shoes
    {
        public Shoes()
        {
            Pictures = new List<Picture>();
            UserFavoriteShoes = new HashSet<UserFavoriteShoes>();
            Reviews = new HashSet<Review>();
            ShoesStocks = new List<ShoesStock>();
            ShoesCartEntities = new List<ShoesCartEntity>();
        }
        public int Id { get; set; }
        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }
        [Required]
        public Brand Brand { get; set; } = null!;
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int StarRating { get; set; }
        public bool IsArchived { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        [Required]
        public Category Category { get; set; } = null!;
        public ICollection<Picture> Pictures { get; set; }

        [Required]
        [MaxLength(GenderMaxLength)]
        public string Gender { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsFeatured { get; set; }

        public Guid? PromotionId { get; set; }
        public Promotion? Promotion { get; set; }

        public ICollection<UserFavoriteShoes> UserFavoriteShoes { get; set; }
        public ICollection<Review> Reviews { get; set; }

        public ICollection<ShoesStock> ShoesStocks { get; set; }
        public ICollection<ShoesCartEntity> ShoesCartEntities { get; set; }
    }
}
