namespace EcommerceApp.Core.Models.AdminModels.Clothes
{
    using System.ComponentModel.DataAnnotations;
    using static EcommerceApp.GlobalConstants.EntityValidation.ClothesEntity;
    public class EditProductModel
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        [MaxLength(DescriptionMaxLength)]
        [Required]
        public string Description { get; set; } = null!;
    }
}
