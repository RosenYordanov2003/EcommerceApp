namespace EcommerceApp.Core.Contracts
{
    using Infrastructure.Data.Models;
    using Microsoft.AspNetCore.Identity;

    public interface IAuthService
    {
        Task<RefreshToken> GenerateRefreshTokenAsync(Guid userId, string jwtId);

        Task<RefreshToken> FindRefreshTokenAsync(string refreshToken);
        Task <bool> CheckIsRefreshTokenExistAsync(string refreshToken);
        Task SetRefreshTokenIsUsed(string refreshToken);
        Task<User> GetUserByRefreshTokenAsync(string refreshToken);
        Task<bool> CheckIfRefreshTokenIsActiveAsync(string refreshToken);   
    }
}
