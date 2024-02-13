namespace EcommerceApp.Core.Contracts
{
    using Models.Brands;
    public interface IBrandService
    {
        Task<IEnumerable<BrandModel>> LoadAllBrandsAsync();
    }
}
