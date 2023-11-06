namespace EcommerceApp.Core.Contracts
{
    using Models.Products;
    public interface IClothesService
    {
        Task<IEnumerable<ProductModel>> GetFeaturedClothesAsync();
    }
}
