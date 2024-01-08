namespace EcommerceApp.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Cart
    {
        public Cart()
        {
            Users = new List<User>();
            ProductCartEntities = new List<ProductCartEntity>();
            ShoesCartEntities = new List<ShoesCartEntity>();
        }
        [Key]
        public Guid Id { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<ProductCartEntity> ProductCartEntities { get; set; }
        public ICollection <ShoesCartEntity> ShoesCartEntities { get; set; }
    }
}
