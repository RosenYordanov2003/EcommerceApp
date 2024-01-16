namespace EcommerceApp.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Cart
    {
        public Cart()
        {
            ProductCartEntities = new List<ProductCartEntity>();
            ShoesCartEntities = new List<ShoesCartEntity>();
        }
        [Key]
        public Guid Id { get; set; }
        public User User { get; set; } = null!;
        public ICollection<ProductCartEntity> ProductCartEntities { get; set; }
        public ICollection <ShoesCartEntity> ShoesCartEntities { get; set; }
    }
}
