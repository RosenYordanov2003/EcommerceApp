namespace EcommerceApp.Core.Contracts
{
    using Models.AdminModels.Shoes;
    using Models.AdminModels.Clothes;
    using Models.Pager;
    using Core.Models.Products;

    public interface IShoesService
    {
        Task<IEnumerable<ProductFeatureModel>> GetFeaturedShoesAsync(Guid? userId);
        Task<IEnumerable<ClothesModel>> GetAllShoesAsync(Pager pager);
        Task<ModifyShoesModel> GetShoesToModifyAsync(int shoesId);
        Task<bool> CheckIfShoesExistsByIdAsync(int shoesId);
        Task EditShoesAsync(EditProductModel model);
        Task ArchiveShoesAsync(int shoesId);
        Task RestoreShoesAsync(int shoesId);
        Task SetFeatureShoesByIdAsync(int shoesId);
        Task RemoveFeaturedShoesByIdAsync(int shoesId);
        Task<int> GetAllShoesCountAsync();
        Task AddShoesToUserFavoriteProductsAsync(UserFavoriteProduct userFavoriteProductModel);
        Task RemoveShoesToUserFavoriteProductsAsync(UserFavoriteProduct userFavoriteProductModel);
    }
}
