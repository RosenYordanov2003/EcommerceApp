namespace EcommerceApp.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using Contracts;
    using Data;
    using Models.Brands;

    public class BrandService : IBrandService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public BrandService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<BrandModel>> LoadAllBrandsAsync()
        {
            return await applicationDbContext.Brands
                .Select(b => new BrandModel()
                {
                    Id = b.Id,
                    Name = b.Name
                })
                .ToArrayAsync();
        }
    }
}
