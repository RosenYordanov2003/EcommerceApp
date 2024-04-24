namespace EcommerceApp.Tests.UnitTests
{
    using Microsoft.EntityFrameworkCore;
    using Core.Contracts;
    using Core.Services;
    using Data;
    using Core.Models.AdminModels.Clothes;
    using Core.Models.Pager;
    using static Tests.DatabaseSeeder;
    using static Common.GeneralApplicationConstants;
    using Core.Models.Products;
    using Core.Models.AdminModels.Shoes;
    using Core.Models.AdminModels.Pictures;
    using Core.Models.Categories;
    using Core.Models.Promotion;
    using Core.Models.Brands;
    using Core.Models.ProductStocks;

    [TestFixture]
    internal class ShoesServiceTests
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
        [Test]
        public async Task TestGetCountMethodShouldReturnTheCorrectShoesCount()
        {
            int expectedResult = 3;
            int actualResult = await shoesService.GetAllShoesCountAsync();
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
        [Test]
        public async Task TestGetFeaturedhoesMethodShouldReturnTheCorrectCount()
        {
            var result = await shoesService.GetFeaturedShoesAsync(userId);
            int expectedResult = 2;
            int actualResult = result.Count();

            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }
        [Test]
        public async Task TestGetFeaturedhoesMethodShouldReturnTheCorrectIds()
        {
            var actualResult = await shoesService.GetFeaturedShoesAsync(userId);
            IEnumerable<int> expectedResult = new int[] { 1, 2 };

            CollectionAssert.AreEqual(expectedResult, actualResult.Select(x => x.Id));
        }
        [Test]
        public async Task TestGetFeaturedhoesMethodShouldReturnThatShoesAreFavoriteForParticularUser()
        {
            var actualResult = await shoesService.GetFeaturedShoesAsync(userId);
            var collectionResult = actualResult.ToArray();

            Assert.IsTrue(collectionResult[0].IsFavorite);
            Assert.IsTrue(collectionResult[1].IsFavorite);
        }
        [Test]
        public async Task TestGetShoesByIdShouldReturnTheCorrectShoesId()
        {
            int expectedShoesId = 1;
            var result = await shoesService.GetProductByIdAsync(shoes1.Id, userId);

            Assert.That(result.Id, Is.EqualTo(expectedShoesId));
        }
        [Test]
        public async Task TestGetShoesByIdShouldReturnCorrectFavoriteValue()
        {
            var result = await shoesService.GetProductByIdAsync(shoes1.Id, userId);
            Assert.IsTrue(result.IsFavorite);
        }
        [Test]
        public async Task TestSGetShoesByIdForCorrectPickedRelatedShoes()
        {
            var result = await shoesService.GetProductByIdAsync(shoes1.Id, userId);
            int[] expectedRelatedShoesIds = new int[] { 2, 3 };

            CollectionAssert.AreEqual(result.RelatedProducts.Select(x => x.Id), expectedRelatedShoesIds);
        }
        [Test]
        public async Task TestGetShoesByIdPromotion()
        {
            var result = await shoesService.GetProductByIdAsync(shoes1.Id, userId);
            decimal expectedPromotionPercentages = 25.50m;

            Assert.That(expectedPromotionPercentages, Is.EqualTo(result.DicountPercentage));
        }
        [Test]
        public async Task TestGetAllShoesAsyncMethod()
        {
            int[] expectedIds = new int[3] { 1, 2, 3 };
            Pager pager = new Pager(3, 1, DefaultPageSize);
            var actualResult = await shoesService.GetAllShoesAsync(pager);

            CollectionAssert.AreEqual(expectedIds, actualResult.Select(x => x.Id));
        }
        [Test]
        public async Task TestRemoveShoesFromUserFavoriteAsyncMethod()
        {
            UserFavoriteProductModel userFavoriteProductModel = new UserFavoriteProductModel() { ProductId = 1, UserId = userId };
            await shoesService.RemoveShoesFromUserFavoriteProductsAsync(userFavoriteProductModel);
            var shoes = await shoesService.GetProductByIdAsync(1, userId);
            Assert.IsFalse(shoes.IsFavorite);
        }
        [Test]
        public async Task TestAddShoesToUserFavoriteAsyncMethod()
        {
            UserFavoriteProductModel userFavoriteProductModel = new UserFavoriteProductModel() { ProductId = 1, UserId = userId };
            await shoesService.RemoveShoesFromUserFavoriteProductsAsync(userFavoriteProductModel);
            await shoesService.AddShoesToUserFavoriteProductsAsync(userFavoriteProductModel);
            var shoes = await shoesService.GetProductByIdAsync(1, userId);
            Assert.IsTrue(shoes.IsFavorite);
        }
        [Test]
        public async Task TestGetShoesToModifyMethod()
        {
            CategoryModel categoryModelOne = new CategoryModel() { Id = category1.Id, Name = category1.Name };
            CategoryModel categoryModelTwo = new CategoryModel() { Id = category2.Id, Name = category2.Name };
            CategoryModel categoryModelThree = new CategoryModel() { Id = category3.Id, Name = category3.Name };
            BrandModel brandModelOne = new BrandModel() { Id = brand1.Id, Name = brand1.Name };
            BrandModel brandModelTwo = new BrandModel() { Id = brand2.Id, Name = brand2.Name };
            PromotionModel promotionModel = new PromotionModel()
            {
                Id = Guid.Parse("EA99BAEFC49D4A19BC82DFF62231AFE9"),
                PercentageDiscount = 25.50m,
                ExpireTime = new DateTime(2024, 8, 4)
            };

            var expectedResult = new ModifyShoesModel()
            {
                SelectedBrandId = 1,
                SelectedCategoryId = 2,
                Description = "The radiance lives on in the Nike Air Force 1 '07 LV8. Crossing hardwood comfort with off-court flair, these kicks put a fresh spin on a hoops classic. Soft suede overlays pair with era-echoing '80s construction and reflective-design Swoosh logos to bring you nothing-but-net style while hidden full-length Air units add the legendary comfort you know and love.",
                IsArchived = false,
                IsFeatured = true,
                ImgUrls = new List<AdminPictureModel>(),
                Categories = new List<CategoryModel>() { categoryModelOne, categoryModelTwo, categoryModelThree },
                Gender = "Men",
                Name = "Nike Air Force 1 '07 LV8",
                Price = 130,
                StarRating = 5,
                Id = 1,
                PromotionModel = promotionModel,
                Brands = new List<BrandModel>() { brandModelOne, brandModelTwo },
                ProductStocks = Enumerable.Empty<ProductStock<double>>()
            };

            var actualResult = await shoesService.GetShoesToModifyAsync(1);

            Assert.That(actualResult.Description, Is.EqualTo(expectedResult.Description));
            Assert.That(actualResult.ImgUrls.Count(), Is.EqualTo(expectedResult.ImgUrls.Count()));
            Assert.That(actualResult.SelectedCategoryId, Is.EqualTo(expectedResult.SelectedCategoryId));
            Assert.That(actualResult.Gender, Is.EqualTo(expectedResult.Gender));
            Assert.That(actualResult.Name, Is.EqualTo(expectedResult.Name));
            Assert.That(actualResult.Id, Is.EqualTo(expectedResult.Id));
            Assert.That(actualResult.PromotionModel.Id, Is.EqualTo(expectedResult.PromotionModel.Id));
            Assert.That(actualResult.PromotionModel.PercentageDiscount, Is.EqualTo(expectedResult.PromotionModel.PercentageDiscount));
            Assert.That(actualResult.PromotionModel.ExpireTime, Is.EqualTo(expectedResult.PromotionModel.ExpireTime));
            Assert.That(actualResult.StarRating, Is.EqualTo(expectedResult.StarRating));
            CollectionAssert.AreEqual(actualResult.Categories.Select(c => c.Id), new int[3] { 1, 2, 3 });
            CollectionAssert.AreEqual(actualResult.Brands.Select(b => b.Id), new int[2] { 1, 2 });
            Assert.That(expectedResult.ProductStocks.Count(), Is.EqualTo(actualResult.ProductStocks.Count()));

        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }
    }
}
