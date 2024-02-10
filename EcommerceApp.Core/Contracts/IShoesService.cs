namespace EcommerceApp.Core.Contracts
{
    using Models.AdminModels.Shoes;
    using Models.AdminModels.Clothes;
    using Models.Shoes;
    public interface IShoesService
    {
        Task<IEnumerable<ShoesFeatureModel>> GetFeaturedShoesAsync(Guid? userId);
        Task<IEnumerable<ClothesModel>> GetAllShoesAsync();
        Task<ModifyShoesModel> GetShoesToModifyAsync(int shoesId);
        Task<bool> CheckIfShoesExistsByIdAsync(int shoesId);
    }
}
