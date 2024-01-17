namespace EcommerceApp.Core.Contracts
{
    using Models.PromotionCodes;
    public interface IPromotionCodeService
    {
        Task<bool> CheckWheterUserReachOrdersCountAsync(Guid userId);

        Task<PromotionCodeModel> GeneratePromotionCodeForUserAsync(Guid userId);
        Task<bool> CheckIfPromotionCodeExistByIdAsync(Guid cupponId);
        Task<bool> CheckIfPromotionCodeIsRelatedWithParticularUserAsync(Guid userId, Guid cupponId);
        Task<PromotionCodeModel> GetPromotionCodeByIdAsync(Guid id);
        Task RemoveCupponByIdAsync(Guid id);
        Task<bool> CheckIfCupponHasExpiredByIdAsync(Guid id);

    }
}
