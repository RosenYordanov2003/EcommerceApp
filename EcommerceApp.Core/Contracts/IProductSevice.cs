namespace EcommerceApp.Core.Contracts
{
    using Models.Products;

    public interface IProductSevice
    {
        Task<IEnumerable<ProductModel>> GetFeaturedClothesAsync();
        Task<AllProductsModel> GetProductByGender(string gedner);
        Task<bool> CheckIfProductExistsByIdAsync(int productId);
        Task<ProductInfo<Т>> GetProductByIdAsync<Т>(int productId, string categoryName, Guid userId);
        Task AddProductToUserFavoritesListAsync(UserFavoriteProduct userFavoriteProductmodel);
        Task RemoveProductFromUserFavoriteListAsync(UserFavoriteProduct userFavoriteProductmodel);
    }
}
