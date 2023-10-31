namespace EcommerceApp.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Category
    {
        public Category()
        {
            Clothes = new List<Clothes>();
            Shoes = new List<Shoes>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public ICollection<Clothes> Clothes { get; set; }
        public ICollection<Shoes> Shoes { get; set; }
    }
}
