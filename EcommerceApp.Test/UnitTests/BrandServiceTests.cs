namespace EcommerceApp.Tests.UnitTests
{
    using Microsoft.EntityFrameworkCore;
    using Core.Contracts;
    using Data;
    using static Tests.DatabaseSeeder;
    using Core.Services;
    using System.Linq;

    [TestFixture]
    public class BrandServiceTests
    {
        private ApplicationDbContext applicationDbContext;
        private IBrandService brandService;
        private DbContextOptions<ApplicationDbContext> dbContextOptions;

        [SetUp]
        public void Setup()
        {
            dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("EcommerceAppInMemoryDatabase" + Guid.NewGuid().ToString())
               .Options;
            applicationDbContext = new ApplicationDbContext(dbContextOptions, true);
            SeedDatabase(applicationDbContext);
            brandService = new BrandService(applicationDbContext);
        }

        [Test]
        public async Task TestGetBrandIds()
        {
            var expectedBrandsIds = new List<int>() { 1, 2 };

            var actualBrandIds = await brandService.LoadAllBrandsAsync();

            CollectionAssert.AreEqual(expectedBrandsIds, actualBrandIds.Select(b => b.Id));
        }
        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Database.EnsureDeleted();
        }
    }
}