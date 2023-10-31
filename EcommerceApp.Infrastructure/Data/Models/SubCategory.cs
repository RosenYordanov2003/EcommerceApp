namespace EcommerceApp.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static EcommerceApp.GlobalConstants.EntityValidation.CategoryEntity;
    public class SubCategory
    {
        public SubCategory()
        {
            Clothes = new List<Clothes>();
            Shoes = new List<Shoes>();
        }
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(MainCategory))]
        public int MainCategoryId { get; set; }
        [Required]
        public MainCategory MainCategory { get; set; } = null!;

        [Required]
        [MaxLength(NameMaxLength)]
        public ICollection<Clothes> Clothes { get; set; }
        public ICollection<Shoes> Shoes { get; set; }
        public string Name { get; set; } = null!;
    }
}
