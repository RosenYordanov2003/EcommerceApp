namespace EcommerceApp.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using Data;
    using Contracts;
    using Infrastructure.Data.Models;
    using Models.PromotionCodes;
    using Core.Models.Discount;

    public class CouponService : ICouponService
    {
        private readonly ApplicationDbContext dbContext;
        public CouponService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> CheckIfCouponHasExpiredByIdAsync(Guid id)
        {
            Coupon coupon = await dbContext.Coupons.FirstAsync(pc => pc.Id == id);

            return coupon.ExpirationTime < DateTime.UtcNow;
        }

        public async Task<bool> CheckIfCouponExistByIdAsync(Guid cupponId)
        {
            return await dbContext.Coupons.AnyAsync(c => c.Id == cupponId);
        }

        public async Task<bool> CheckIfCouponIsRelatedWithParticularUserAsync(Guid cupponId, Guid userId)
        {
            return  await dbContext.Coupons.AnyAsync(c => c.Id == cupponId && c.UserId == userId);
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

        public async Task<CouponModel> GenerateCouponForUserAsync(Guid userId, decimal discount)
        {

            Coupon promotionCode = new Coupon()
            {
                UserId = userId,
                ExpirationTime = DateTime.UtcNow.AddMonths(1),
                PromotionPercentages = discount
            };

            await dbContext.AddAsync(promotionCode);
            await dbContext.SaveChangesAsync();

            return new CouponModel()
            {
                Id = promotionCode.Id,
                DiscountPercantages = promotionCode.PromotionPercentages,
                ExpirationTime = promotionCode.ExpirationTime
            };
        }

        public async Task<CouponModel> GetCouponByIdAsync(Guid id)
        {
            return await dbContext.Coupons.
                Where(pc => pc.Id == id)
                .Select(pc => new CouponModel()
                {
                    Id = pc.Id,
                    DiscountPercantages = pc.PromotionPercentages,
                    ExpirationTime = pc.ExpirationTime
                })
                .FirstAsync();
        }

        public async Task RemoveCouponByIdAsync(Guid id)
        {
            Coupon promotionCode =  await dbContext.Coupons.FirstAsync(pc => pc.Id == id);

            dbContext.Coupons.Remove(promotionCode);

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
