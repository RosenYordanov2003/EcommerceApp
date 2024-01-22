namespace EcommerceApp.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Cart
    {
        public Cart()
        {
            ProductCartEntities = new List<ProductCartEntity>();
            ShoesCartEntities = new List<ShoesCartEntity>();
        }
        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(User))]
        public Guid? UserId { get; set; }
        public User? User { get; set; }
        public ICollection<ProductCartEntity> ProductCartEntities { get; set; }
        public ICollection <ShoesCartEntity> ShoesCartEntities { get; set; }
    }
}
