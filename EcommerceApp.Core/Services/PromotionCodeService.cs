namespace EcommerceApp.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using Core.Contracts;
    using Data;
    using EcommerceApp.Infrastructure.Data.Models;
    using EcommerceApp.Core.Models.PromotionCodes;

    public class PromotionCodeService : IPromotionCodeService
    {
        private readonly ApplicationDbContext dbContext;
        public PromotionCodeService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> CheckWheterUserReachOrdersCountAsync(Guid userId)
        {
            int userOrdersCount = await GetUserOrdersCount(userId);

            return userOrdersCount % 10 == 0 || userOrdersCount % 20 == 0;
        }

        public async Task<PromotionCodeModel> GeneratePromotionCodeForUserAsync(Guid userId)
        {
            int userOrdersCount = await GetUserOrdersCount(userId);

            PromotionCode promotionCode = new PromotionCode()
            {
                UserId = userId,
                ExpirationTime = DateTime.UtcNow.AddMonths(1),
            };

            if (userOrdersCount % 20 == 0)
            {
                promotionCode.PromotionPercentages = 25;
            }
            else
            {
                promotionCode.PromotionPercentages = 15;
            }
            await dbContext.AddAsync(promotionCode);
            await dbContext.SaveChangesAsync();

            return new PromotionCodeModel()
            {
                Id = promotionCode.Id,
                DiscountPercantages = promotionCode.PromotionPercentages,
                ExpirationTime = promotionCode.ExpirationTime
            };
        }

        private async Task<int> GetUserOrdersCount(Guid userId)
        {
            return await dbContext.Users
               .Where(u => u.Id == userId)
               .Select(u => u.Orders.Count)
               .FirstAsync();
        }
    }
}
