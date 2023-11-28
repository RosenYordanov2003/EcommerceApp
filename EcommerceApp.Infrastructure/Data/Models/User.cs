namespace EcommerceApp.Infrastructure.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User : IdentityUser<Guid>
    {
        [ForeignKey(nameof(RefreshToken))]
        public int? RefreshTokenId { get; set; }
        public RefreshToken? RefreshToken { get; set; }
    }
}
