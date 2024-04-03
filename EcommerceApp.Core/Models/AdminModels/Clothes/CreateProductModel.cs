namespace EcommerceApp.Core.Models.AdminModels.Clothes
{
    using Microsoft.AspNetCore.Http;
    using Models.Brands;
    using Models.Categories;
    using System.ComponentModel.DataAnnotations;
    using static GlobalConstants.EntityValidation.ClothesEntity;
    public class CreateProductModel : EditProductModel
    {
        public CreateProductModel()
        {
            Brands = new List<BrandModel>();
            Categories = new List<CategoryModel>();
            Files = new List<IFormFile>();
        }
        [Range(minimum: StarRatingMinValue, maximum: StarRatingMaxValue)]
        public int StarRating { get; set; }
        [MinLength(GenderMinLength)]
        [MaxLength(GenderMaxLength)]
        [Required]
        public string Gender { get; set; } = null!;
        public IEnumerable<IFormFile> Files { get; set; } = null!;
        public IEnumerable<BrandModel> Brands { get; set; }
        public IEnumerable<CategoryModel> Categories { get; set; }
    }
}
