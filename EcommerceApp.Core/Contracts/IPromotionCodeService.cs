namespace EcommerceApp.Core.Contracts
{
    using Models.PromotionCodes;
    public interface IPromotionCodeService
    {
        Task<bool> CheckWheterUserReachOrdersCountAsync(Guid userId);

        Task<PromotionCodeModel> GeneratePromotionCodeForUserAsync(Guid userId);
    }
}
