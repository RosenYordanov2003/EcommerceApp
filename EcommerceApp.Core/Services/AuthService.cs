namespace EcommerceApp.Core.Services
{
    using Core.Contracts;
    using EcommerceApp.Data;
    using Infrastructure.Data.Models;
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext applicationDbContext;
        public AuthService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<RefreshToken> GenerateRefreshTokenAsync(string userId, string jwtId)
        {
            RefreshToken refreshToken = new RefreshToken()
            {
                JwtId = jwtId,
                IsUsed = false,
                UserId = userId,
                CreatedDate = DateTime.UtcNow,
                ExpireData = DateTime.UtcNow.AddYears(1),
                IsRevoked = false,
                Token = Guid.NewGuid().ToString()
            };

            await applicationDbContext.RefreshTokens.AddAsync(refreshToken);
            await applicationDbContext.SaveChangesAsync();

            return refreshToken;
        }
    }
}
