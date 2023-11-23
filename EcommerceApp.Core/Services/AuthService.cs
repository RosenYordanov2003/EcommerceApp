namespace EcommerceApp.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using Core.Contracts;
    using EcommerceApp.Data;
    using Infrastructure.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using System.Security.Cryptography;

    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext applicationDbContext;
        public AuthService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<bool> CheckIsRefreshTokenExistAsync(string refreshToken)
        {
            return await applicationDbContext.RefreshTokens.FirstOrDefaultAsync(rt => rt.Token == refreshToken) != null;
        }

        public async Task<RefreshToken> FindRefreshTokenAsync(string refreshToken)
        {
            RefreshToken refreshTokenToFind = await applicationDbContext.RefreshTokens.FirstOrDefaultAsync(rt => rt.Token == refreshToken);

            return refreshTokenToFind;
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

        public async Task SetRefreshTokenIsUsed(string refreshToken)
        {
            if (await CheckIsRefreshTokenExistAsync(refreshToken))
            {
                RefreshToken tokenToFind = await FindRefreshTokenAsync(refreshToken);
                tokenToFind.IsUsed = true;
                await applicationDbContext.SaveChangesAsync();
            }
        }
    }
}
