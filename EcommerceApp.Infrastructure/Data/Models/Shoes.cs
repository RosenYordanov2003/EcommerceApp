namespace EcommerceApp.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Shoes
    {
        public Shoes()
        {
            Pictures = new List<Picture>();
        }
        public int Id { get; set; }
        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }
        [Required]
        public Brand Brand { get; set; } = null!;
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        [Required]
        public string Color { get; set; } = null!;
        public int StarRating { get; set; }

        [ForeignKey(nameof(Category))]
        public int SubCategoryId { get; set; }
        [Required]
        public SubCategory SubCategory { get; set; } = null!;
        public int CategoryId { get; set; }
        [Required]
        public MainCategory Category { get; set; } = null!;
        public ICollection<Picture> Pictures { get; set; }
    }
}
