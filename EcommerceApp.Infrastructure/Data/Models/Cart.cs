namespace EcommerceApp.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Cart
    {
        public Cart()
        {
            Users = new List<User>();
            ProductStocks = new List<Product>();
            ShoesStocks = new List<Shoes>();
        }
        [Key]
        public Guid Id { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Product> ProductStocks { get; set; }
        public ICollection <Shoes> ShoesStocks { get; set; }
    }
}
