namespace EcommerceApp.Core.Contracts
{
    using Models.Products;
    public interface IProductSevice
    {
        Task<IEnumerable<ProductModel>> GetFeaturedClothesAsync();
        Task<AllProductsModel> GetProductByGender(string gedner);
    }
}
