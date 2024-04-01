namespace EcommerceApp.Tests.UnitTests
{
    using Microsoft.EntityFrameworkCore;
    using static Tests.DatabaseSeeder;
    using Core.Contracts;
    using Data;
    using Core.Services;
    using Core.Models.Cart;
    using EcommerceApp.Core.Models.Products;
    using EcommerceApp.Tests.UnitTests.Comparators;
    using EcommerceApp.Infrastructure.Data.Models;

    [TestFixture]
    public class CartServiceTests
    {
        private ApplicationDbContext applicationDbContext;
        private ICartService cartService;
        private DbContextOptions<ApplicationDbContext> dbContextOptions;

        [SetUp]
        public void SetUp()
        {
            dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
              .UseInMemoryDatabase("EcommerceAppInMemoryDatabase" + Guid.NewGuid().ToString())
              .Options;
            applicationDbContext = new ApplicationDbContext(dbContextOptions, false);
            SeedDatabase(applicationDbContext);
            cartService = new CartService(applicationDbContext);
        }
        [Test]
        public async Task TestAddProductToUserCartWithShoesShouldAddShoecCartEntity()
        {
            Core.Models.Cart.CartProductModel addProductToCartModel = new Core.Models.Cart.CartProductModel()
            {
                UserId = UserId,
                CategoryName = "Shoes",
                ProductId = shoes1.Id,
                Quantity = 2,
                Size = "45"
            };
            var expectedObject = new { Quantity = 2, ShoesId = 1, Size = 45 };
            await cartService.AddProductToUserCartAsync(addProductToCartModel);
            var result = await applicationDbContext.ShoesCartEntities.FirstAsync(x => x.ShoesId == shoes1.Id && x.Size == 45);

            Assert.That(expectedObject.ShoesId, Is.EqualTo(result.ShoesId));
            Assert.That(expectedObject.Size, Is.EqualTo(result.Size));
            Assert.That(expectedObject.Quantity, Is.EqualTo(result.Quantity));
        }
        [Test]
        public async Task TestAddProductToUserCartWithShoesShouldAddProductEntity()
        {
            Core.Models.Cart.CartProductModel addProductToCartModel = new Core.Models.Cart.CartProductModel()
            {
                UserId = UserId,
                CategoryName = "T-Shirts",
                ProductId = product1.Id,
                Quantity = 2,
                Size = "M"
            };
            var expectedObject = new { Quantity = 2, ShoesId = 1, Size = "M" };
            await cartService.AddProductToUserCartAsync(addProductToCartModel);
            var result = await applicationDbContext.ProductCartEntities.FirstAsync(x => x.ProductId == product1.Id && x.Size == "M");

            Assert.That(expectedObject.ShoesId, Is.EqualTo(result.ProductId));
            Assert.That(expectedObject.Size, Is.EqualTo(result.Size));
            Assert.That(expectedObject.Quantity, Is.EqualTo(result.Quantity));
        }
        [Test]
        public async Task TestAddProductToUserCartWithShoesShouldIncreaseProductCartQuantity()
        {
            Core.Models.Cart.CartProductModel addProductToCartModel = new Core.Models.Cart.CartProductModel()
            {
                UserId = UserId,
                CategoryName = "T-Shirts",
                ProductId = product1.Id,
                Quantity = 2,
                Size = "M"
            };
            Core.Models.Cart.CartProductModel addProductToCartModelSecond = new Core.Models.Cart.CartProductModel()
            {
                UserId = UserId,
                CategoryName = "T-Shirts",
                ProductId = product1.Id,
                Quantity = 5,
                Size = "M"
            };
            var expectedObject = new { Quantity = 7, ShoesId = 1, Size = "M" };
            await cartService.AddProductToUserCartAsync(addProductToCartModel);
            await cartService.AddProductToUserCartAsync(addProductToCartModelSecond);
            var result = await applicationDbContext.ProductCartEntities.FirstAsync(x => x.ProductId == product1.Id && x.Size == "M");

            Assert.That(expectedObject.ShoesId, Is.EqualTo(result.ProductId));
            Assert.That(expectedObject.Size, Is.EqualTo(result.Size));
            Assert.That(expectedObject.Quantity, Is.EqualTo(result.Quantity));
        }
        [Test]
        public async Task TestAddProductToUserCartWithShoesShouldIncreaseQuantity()
        {
            Core.Models.Cart.CartProductModel addProductToCartModel = new Core.Models.Cart.CartProductModel()
            {
                UserId = UserId,
                CategoryName = "Shoes",
                ProductId = shoes1.Id,
                Quantity = 2,
                Size = "45"
            };
            Core.Models.Cart.CartProductModel addProductToCartModelTwo = new Core.Models.Cart.CartProductModel()
            {
                UserId = UserId,
                CategoryName = "Shoes",
                ProductId = shoes1.Id,
                Quantity = 2,
                Size = "45"
            };
            var expectedObject = new { Quantity = 4, ShoesId = 1, Size = 45 };
            await cartService.AddProductToUserCartAsync(addProductToCartModel);
            await cartService.AddProductToUserCartAsync(addProductToCartModelTwo);
            var result = await applicationDbContext.ShoesCartEntities.FirstAsync(x => x.ShoesId == shoes1.Id && x.Size == 45);

            Assert.That(expectedObject.ShoesId, Is.EqualTo(result.ShoesId));
            Assert.That(expectedObject.Size, Is.EqualTo(result.Size));
            Assert.That(expectedObject.Quantity, Is.EqualTo(result.Quantity));
        }
        [Test]
        public async Task TestCheckICartProductsQuantityIsAvailableAsyncShouldReturnTrue()
        {
            Core.Models.Cart.CartProductModel addProductToCartModel = new Core.Models.Cart.CartProductModel()
            {
                UserId = UserId,
                CategoryName = "Shoes",
                ProductId = shoes2.Id,
                Quantity = 3,
                Size = "45"
            };
            Core.Models.Cart.CartProductModel addProductToCartModel2 = new Core.Models.Cart.CartProductModel()
            {
                UserId = UserId,
                CategoryName = "T-Shirts",
                ProductId = product1.Id,
                Quantity = 10,
                Size = "L"
            };
            await cartService.AddProductToUserCartAsync(addProductToCartModel);
            await cartService.AddProductToUserCartAsync(addProductToCartModel2);
            bool result = await cartService.CheckICartProductsQuantityIsAvailableAsync(UserId);
            var shoesStock = await applicationDbContext.ShoesStock.FirstAsync(x => x.ShoesId == shoes2.Id && x.Size == 45);
            var productStock = await applicationDbContext.ProductStocks.FirstAsync(x => x.ProductId == product1.Id && x.Size == "L");
            const int expectedQuantity = 2;
            const int expectedTshirtsQuantity = 0;
            Assert.IsTrue(result);
            Assert.That(shoesStock.Quantity, Is.EqualTo(expectedQuantity));
            Assert.That(productStock.Quantity, Is.EqualTo(expectedTshirtsQuantity));
        }
        [Test]
        public async Task TestCheckICartProductsQuantityIsAvailableAsyncShouldReturnFalse()
        {
            Core.Models.Cart.CartProductModel addProductToCartModel = new Core.Models.Cart.CartProductModel()
            {
                UserId = UserId,
                CategoryName = "Shoes",
                ProductId = shoes2.Id,
                Quantity = 13,
                Size = "45"
            };
            Core.Models.Cart.CartProductModel addProductToCartModel2 = new Core.Models.Cart.CartProductModel()
            {
                UserId = UserId,
                CategoryName = "T-Shirts",
                ProductId = shoes2.Id,
                Quantity = 11,
                Size = "L"
            };
            await cartService.AddProductToUserCartAsync(addProductToCartModel);
            await cartService.AddProductToUserCartAsync(addProductToCartModel2);
            bool result = await cartService.CheckICartProductsQuantityIsAvailableAsync(UserId);
            Assert.IsFalse(result);
        }
        [Test]
        public async Task TestClearUserCartAsyncAfterFinishingOrder()
        {
            Core.Models.Cart.CartProductModel addProductToCartModel = new Core.Models.Cart.CartProductModel()
            {
                UserId = UserId,
                CategoryName = "Shoes",
                ProductId = shoes2.Id,
                Quantity = 13,
                Size = "45"
            };
            Core.Models.Cart.CartProductModel addProductToCartModel2 = new Core.Models.Cart.CartProductModel()
            {
                UserId = UserId,
                CategoryName = "T-Shirts",
                ProductId = shoes2.Id,
                Quantity = 11,
                Size = "L"
            };
            await cartService.AddProductToUserCartAsync(addProductToCartModel);
            await cartService.AddProductToUserCartAsync(addProductToCartModel2);
            await cartService.ClearUserCartAsyncAfterFinishingOrder(UserId);

            const int expectedShoesCartEntitiesCount = 0;
            const int expectedProductCartEntitiesCount = 0;

            int actualShoesCartEntitesCount = await applicationDbContext.ShoesCartEntities.CountAsync();
            int actualProductsCartEntitesCount = await applicationDbContext.ProductCartEntities.CountAsync();

            Assert.That(actualShoesCartEntitesCount, Is.EqualTo(expectedShoesCartEntitiesCount));
            Assert.That(actualProductsCartEntitesCount, Is.EqualTo(expectedProductCartEntitiesCount));
        }
        [Test]
        public async Task TestDecreaseProductCartQuantityAsync()
        {
            ModifyProductCartQuantityModel model = new ModifyProductCartQuantityModel()
            {
                Operation = "Decrease",
                CategoryName = "Shoes",
                ProductId = shoes2.Id,
                Size = "45",
                UserId = UserId
            };
            Core.Models.Cart.CartProductModel addProductToCartModel = new Core.Models.Cart.CartProductModel()
            {
                UserId = UserId,
                CategoryName = "Shoes",
                ProductId = shoes2.Id,
                Quantity = 3,
                Size = "45"
            };
            await cartService.AddProductToUserCartAsync(addProductToCartModel);
            await cartService.DecreaseProductCartQuantityAsync(model);

            const int expectedCartProductQuantity = 2;

            var result = await applicationDbContext.ShoesCartEntities.FirstAsync(x => x.ShoesId == shoes2.Id && x.Size == 45);

            Assert.That(result.Quantity, Is.EqualTo(expectedCartProductQuantity));
        }
        [Test]
        public async Task TestIncreaseProductQuantityAsync()
        {
            ModifyProductCartQuantityModel model = new ModifyProductCartQuantityModel()
            {
                Operation = "Decrease",
                CategoryName = "Shoes",
                ProductId = shoes2.Id,
                Size = "45",
                UserId = UserId
            };
            Core.Models.Cart.CartProductModel addProductToCartModel = new Core.Models.Cart.CartProductModel()
            {
                UserId = UserId,
                CategoryName = "Shoes",
                ProductId = shoes2.Id,
                Quantity = 3,
                Size = "45"
            };
            await cartService.AddProductToUserCartAsync(addProductToCartModel);
            await cartService.IncreaseProductCartQuantityAsync(model);

            const int expectedCartProductQuantity = 4;

            var result = await applicationDbContext.ShoesCartEntities.FirstAsync(x => x.ShoesId == shoes2.Id && x.Size == 45);

            Assert.That(result.Quantity, Is.EqualTo(expectedCartProductQuantity));
        }
        [Test]
        public async Task TestGetUserCartByUserIdAsync()
        {
            Core.Models.Cart.CartProductModel addProductToCartModel = new Core.Models.Cart.CartProductModel()
            {
                Size = "45",
                CategoryName = "Shoes",
                Quantity = 2,
                UserId = UserId,
                ProductId = shoes1.Id
            };
            Core.Models.Cart.CartProductModel addProductToCartModel2 = new Core.Models.Cart.CartProductModel()
            {
                Size = "M",
                CategoryName = "T-Shirts",
                Quantity = 1,
                UserId = UserId,
                ProductId = product1.Id
            };

            await cartService.AddProductToUserCartAsync(addProductToCartModel);
            await cartService.AddProductToUserCartAsync(addProductToCartModel2);

            var expectedCartModel = new CartModel()
            {
                CartId = Guid.Parse("742C4C45-5A51-4053-8F5E-7062135175A3"),
                CartShoes = new List<Core.Models.Products.ProductCartModel>()
                {
                    new Core.Models.Products.ProductCartModel()
                    {
                        Size = "45",
                        CategoryName = "Shoes",
                        Name = "Nike Air Force 1 '07 LV8",
                        ImgUrl = null,
                        Price = 96.85m,
                        Quantity = 2
                    },
                },
                CartProducts = new List<Core.Models.Products.ProductCartModel>()
                {
                    new Core.Models.Products.ProductCartModel()
                    {
                        Size = "M",
                        CategoryName = "T-Shirts",
                        Name = "Chicago Bulls Essential",
                        ImgUrl = null,
                        Price = 40,
                        Quantity = 1
                    }

                },
                TotalPrice = 235
            };



            var actualCartModel = await cartService.GetUserCartByUserIdAsync(UserId);

            Assert.That(actualCartModel.CartId, Is.EqualTo(expectedCartModel.CartId));
            CollectionAssert.AreEqual(expectedCartModel.CartShoes, actualCartModel.CartShoes, new ProductCartModelComparator());
            CollectionAssert.AreEqual(expectedCartModel.CartProducts, actualCartModel.CartProducts, new ProductCartModelComparator());
        }
        [Test]
        public async Task TestRemoveProductFromUserCartAsync()
        {
            CartProductModel model = new CartProductModel()
            {
                Size = "45",
                CategoryName = "Shoes",
                Quantity = 2,
                UserId = UserId,
                ProductId = shoes1.Id
            };
            CartProductModel model2 = new CartProductModel()
            {
                Size = "M",
                CategoryName = "T-Shirts",
                Quantity = 1,
                UserId = UserId,
                ProductId = product1.Id
            };

            await cartService.AddProductToUserCartAsync(model);
            await cartService.AddProductToUserCartAsync(model2);


            await cartService.RemoveProductFromUserCartAsync(model);

            int expectedShoesCartEntitesCount = 0;
            int actualShoesCartEntitesCount = await applicationDbContext.ShoesCartEntities.CountAsync();

            Assert.That(expectedShoesCartEntitesCount, Is.EqualTo(actualShoesCartEntitesCount));
        }
        public async Task TestRemoveProductFromUserCartAsyncShouldRemainsOneEntity()
        {
            CartProductModel model = new CartProductModel()
            {
                Size = "45",
                CategoryName = "Shoes",
                Quantity = 2,
                UserId = UserId,
                ProductId = shoes1.Id
            };
            CartProductModel model2 = new CartProductModel()
            {
                Size = "44",
                CategoryName = "Shoes",
                Quantity = 2,
                UserId = UserId,
                ProductId = shoes1.Id
            };


            await cartService.AddProductToUserCartAsync(model);
            await cartService.AddProductToUserCartAsync(model2);


            await cartService.RemoveProductFromUserCartAsync(model);

            int expectedShoesCartEntitesCount = 1;
            int actualShoesCartEntitesCount = await applicationDbContext.ShoesCartEntities.CountAsync();

            Assert.That(expectedShoesCartEntitesCount, Is.EqualTo(actualShoesCartEntitesCount));
        }
        [Test]
        public async Task TestCreateUserCartAsync()
        {
            User user = new User()
            {
                Id = Guid.Parse("E18A5422-4434-4891-A123-49E4AE9F84FA"),
                UserName = "TestUser",
                NormalizedUserName = "TESTUSER",
                Email = "test@gmail.com",
                NormalizedEmail = "TES@GMAIL.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            await applicationDbContext.Users.AddAsync(user);

            await cartService.CreateUserCartAsync(user.Id);

            var userCart = cartService.GetUserCartByUserIdAsync(user.Id);

            Assert.IsNotNull(userCart);
        }
        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Database.EnsureDeleted();
        }
    }
}
