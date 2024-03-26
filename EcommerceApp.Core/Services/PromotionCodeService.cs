namespace EcommerceApp.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using Data;
    using Contracts;
    using Infrastructure.Data.Models;
    using Models.PromotionCodes;
    using Core.Models.Discount;

    public class PromotionCodeService : IPromotionCodeService
    {
        private readonly ApplicationDbContext dbContext;
        public PromotionCodeService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> CheckIfCupponHasExpiredByIdAsync(Guid id)
        {
            PromotionCode promotionCode = await dbContext.PromotionCodes.FirstAsync(pc => pc.Id == id);

            return promotionCode.ExpirationTime > DateTime.UtcNow;
        }

        public async Task<bool> CheckIfPromotionCodeExistByIdAsync(Guid cupponId)
        {
            return await dbContext.PromotionCodes.AnyAsync(c => c.Id == cupponId);
        }

        public async Task<bool> CheckIfPromotionCodeIsRelatedWithParticularUserAsync(Guid cupponId, Guid userId)
        {
            return  await dbContext.PromotionCodes.AnyAsync(c => c.Id == cupponId && c.UserId == userId);
        }

        public async Task<decimal> CheckWheterUserReachesDiscount(Guid userId)
        {
            int userOrdersCount = await GetUserOrdersCount(userId);
            NewClientDiscountHandler newClientDiscountHandler = new NewClientDiscountHandler();
            TwentyPercentageDiscountHandler twentyPercentDiscountHandler = new TwentyPercentageDiscountHandler();
            newClientDiscountHandler.SetNextDiscountHandler(twentyPercentDiscountHandler);
            twentyPercentDiscountHandler.SetNextDiscountHandler(new TenPercentageDiscountHandler());


            decimal promotion = newClientDiscountHandler.GetDiscount(userOrdersCount);

            return promotion;
        }

        public async Task<PromotionCodeModel> GeneratePromotionCodeForUserAsync(Guid userId, decimal discount)
        {

            PromotionCode promotionCode = new PromotionCode()
            {
                UserId = userId,
                ExpirationTime = DateTime.UtcNow.AddMonths(1),
                PromotionPercentages = discount
            };

            await dbContext.AddAsync(promotionCode);
            await dbContext.SaveChangesAsync();

            return new PromotionCodeModel()
            {
                Id = promotionCode.Id,
                DiscountPercantages = promotionCode.PromotionPercentages,
                ExpirationTime = promotionCode.ExpirationTime
            };
        }

        public async Task<PromotionCodeModel> GetPromotionCodeByIdAsync(Guid id)
        {
            return await dbContext.PromotionCodes.
                Where(pc => pc.Id == id)
                .Select(pc => new PromotionCodeModel()
                {
                    Id = pc.Id,
                    DiscountPercantages = pc.PromotionPercentages,
                    ExpirationTime = pc.ExpirationTime
                })
                .FirstAsync();
        }

        public async Task RemoveCupponByIdAsync(Guid id)
        {
            PromotionCode promotionCode =  await dbContext.PromotionCodes.FirstAsync(pc => pc.Id == id);

            dbContext.PromotionCodes.Remove(promotionCode);

            await dbContext.SaveChangesAsync();
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
