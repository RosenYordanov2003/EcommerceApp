namespace EcommerceApp.Core.Contracts
{
    using Models.PromotionCodes;
    public interface ICouponService
    {
        Task<decimal> CheckWheterUserReachesDiscount(Guid userId);

        Task<CouponModel> GenerateCouponForUserAsync(Guid userId, decimal discount);
        Task<bool> CheckIfCouponExistByIdAsync(Guid cupponId);
        Task<bool> CheckIfCouponIsRelatedWithParticularUserAsync(Guid userId, Guid cupponId);
        Task<CouponModel> GetCouponByIdAsync(Guid id);
        Task RemoveCouponByIdAsync(Guid id);
        Task<bool> CheckIfCouponHasExpiredByIdAsync(Guid id);

    }
}
