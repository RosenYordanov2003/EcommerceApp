namespace EcommerceApp.Core.Contracts
{
    using Models.Products;
    using System.Threading.Tasks.Dataflow;

    public interface IProductSevice
    {
        Task<IEnumerable<ProductModel>> GetFeaturedClothesAsync();
        Task<AllProductsModel> GetProductByGender(string gedner);
        Task<bool> CheckIfProductExistsByIdAsync(int productId);
    }
}
