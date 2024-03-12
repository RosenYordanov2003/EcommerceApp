namespace EcommerceApp.Tests.UnitTests
{
    using Microsoft.EntityFrameworkCore;
    using Core.Contracts;
    using Core.Services;
    using Data;
    using static Tests.DatabaseSeeder;

    [TestFixture]
    public class ShoesServiceTests
    {
        private IShoesService shoesService;
        private ApplicationDbContext dbContext;
        private DbContextOptions<ApplicationDbContext> dbContextOptions;

        [SetUp]
        public void SetUp()
        {
            shoesService = new ShoesService(dbContext);
            dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
              .UseInMemoryDatabase("EcommerceAppInMemoryDatabase" + Guid.NewGuid().ToString())
              .Options;
            dbContext = new ApplicationDbContext(dbContextOptions, true);
            SeedDatabase(dbContext);
            shoesService = new ShoesService(dbContext);
        }
        [Test]
        public async Task TestArchiveShoesShouldReturnTrue()
        {
            var expectedResult = true;
            await shoesService.ArchiveShoesAsync(1);
            Assert.That(shoes1.IsArchived, Is.EqualTo(expectedResult));
        }
        [Test]
        public void TestArchiveMethodShouldNotBeArchived()
        {
            var expectedResult = false;
            Assert.That(shoes1.IsArchived, Is.EqualTo(expectedResult));
        }
        [Test]
        public async Task TestArchivedShesMethodShouldReturnFalse()
        {
            var expectedResult = false;
            await shoesService.ArchiveShoesAsync(1);
            await shoesService.RestoreShoesAsync(1);
            Assert.That(shoes1.IsArchived, Is.EqualTo(expectedResult));
        }
        [Test]
        public async Task TestSetFeatureShoesByIdAsyncShouldSetShoesToBeFeatured()
        {
            await shoesService.SetFeatureShoesByIdAsync(1);
            Assert.IsTrue(shoes1.IsFeatured);
        }
        [Test]
        public async Task TestSetFeatureShoesByIdAsyncShouldSetShoesToNotBeFeatured()
        {
            await shoesService.SetFeatureShoesByIdAsync(1);
            await shoesService.RemoveFeaturedShoesByIdAsync(1);
            Assert.IsFalse(shoes1.IsFeatured);
        }
        [Test]
        public async Task TestCheckIfShoesExistsByIdAsyncShouldReturnTrue()
        {
            Assert.IsTrue(await shoesService.CheckIfShoesExistsByIdAsync(1));
        }
        [Test]
        public async Task TestCheckIfShoesExistsByIdAsyncShouldReturnFalse()
        {
            Assert.IsFalse(await shoesService.CheckIfShoesExistsByIdAsync(-1));
        }
        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
        }
    }
}
