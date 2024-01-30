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

        public async Task<bool> CheckIfRefreshTokenIsActiveAsync(string refreshToken)
        {
            RefreshToken refreshTokenToCheck = await applicationDbContext.RefreshTokens.FirstAsync(rt => rt.Token == refreshToken);

            return refreshTokenToCheck.ExpireData > DateTime.UtcNow;
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

        public async Task<RefreshToken> GenerateRefreshTokenAsync(Guid userId, string jwtId)
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
            User user = await applicationDbContext.Users.Include(u => u.RefreshToken).FirstOrDefaultAsync(u => u.Id == userId);
            if (user.RefreshToken != null)
            {
                await DeleteUserRefreshToken(user);
            }
            user.RefreshToken = refreshToken;
            user.RefreshTokenId = refreshToken.Id;

            await applicationDbContext.RefreshTokens.AddAsync(refreshToken);
            await applicationDbContext.SaveChangesAsync();

            return refreshToken;
        }

        private async Task DeleteUserRefreshToken(User user)
        {
            applicationDbContext.RefreshTokens.Remove(user.RefreshToken);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<User> GetUserByRefreshTokenAsync(string refreshToken)
        {
            return await applicationDbContext.RefreshTokens.Where(rt => rt.Token == refreshToken)
                .Select(rt => rt.User)
                .FirstOrDefaultAsync();
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
