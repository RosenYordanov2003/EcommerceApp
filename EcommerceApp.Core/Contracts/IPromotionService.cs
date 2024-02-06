namespace EcommerceApp.Core.Contracts
{
    public interface IPromotionService
    {
        Task RemovePromotionAsync(Guid id);
        Task<bool> CheckIfPromotionExistsByIdAsync(Guid id);
    }
}
