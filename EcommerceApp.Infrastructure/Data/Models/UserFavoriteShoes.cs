namespace EcommerceApp.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    public class UserFavoriteShoes
    {
        [ForeignKey(nameof(Shoes))]
        public int ShoesId { get; set; }
        public Shoes Shoes { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
