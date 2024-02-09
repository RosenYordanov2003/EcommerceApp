namespace EcommerceApp.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static EcommerceApp.GlobalConstants.EntityValidation.CategoryEntity;
    public class Category
    {
        public Category()
        {
            Clothes = new List<Product>();
            Shoes = new List<Shoes>();
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
    }
}
