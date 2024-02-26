namespace EcommerceApp.Infrastructure.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User : IdentityUser<Guid>
    {
        public User()
        {
            Reviews = new HashSet<Review>();
            UserFavoriteProducts = new HashSet<UserFavoriteProducts>();
            UserFavoriteShoes = new HashSet<UserFavoriteShoes>();
            Orders = new List<Order>();
            PromotionCodes = new List<PromotionCode>();
            Messages = new List<UserMessage>();
        }
        [ForeignKey(nameof(RefreshToken))]
        public int? RefreshTokenId { get; set; }
        public RefreshToken? RefreshToken { get; set; }
        public ICollection<Review> Reviews { get; set; }

        [ForeignKey(nameof(Cart))]
        public Guid? CartId { get; set; }
        public Cart? Cart { get; set; }
        public ICollection<UserFavoriteProducts> UserFavoriteProducts { get; set; }
        public ICollection<UserFavoriteShoes> UserFavoriteShoes { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<PromotionCode> PromotionCodes { get; set; }
        public ICollection<UserMessage> Messages { get; set; }
    }
}
