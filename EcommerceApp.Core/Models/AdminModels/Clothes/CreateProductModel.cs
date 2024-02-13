namespace EcommerceApp.Core.Models.AdminModels.Clothes
{
    using Microsoft.AspNetCore.Http;
    using Models.Brands;
    using Models.Categories;
    using System.ComponentModel.DataAnnotations;
    using static GlobalConstants.EntityValidation.ClothesEntity;
    public class CreateProductModel
    {
        public CreateProductModel()
        {
            Brands = new List<BrandModel>();
            Categories = new List<CategoryModel>();
            ImgFiles = new List<IFormFile>();
        }

        [MaxLength(DescriptionMaxLength)]
        public string? Description { get; set; }

        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        [Required]
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }

        [Range(minimum: StarRatingMinValue, maximum: StarRatingMaxValue)]
        public int StarRating { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        [MinLength(GenderMinLength)]
        [MaxLength(GenderMaxLength)]
        [Required]
        public string Gender { get; set; } = null!;
        public IEnumerable<IFormFile> ImgFiles { get; set; } = null!;
        public IEnumerable<BrandModel> Brands { get; set; }
        public IEnumerable<CategoryModel> Categories { get; set; }
    }
}
