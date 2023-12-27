namespace EcommerceApp.Core.Contracts
{
    using Models.Shoes;
    public interface IShoesService
    {
        Task<IEnumerable<ShoesFeatureModel>> GetFeaturedShoesAsync(Guid? userId);
    }
}
