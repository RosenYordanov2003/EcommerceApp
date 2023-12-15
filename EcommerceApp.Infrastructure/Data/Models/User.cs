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
        }
        [ForeignKey(nameof(RefreshToken))]
        public int? RefreshTokenId { get; set; }
        public RefreshToken? RefreshToken { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<UserFavoriteProducts> UserFavoriteProducts { get; set; }

        public ICollection<UserFavoriteShoes> UserFavoriteShoes { get; set; }

    }
}
