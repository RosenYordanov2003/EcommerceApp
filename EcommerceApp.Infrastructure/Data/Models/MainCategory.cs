namespace EcommerceApp.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static EcommerceApp.GlobalConstants.EntityValidation.CategoryEntity;
    public class MainCategory
    {
        public MainCategory()
        {
            Clothes = new List<Product>();
            Shoes = new List<Shoes>();
            SubCategories = new List<SubCategory>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;
        [Required]
        [MaxLength(GenderMaxLength)]
        public string Gender { get; set; } = null!;
        public ICollection<Product> Clothes { get; set; }
        public ICollection<Shoes> Shoes { get; set; }
        public ICollection<SubCategory> SubCategories { get; set; }
    }
}
