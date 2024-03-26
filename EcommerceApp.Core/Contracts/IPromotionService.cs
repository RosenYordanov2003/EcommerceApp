namespace EcommerceApp.Core.Contracts
{
    using Models.AdminModels.Promotion;
    public interface IPromotionService
    {
        Task RemovePromotionAsync(Guid id);
        Task<bool> CheckIfPromotionExistsByIdAsync(Guid id);
        Task ApplyPromotionAsync(AddPromotionModel addPromotionModel);
        Task ClearExpiredPrmotionsAsync();
    }
}
