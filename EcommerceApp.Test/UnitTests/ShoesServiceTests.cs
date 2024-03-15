namespace EcommerceApp.Tests.UnitTests
{
    using Microsoft.EntityFrameworkCore;
    using Core.Contracts;
    using Core.Services;
    using Data;
    using static Tests.DatabaseSeeder;
    using EcommerceApp.Core.Models.AdminModels.Clothes;

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
            dbContext = new ApplicationDbContext(dbContextOptions, false);
            dbContext.Database.EnsureCreated();
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
        [Test]
        public async Task TestCheckIfShoesExistsByIdAsyncMethodShouldReturnTrue1()
        {
            Assert.IsTrue(await shoesService.CheckIfShoesExistsByIdAsync(1));
        }
        [Test]
        public async Task TestCheckIfShoesExistsByIdAsyncMethodShouldReturnTrue2()
        {
            Assert.IsTrue(await shoesService.CheckIfShoesExistsByIdAsync(2));
        }
        [Test]
        public async Task TestCheckIfShoesExistsByIdAsyncMethodShouldReturnFalse1()
        {
            Assert.IsFalse(await shoesService.CheckIfShoesExistsByIdAsync(-1));
        }
        [Test]
        public async Task TestCheckIfShoesExistsByIdAsyncMethodShouldReturnFalse2()
        {
            Assert.IsFalse(await shoesService.CheckIfShoesExistsByIdAsync(99));
        }
        [Test]
        public async Task TestEditShoesAsyncShouldEditTheShoesProperlyTest1()
        {
            EditProductModel editProductModel = new EditProductModel()
            {
                CategoryId = 2,
                BrandId = 2,
                Description = "Test Description",
                Name = "Test 1234",
                Price = 250,
                Id = shoes1.Id
            };

            string expectedDescription = "Test Description";
            int expectedCategoryId = 2;
            int expectedBrandId = 2;
            string expectedName = "Test 1234";
            decimal expectedPrice = 250;

            await shoesService.EditShoesAsync(editProductModel);

            Assert.That(shoes1.Description, Is.EqualTo(expectedDescription));
            Assert.That(shoes1.Price, Is.EqualTo(expectedPrice));
            Assert.That(shoes1.CategoryId, Is.EqualTo(expectedCategoryId));
            Assert.That(shoes1.BrandId, Is.EqualTo(expectedBrandId));
            Assert.That(shoes1.Name, Is.EqualTo(expectedName));
        }
        [Test]
        public async Task TestEditShoesAsyncShouldEditTheShoesProperlyTest2()
        {
            EditProductModel editProductModel = new EditProductModel()
            {
                BrandId = shoes1.BrandId,
                CategoryId = shoes1.CategoryId,
                Description = "Test Description",
                Name = "Test 1234",
                Price = 350,
                Id = 1
            };

            string expectedDescription = "Test Description";
            int expectedCategoryId = shoes1.CategoryId;
            int expectedBrandId = shoes1.BrandId;
            string expectedName = "Test 1234";
            decimal expectedPrice = 350;

            await shoesService.EditShoesAsync(editProductModel);

            Assert.That(shoes1.Description, Is.EqualTo(expectedDescription));
            Assert.That(shoes1.Price, Is.EqualTo(expectedPrice));
            Assert.That(shoes1.CategoryId, Is.EqualTo(expectedCategoryId));
            Assert.That(shoes1.BrandId, Is.EqualTo(expectedBrandId));
            Assert.That(shoes1.Name, Is.EqualTo(expectedName));
        }

        [TearDown]
        public void TearDown()
        {
           dbContext.Database.EnsureDeleted();
           dbContext.Dispose();
        }
    }
}
