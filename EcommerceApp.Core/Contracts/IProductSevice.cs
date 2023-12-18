namespace EcommerceApp.Core.Contracts
{
    using Models.Products;

    public interface IProductSevice
    {
        Task<IEnumerable<ProductModel>> GetFeaturedClothesAsync();
        Task<AllProductsModel> GetProductByGender(string gedner);
        Task<bool> CheckIfProductExistsByIdAsync(int productId);
        Task<ProductInfo<Т>> GetProductByIdAsync<Т>(int productId);
        Task<bool> CheckForProductIsShoesAsync(int productId);
    }
}
