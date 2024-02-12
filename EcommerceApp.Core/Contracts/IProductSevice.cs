namespace EcommerceApp.Core.Contracts
{
    using Models.AdminModels.Clothes;
    using Models.Shoes;
    using Models.Products;
    using EcommerceApp.Core.Models.AdminModels.Promotion;

    public interface IProductSevice
    {
        Task<IEnumerable<ProductModel>> GetFeaturedClothesAsync(Guid? userId);
        Task<AllProductsModel> GetProductByGender(string gedner, Guid? userId);
        Task<bool> CheckIfProductExistsByIdAsync(int productId);
        Task<ProductInfo<Т>> GetProductByIdAsync<Т>(int productId, string categoryName, Guid? userId);
        Task AddProductToUserFavoritesListAsync(UserFavoriteProduct userFavoriteProductmodel);
        Task RemoveProductFromUserFavoriteListAsync(UserFavoriteProduct userFavoriteProductmodel);
        Task<ICollection<GetUserFavoriteProductModel>> GetUserFavoriteProductsAsync(Guid userId);
        Task<IEnumerable<ShoesFeatureModel>> LoadUserFavoriteProductsAsync(Guid userId);
        Task<IEnumerable<ClothesModel>> LoadAllClothesAsync();
        Task<ModifyClothesModel> GetProductToModifyAsync(int productId);
        Task EditProductAsync(EditProductModel model);
        Task ArchiveProductAsync(int productId);
        Task RestoreProductAsync(int productId);
    }
}
