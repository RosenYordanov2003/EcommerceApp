namespace EcommerceApp.Core.Contracts
{
    using Infrastructure.Data.Models;

    public interface IAuthService
    {
        Task<RefreshToken> GenerateRefreshTokenAsync(string userId, string jwtId);
    }
}
