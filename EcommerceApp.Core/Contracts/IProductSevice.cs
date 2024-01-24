namespace EcommerceApp.Core.Contracts
{
    using EcommerceApp.Core.Models.Shoes;
    using Models.Products;

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
    }
}
