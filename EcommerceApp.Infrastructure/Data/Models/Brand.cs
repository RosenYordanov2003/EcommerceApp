namespace EcommerceApp.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Brand
    {
        public Brand()
        {
            Products = new List<Clothes>();
            Shoes = new List<Shoes>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Clothes> Products { get; set; }
        public ICollection<Shoes> Shoes { get; set; }
    }
}