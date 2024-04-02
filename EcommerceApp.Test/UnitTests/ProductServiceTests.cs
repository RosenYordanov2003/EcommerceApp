namespace EcommerceApp.Tests.UnitTests
{
    using Microsoft.EntityFrameworkCore;
    using static Tests.DatabaseSeeder;
    using Core.Contracts;
    using Data;
    using Core.Services;
    using EcommerceApp.Core.Models.Products;
    using EcommerceApp.Core.Models.Pictures;
    using EcommerceApp.Tests.UnitTests.Comparators;
    using EcommerceApp.Core.Models.Review;
    using EcommerceApp.Core.Models.ProductStocks;

    [TestFixture]
    internal class ProductServiceTests
    {
        private IProductSevice productSevice;
        private ApplicationDbContext applicationDbContext;
        private DbContextOptions<ApplicationDbContext> dbContextOptions;

        [SetUp]
        public void SetUp()
        {
            dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
              .UseInMemoryDatabase("EcommerceAppInMemoryDatabase" + Guid.NewGuid().ToString())
              .Options;
            applicationDbContext = new ApplicationDbContext(dbContextOptions, false);
            productSevice = new ProductService(applicationDbContext);
            SeedDatabase(applicationDbContext);
        }
        [Test]
        public async Task TestAddProductToUserFavoritesListAsync()
        {
            UserFavoriteProduct userFavoriteProduct = new UserFavoriteProduct()
            {
                UserId = UserId,
                ProductId = product1.Id
            };
            await productSevice.AddProductToUserFavoritesListAsync(userFavoriteProduct);
            var result = await productSevice.GetProductByIdAsync(product1.Id, UserId);

            Assert.IsTrue(result.IsFavorite);
        }
        [Test]
        public async Task TestRemoveProductFromUserFavoriteListAsync()
        {
            UserFavoriteProduct userFavoriteProduct = new UserFavoriteProduct()
            {
                UserId = UserId,
                ProductId = product1.Id
            };
            await productSevice.AddProductToUserFavoritesListAsync(userFavoriteProduct);
            await productSevice.RemoveProductFromUserFavoriteListAsync(userFavoriteProduct);

            var result = await productSevice.GetProductByIdAsync(product1.Id, UserId);

            Assert.IsFalse(result.IsFavorite);
        }
        [Test]
        public async Task TestCheckIfProductExistsByIdAsyncShouldReturnTrue()
        {
            bool result = await productSevice.CheckIfProductExistsByIdAsync(product1.Id);
            Assert.IsTrue(result);
        }
        [Test]
        public async Task TestCheckIfProductExistsByIdAsyncShouldReturnFalse()
        {
            bool result = await productSevice.CheckIfProductExistsByIdAsync(100);
            Assert.IsFalse(result);
        }
        [Test]
        public async Task TaskGetFeaturedClothesAsyncShouldReturnTheCorrectIds()
        {
            int[] expectedIds = new int[2] { 1, 3 };
            var result = await productSevice.GetFeaturedClothesAsync(UserId);

            CollectionAssert.AreEqual(expectedIds, result.Select(x => x.Id));
        }
        [Test]
        public async Task TaskGetFeaturedClothesAsyncShouldReturnTheCorrectObjects()
        {
            var expectedResult = new List<ProductModel>()
            {
                new ProductModel()
                {
                    Price = 40,
                    CategoryName = "T-Shirts",
                    Description = "Men's Jordan NBA Long-Sleeve T-Shirt",
                    IsFavorite = true,
                    DicountPercentage = 0,
                    Name = "Chicago Bulls Essential",
                    Pictures = new List<PictureModel>(),
                    StarRating = 4
                },
                new ProductModel()
                {
                    Price = 38,
                    CategoryName = "T-Shirts",
                    Description = "From the pitch to the streets, you can celebrate Marcus Rashford's passion for sport in comfort with this sweat-wicking tee. Soft fabric and a relaxed fit help keep you dry and comfortable, while retro branding and an \"MR\" logo add the perfect finishing touches.",
                    IsFavorite = false,
                    DicountPercentage = 0,
                    Name = "Nike Air x Marcus Rashford",
                    Pictures = new List<PictureModel>(),
                    StarRating = 5
                },
            };
            UserFavoriteProduct userFavoriteProduct = new UserFavoriteProduct()
            {
                UserId = UserId,
                ProductId = product1.Id
            };
            await productSevice.AddProductToUserFavoritesListAsync(userFavoriteProduct);
            var result = await productSevice.GetFeaturedClothesAsync(UserId);

            CollectionAssert.AreEqual(expectedResult, result, new ProductModelComparator());
        }
        [Test]
        public async Task TestGetProductByGenderShouldReturnEmptyCollectionWithCorrectBrands()
        {
            var result = await productSevice.GetProductByGender("women", UserId);

            var expectedCategories = new List<string>()
            {
                "T-Shirts",
                "Shoes",
                "Trousers"
            };
          
            int expectedCount = 0;

            Assert.That(result.Shoes.Count(), Is.EqualTo(expectedCount));
            Assert.That(result.Products.Count(), Is.EqualTo(expectedCount));
            CollectionAssert.AreEqual(expectedCategories, result.Categories.Select(x => x.Name));
        }
        [Test]
        public async Task TestGetProductByGenderShouldReturnEmptyCollectionWithCorrectBrands2()
        {
            var result = await productSevice.GetProductByGender("men", UserId);

            var expectedCategories = new List<string>()
            {
                "T-Shirts",
                "Shoes",
                "Trousers"
            };

            var expectedCollectionResult = new List<ProductModel>()
            {
                new ProductModel()
                {
                    Price = 40,
                    CategoryName = "T-Shirts",
                    Description = "Men's Jordan NBA Long-Sleeve T-Shirt",
                    IsFavorite = false,
                    DicountPercentage = 0,
                    Name = "Chicago Bulls Essential",
                    Pictures = new List<PictureModel>(),
                    StarRating = 4
                },
                new ProductModel()
                {
                    Price = 40,
                    CategoryName = "T-Shirts",
                    Description = "Men's Jordan NBA Long-Sleeve T-Shirt",
                    IsFavorite = false,
                    DicountPercentage = 0,
                    Name = "Chicago Bulls Essential",
                    Pictures = new List<PictureModel>(),
                    StarRating = 4
                },
                new ProductModel()
                {
                    Price = 38,
                    CategoryName = "T-Shirts",
                    Description = "From the pitch to the streets, you can celebrate Marcus Rashford's passion for sport in comfort with this sweat-wicking tee. Soft fabric and a relaxed fit help keep you dry and comfortable, while retro branding and an \"MR\" logo add the perfect finishing touches.",
                    IsFavorite = false,
                    DicountPercentage = 0,
                    Name = "Nike Air x Marcus Rashford",
                    Pictures = new List<PictureModel>(),
                    StarRating = 5
                },
            };


            int expectedCount = 3;

            Assert.That(result.Shoes.Count(), Is.EqualTo(expectedCount));
            Assert.That(result.Products.Count(), Is.EqualTo(expectedCount));
            CollectionAssert.AreEqual(expectedCategories, result.Categories.Select(x => x.Name));
            CollectionAssert.AreEqual(expectedCategories, result.Categories.Select(x => x.Name));
            CollectionAssert.AreEqual(expectedCollectionResult, result.Products, new ProductModelComparator());
        }
        [Test]
        public async Task TestGetProductByIdAsync()
        {
            var expectedProductModel = new ProductInfo<string>()
            {
                CategoryName = "T-Shirts",
                Brand = "Nike",
                Description = "Men's Jordan NBA Long-Sleeve T-Shirt",
                Name = "Chicago Bulls Essential",
                DicountPercentage = 0,
                Gender = "Men",
                IsAvalilable = true,
                IsFavorite = true,
                Pictures = new List<PictureModel>(),
                Price = 40,
                Reviews = new List<ReviewModel>(),
                StarRating = 4,
                TotalMilisecondsDifference = 0,
                ProductStocks = new List<ProductStock<string>>()
                {
                    new ProductStock<string>()
                    {   Quantity = 5,
                        Size = "S"
                    },
                    new ProductStock<string>()
                    {
                        Quantity = 10,
                        Size = "L"
                    },
                },
                RelatedProducts = new List<ProductModel>()
                {
                    new ProductModel()
                    {
                        Price = 40,
                        CategoryName = "T-Shirts",
                        Description = "Men's Jordan NBA Long-Sleeve T-Shirt",
                        IsFavorite = false,
                        DicountPercentage = 0,
                        Name = "Chicago Bulls Essential",
                        Pictures = new List<PictureModel>(),
                        StarRating = 4
                    },
                    new ProductModel()
                    {
                        Price = 38,
                        CategoryName = "T-Shirts",
                        Description = "From the pitch to the streets, you can celebrate Marcus Rashford's passion for sport in comfort with this sweat-wicking tee. Soft fabric and a relaxed fit help keep you dry and comfortable, while retro branding and an \"MR\" logo add the perfect finishing touches.",
                        IsFavorite = false,
                        DicountPercentage = 0,
                        Name = "Nike Air x Marcus Rashford",
                        Pictures = new List<PictureModel>(),
                        StarRating = 5
                    },
                }
            };
            await productSevice.AddProductToUserFavoritesListAsync(new UserFavoriteProduct() { ProductId = product1.Id, UserId = UserId });
            var result = await productSevice.GetProductByIdAsync(product1.Id, UserId);

            CollectionAssert.AreEqual(expectedProductModel.RelatedProducts.OrderByDescending(x => x.StarRating), result.RelatedProducts, new ProductModelComparator());
            CollectionAssert.AreEqual(expectedProductModel.ProductStocks, result.ProductStocks, new ProductStockComparator());
            Assert.That(result.CategoryName, Is.EqualTo(expectedProductModel.CategoryName));
            Assert.That(result.Name, Is.EqualTo(expectedProductModel.Name));
            Assert.That(result.Price, Is.EqualTo(expectedProductModel.Price));
            Assert.That(result.IsFavorite, Is.EqualTo(expectedProductModel.IsFavorite));
            Assert.That(result.IsAvalilable, Is.EqualTo(expectedProductModel.IsAvalilable));
            Assert.That(result.Description, Is.EqualTo(expectedProductModel.Description));
            Assert.That(result.Brand, Is.EqualTo(expectedProductModel.Brand));
        }
        [Test]
        public async Task TestGetUserFavoriteProductsAsyncShouldReturnTheCorrectCount()
        {
            await productSevice.AddProductToUserFavoritesListAsync(new UserFavoriteProduct() { ProductId = product1.Id, UserId = UserId });
            var result = await productSevice.GetUserFavoriteProductsAsync(UserId);

            int expectedCount = 3;

            Assert.That(result.Count, Is.EqualTo(expectedCount));
        }
        [Test]
        public async Task TestGetUserFavoriteProductsAsyncShouldReturnTheCorrectObjects()
        {
            var expectedCollection = new List<GetUserFavoriteProductModel>()
            {
                new GetUserFavoriteProductModel()
                {
                    CategoryName = "Shoes",
                    ProductId = 1,
                    ProductName = "Nike Air Force 1 '07 LV8"
                },
                new GetUserFavoriteProductModel()
                {
                    CategoryName = "Shoes",
                    ProductId = 2,
                    ProductName = "Nike Mercurial Vapor 15 Pro"
                }
            };

            var actualCollection = await productSevice.GetUserFavoriteProductsAsync(UserId);

            CollectionAssert.AreEqual(expectedCollection, actualCollection, new UserFavoriteProductModelComparator());
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Database.EnsureDeleted();
        }
    }
}
