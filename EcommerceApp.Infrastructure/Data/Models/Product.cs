﻿namespace EcommerceApp.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static EcommerceApp.GlobalConstants.EntityValidation.ClothesEntity;

    public class Product
    {
        public Product()
        {
            Pictures = new List<Picture>();
            ProductStocks = new List<ProductStock>();
            UserFavoriteProducts = new HashSet<UserFavoriteProducts>();
            Reviews = new HashSet<Review>();
            ProductCartEntities = new List<ProductCartEntity>();
        }
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
        public ICollection<Picture> Pictures { get; set; }
        public ICollection<ProductStock> ProductStocks { get; set; }
        public ICollection<UserFavoriteProducts> UserFavoriteProducts { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<ProductCartEntity> ProductCartEntities { get; set; }
    }
}