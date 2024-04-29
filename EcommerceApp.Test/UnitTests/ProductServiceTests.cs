namespace EcommerceApp.Tests.UnitTests
{
    using Microsoft.EntityFrameworkCore;
    using static Tests.DatabaseSeeder;
    using static Common.GeneralApplicationConstants;
    using Core.Contracts;
    using Data;
    using Core.Services;
    using Core.Models.Products;
    using Core.Models.Pictures;
    using Tests.UnitTests.Comparators;
    using Core.Models.Review;
    using Core.Models.ProductStocks;
    using Core.Models.Pager;
    using Core.Models.AdminModels.Clothes;
    using Core.Models.AdminModels.Pictures;

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
            UserFavoriteProductModel userFavoriteProduct = new UserFavoriteProductModel()
            {
                UserId = userId,
                ProductId = product1.Id
            };
            await productSevice.AddProductToUserFavoritesListAsync(userFavoriteProduct);
            var result = await productSevice.GetProductByIdAsync(product1.Id, userId);

            Assert.IsTrue(result.IsFavorite);
        }
        [Test]
        public async Task TestRemoveProductFromUserFavoriteListAsync()
        {
            UserFavoriteProductModel userFavoriteProduct = new UserFavoriteProductModel()
            {
                UserId = userId,
                ProductId = product1.Id
            };
            await productSevice.AddProductToUserFavoritesListAsync(userFavoriteProduct);
            await productSevice.RemoveProductFromUserFavoriteListAsync(userFavoriteProduct);

            var result = await productSevice.GetProductByIdAsync(product1.Id, userId);

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
            var result = await productSevice.GetFeaturedClothesAsync(userId);

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
            UserFavoriteProductModel userFavoriteProduct = new UserFavoriteProductModel()
            {
                UserId = userId,
                ProductId = product1.Id
            };
            await productSevice.AddProductToUserFavoritesListAsync(userFavoriteProduct);
            var result = await productSevice.GetFeaturedClothesAsync(userId);

            CollectionAssert.AreEqual(expectedResult, result, new ProductModelComparator());
        }
        [Test]
        public async Task TestGetProductByGenderShouldReturnEmptyCollectionWithCorrectBrands()
        {
            var result = await productSevice.GetProductByGender("women", userId);

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
            var result = await productSevice.GetProductByGender("men", userId);

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
            var expectedProductModel = new ProductInfoModel<string>()
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
            await productSevice.AddProductToUserFavoritesListAsync(new UserFavoriteProductModel() { ProductId = product1.Id, UserId = userId });
            var result = await productSevice.GetProductByIdAsync(product1.Id, userId);

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
            await productSevice.AddProductToUserFavoritesListAsync(new UserFavoriteProductModel() { ProductId = product1.Id, UserId = userId });
            var result = await productSevice.GetUserFavoriteProductsAsync(userId);

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

            var actualCollection = await productSevice.GetUserFavoriteProductsAsync(userId);

            CollectionAssert.AreEqual(expectedCollection, actualCollection, new UserFavoriteProductModelComparator());
        }
        [Test]
        public async Task TestLoadAllClothesAsyncShouldReturnsTheCorrectIds()
        {
            Pager pager = new Pager(3, 1, DefaultPageSize);
            var result = await productSevice.LoadAllClothesAsync(pager);

            int[] expectedIds = new int[] { 1, 2, 3 };

            CollectionAssert.AreEqual(expectedIds, result.Select(x => x.Id));
        }
        [Test]
        public async Task TestLoadAllClothesAsyncShouldReturnsTheCorrectObjects()
        {
            Pager pager = new Pager(3, 1, DefaultPageSize);
            var result = await productSevice.LoadAllClothesAsync(pager);

            var expectedCollection = new List<ClothesModel>()
            {
                new ClothesModel()
                {
                    Id = 1,
                    ImgUrls = new List<AdminPictureModel>(),
                    IsArchived = false,
                    Name = "Chicago Bulls Essential",
                    Price = 40,
                    StarRating = 4
                },
                new ClothesModel()
                {
                    Id = 2,
                    ImgUrls = new List<AdminPictureModel>(),
                    IsArchived = false,
                    Name = "Chicago Bulls Essential",
                    Price = 40,
                    StarRating = 4
                },
                new ClothesModel()
                {
                    Id = 3,
                    ImgUrls = new List<AdminPictureModel>(),
                    IsArchived = false,
                    Name = "Nike Air x Marcus Rashford",
                    Price = 38,
                    StarRating = 5
                }
            };

            var actualCollection = await productSevice.LoadAllClothesAsync(pager);

            CollectionAssert.AreEqual(expectedCollection, actualCollection, new ClothesModelComparator());
        }
        [Test]
        public async Task TestLoadUserFavoriteProductsAsyncShouldReturnsTwoElements()
        {
            const int expectedCount = 2;

            var result = await productSevice.LoadUserFavoriteProductsAsync(userId);

            Assert.That(result.Count, Is.EqualTo(expectedCount));
        }
        [Test]
        public async Task TestLoadUserFavoriteProductsAsyncShouldReturnsTheCorrectElements()
        {
           var expectedCollection = new List<ProductFeatureModel>()
           {
               new ProductFeatureModel()
               {
                   Id = 3,
                   CategoryName = "T-Shirts",
                   DicountPercentage = 0,
                   Name = "Nike Air x Marcus Rashford",
                   IsFavorite = true,
                   StarRating = 5,
                   Pictures = new List<PictureModel>(),
                   Price = 38
               },
               new ProductFeatureModel()
               {
                   Id = 1,
                   CategoryName = "Shoes",
                   DicountPercentage = 25.50m,
                   Name = "Nike Air Force 1 '07 LV8",
                   IsFavorite = true,
                   StarRating = 5,
                   Pictures = new List<PictureModel>(),
                   Price = 130
               },
               new ProductFeatureModel()
               {
                   Id = 2,
                   CategoryName = "Shoes",
                   DicountPercentage = 0,
                   Name = "Nike Mercurial Vapor 15 Pro",
                   IsFavorite = true,
                   StarRating = 5,
                   Pictures = new List<PictureModel>(),
                   Price = 160
               },
           };

            await productSevice.AddProductToUserFavoritesListAsync(new UserFavoriteProductModel() { ProductId = 3, UserId = userId });

            var actualCollection = await productSevice.LoadUserFavoriteProductsAsync(userId);

            CollectionAssert.AreEqual(expectedCollection, actualCollection, new ProductFeatureModelComparator());
        }
        [Test]
        public async Task TestGetProductToModifyAsync()
        {
            ModifyClothesModel expectedModel = new ModifyClothesModel()
            {
                SelectedBrandId = 1,
                IsArchived = false,
                IsFeatured = true,
                Id = 1,
                SelectedCategoryId = 1,
                Description = "Men's Jordan NBA Long-Sleeve T-Shirt",
                Name = "Chicago Bulls Essential",
                Gender = "Men",
                StarRating = 5,
                ImgUrls = new List<AdminPictureModel>(),
                Price = 40,
                ProductStocks = new List<ProductStock<string>>()
                {
                    new ProductStock<string>()
                    {
                        Size = "S",
                        Quantity = 5
                    },
                    new ProductStock<string>()
                    {
                        Size = "L",
                        Quantity = 10
                    }
                }
            };

            var actualModel = await productSevice.GetProductToModifyAsync(1);

            Assert.That(actualModel.SelectedBrandId, Is.EqualTo(expectedModel.SelectedBrandId));
            Assert.That(actualModel.IsFeatured, Is.EqualTo(expectedModel.IsFeatured));
            Assert.That(actualModel.IsArchived, Is.EqualTo(expectedModel.IsArchived));
            Assert.That(actualModel.Name, Is.EqualTo(expectedModel.Name));
            Assert.That(actualModel.Description, Is.EqualTo(expectedModel.Description));
            Assert.That(actualModel.Price, Is.EqualTo(expectedModel.Price));
            Assert.That(actualModel.Gender, Is.EqualTo(expectedModel.Gender));
            CollectionAssert.AreEqual(expectedModel.ProductStocks, actualModel.ProductStocks, new ProductStockComparator());
        }
        [Test]
        public async Task TestEditProduct()
        {
            var model = new EditProductModel()
            {
                CategoryId = 2,
                BrandId = 1,
                Description = "Men's Jordan NBA Long-Sleeve T-Shirt",
                Name = "Chicago Bulls Essential",
                Price = 35,
                Id = 1,
            };

            const int expectedCategoryId = 2;
            const decimal expectedPrice = 35;

            await productSevice.EditProductAsync(model);
            var result = await applicationDbContext.Clothes.FirstAsync(x => x.Id == 1);

            Assert.That(result.CategoryId, Is.EqualTo(expectedCategoryId));
            Assert.That(result.Price, Is.EqualTo(expectedPrice));
        }
        [Test]
        public async Task TestArchiveProductAsync()
        {
            await productSevice.ArchiveProductAsync(product1.Id);
            var result = await applicationDbContext.Clothes.FirstAsync(x => x.Id == 1);

            Assert.IsTrue(result.IsArchived);
        }
        [Test]
        public async Task TestRestoreProductAsync()
        {
            await productSevice.ArchiveProductAsync(product1.Id);
            await productSevice.RestoreProductAsync(product1.Id);
            var result = await applicationDbContext.Clothes.FirstAsync(x => x.Id == 1);

            Assert.IsFalse(result.IsArchived);
        }
        [Test]
        public async Task TestSetFeaturedProductAsync()
        {
            await productSevice.SetProductToBeFeaturedByIdAsync(product2.Id);
            var result = await applicationDbContext.Clothes.FirstAsync(x => x.Id == 2);

            Assert.IsTrue(result.IsFeatured);
        }
        [Test]
        public async Task TestRemoveProductFromBeFeaturedProductsByIdAsync()
        {
            await productSevice.SetProductToBeFeaturedByIdAsync(product2.Id);
            await productSevice.RemoveProductFromBeFeaturedProductsByIdAsync(product2.Id);
            var result = await applicationDbContext.Clothes.FirstAsync(x => x.Id == 2);

            Assert.IsFalse(result.IsFeatured);
        }
        [Test]
        public async Task TestCreateProductMethodAsync()
        {
            CreateProductModel createProductModel = new CreateProductModel()
            {
                CategoryId = 1,
                BrandId = 2,
                Gender = "Women",
                Description = "Test Description",
                Name = "Test Product",
                Price = 100,
                StarRating = 5
            };

            await productSevice.CreateProductAsync(createProductModel);

            var result = await applicationDbContext.Clothes.AnyAsync(x => x.Id == 4);

            Assert.IsTrue(result);
        }
        [Test]
        public async Task TestCreateProductMethodAsync2()
        {
            CreateProductModel createProductModel = new CreateProductModel()
            {
                CategoryId = 9,
                BrandId = 2,
                Gender = "Women",
                Description = "Test Description",
                Name = "Test Product",
                Price = 100,
                StarRating = 5
            };

            await productSevice.CreateProductAsync(createProductModel);

            var result = await applicationDbContext.Shoes.AnyAsync(x => x.Id == 4);

            Assert.IsTrue(result);
        }
        [Test]
        public async Task TestGetAllClothesCountAsync()
        {
            const int expectedCount = 3;
            int actualCount = await productSevice.GetAllClothesCountAsync();

            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Database.EnsureDeleted();
        }
    }
}
