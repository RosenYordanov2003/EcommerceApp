namespace EcommerceApp.Tests.UnitTests
{
    using Microsoft.EntityFrameworkCore;
    using Core.Contracts;
    using static Tests.DatabaseSeeder;
    using Data;
    using Core.Services;
    using EcommerceApp.Core.Models.AdminModels.Clothes;
    using Microsoft.AspNetCore.Http;
    using EcommerceApp.Core.Models.AdminModels.Pictures;

    [TestFixture]
    public class PictureServiceTests
    {
        private IPictureService pictureService;
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
            pictureService = new PictureService(applicationDbContext);
        }
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public async Task TestCheckIfImgExistsAsyncShouldReturnsTrue(int id)
        {
            bool actualResult = await pictureService.CheckIfImgExistsAsync(id);
            Assert.IsTrue(actualResult);
        }
        [Test]
        [TestCase(-1)]
        [TestCase(-99)]
        [TestCase(3)]
        [TestCase(4)]
        public async Task TestCheckIfImgExistsAsyncShouldReturnsFalse(int id)
        {
            bool actualResult = await pictureService.CheckIfImgExistsAsync(id);
            Assert.IsFalse(actualResult);
        }
        [Test]
        public async Task TestUploadImgAsync()
        {
            var uploadProductImgModel = new UploadProductImgModel
            {
                ProductId = 1,
                ProductCategory = "Shoes",
                PictureFile = new FormFile(new MemoryStream(new byte[1024]), 0, 1024, "data", "test.jpg")
            };
            var path = "C:\\Users\\Home\\Desktop\\Ecomemrce App Remote\\EcommerceApp\\EcommerceApp\\wwwroot\\shoes";

            await pictureService.UploadImgAsync(uploadProductImgModel, path);

            bool result = Directory.Exists($"{path}");
            var files = Directory.GetFiles(path);

            Assert.IsTrue(files.Any(f => f.Split("\\").Contains("1_test.jpg")));
            Assert.IsTrue(result);

            DeletePictureModel model = new DeletePictureModel()
            {
                PictureProductCategory = "shoes",
                Id = 3,
            };
            await pictureService.DeleteImgAsync(model, path);
        }
        [Test]
        public async Task DeleteImgAsyncShouldRemovesItFromTheDatabase()
        {
            DeletePictureModel model = new DeletePictureModel()
            {
                PictureProductCategory = "shoes",
                Id = 1,
            };
            await pictureService.DeleteImgAsync(model, "testPath");

            Assert.IsFalse(await pictureService.CheckIfImgExistsAsync(1));
        }
        [Test]
        public async Task DeleteImgAsyncShouldRemovesItFromTheDisk()
        {
            var uploadProductImgModel = new UploadProductImgModel
            {
                ProductId = 1,
                ProductCategory = "Shoes",
                PictureFile = new FormFile(new MemoryStream(new byte[1024]), 0, 1024, "data", "test2.jpg")
            };
            var path = "C:\\Users\\Home\\Desktop\\Ecomemrce App Remote\\EcommerceApp\\EcommerceApp\\wwwroot\\shoes";
            await pictureService.UploadImgAsync(uploadProductImgModel, path);

            DeletePictureModel model = new DeletePictureModel()
            {
                PictureProductCategory = "shoes",
                Id = 3,
            };
            await pictureService.DeleteImgAsync(model, path);
            var files = Directory.GetFiles(path);

            Assert.IsFalse(files.Any(f => f.Split("\\").Contains("1_test2.jpg")));
        }
        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Database.EnsureDeleted();
        }
    }
}
