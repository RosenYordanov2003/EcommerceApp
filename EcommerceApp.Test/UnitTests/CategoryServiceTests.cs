namespace EcommerceApp.Tests.UnitTests
{
    using Microsoft.EntityFrameworkCore;
    using Core.Contracts;
    using Data;
    using Core.Services;
    using static Tests.DatabaseSeeder;

    [TestFixture]
    public class CategoryServiceTests
    {
        private ICategoryService categoryService;
        private ApplicationDbContext dbContext;
        private DbContextOptions<ApplicationDbContext> dbContextOptions;

        [SetUp]
        public void SetUp()
        {
            dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
              .UseInMemoryDatabase("EcommerceAppInMemoryDatabase" + Guid.NewGuid().ToString())
              .Options;
            dbContext = new ApplicationDbContext(dbContextOptions, false);
            SeedDatabase(dbContext);
            categoryService = new CategoryService(dbContext);
        }
        [Test]
        public async Task TestLoadAllCategories()
        {
            var expectedCategoryIds = new List<int>() { 1, 2, 3};
            var actualCategoires = await categoryService.LoadAllCategoriesAsync();

            CollectionAssert.AreEqual(expectedCategoryIds, actualCategoires.Select(c => c.Id));
        }
        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
        }
    }
}
