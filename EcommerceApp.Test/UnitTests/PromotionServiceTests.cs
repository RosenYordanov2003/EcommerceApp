namespace EcommerceApp.Tests.UnitTests
{
    using Microsoft.EntityFrameworkCore;
    using Core.Contracts;
    using Data;
    using Core.Services;
    using static Tests.DatabaseSeeder;
    using Core.Models.AdminModels.Promotion;

    public class PromotionServiceTests
    {
        private IPromotionService promotionService;
        private ApplicationDbContext applicationDbContext;
        private DbContextOptions<ApplicationDbContext> dbContextOptions;

        [SetUp]
        public void SetUp()
        {
            dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                 .UseInMemoryDatabase("EcommerceAppInMemoryDatabase" + Guid.NewGuid().ToString())
              .Options;
            applicationDbContext = new ApplicationDbContext(dbContextOptions, false);
            SeedDatabase(applicationDbContext);
            promotionService = new PromotionService(applicationDbContext);
        }
        [Test]
        public async Task TestApplyPromotionAsync()
        {
            AddPromotionModel model = new AddPromotionModel()
            {
                Percentages = 20,
                ProductCategory = "Shoes",
                ProductId = 2,
                ExpirationTime = new DateTime(2024, 10, 8)
            };
            await promotionService.ApplyPromotionAsync(model);
            var result = await applicationDbContext.Promotions.FirstAsync(p => p.ShoesId == 2);

            Assert.That(result.PercantageDiscount, Is.EqualTo(model.Percentages));
            Assert.That(result.ExpireTime, Is.EqualTo(model.ExpirationTime));
        }
        [Test]
        public async Task TestApplyPromotionAsync2()
        {
            AddPromotionModel model = new AddPromotionModel()
            {
                Percentages = 20,
                ProductCategory = "T-Shirts",
                ProductId = 1,
                ExpirationTime = new DateTime(2024, 10, 8)
            };
            await promotionService.ApplyPromotionAsync(model);
            var result = await applicationDbContext.Promotions.FirstAsync(p => p.ProductId == 1);

            Assert.That(result.PercantageDiscount, Is.EqualTo(model.Percentages));
            Assert.That(result.ExpireTime, Is.EqualTo(model.ExpirationTime));
        }
        [Test]
        public async Task TestRemoveOldPromotionsShouldWork()
        {
            AddPromotionModel model = new AddPromotionModel()
            {
                Percentages = 20,
                ProductCategory = "T-Shirts",
                ProductId = 1,
                ExpirationTime = new DateTime(2024, 10, 8)
            };
            await promotionService.ApplyPromotionAsync(model);
            var result = await applicationDbContext.Promotions.FirstOrDefaultAsync(p => p.ProductId == 1);

            Assert.IsNotNull(result);

            await promotionService.RemovePromotionAsync(result.Id);

            var resultAfterDelete = await applicationDbContext.Promotions.FirstOrDefaultAsync(p => p.ProductId == 1);

            Assert.IsNull(resultAfterDelete);
        }
        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Database.EnsureDeleted();
        }
    }
}
