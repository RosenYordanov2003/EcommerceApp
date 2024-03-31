namespace EcommerceApp.Tests.UnitTests
{
    using Microsoft.EntityFrameworkCore;
    using static Tests.DatabaseSeeder;
    using Core.Contracts;
    using Data;
    using Core.Services;
    using Core.Models.Cart;

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
            AddProductToCartModel addProductToCartModel = new AddProductToCartModel()
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
            AddProductToCartModel addProductToCartModel = new AddProductToCartModel()
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
            AddProductToCartModel addProductToCartModel = new AddProductToCartModel()
            {
                UserId = UserId,
                CategoryName = "T-Shirts",
                ProductId = product1.Id,
                Quantity = 2,
                Size = "M"
            };
            AddProductToCartModel addProductToCartModelSecond = new AddProductToCartModel()
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
            AddProductToCartModel addProductToCartModel = new AddProductToCartModel()
            {
                UserId = UserId,
                CategoryName = "Shoes",
                ProductId = shoes1.Id,
                Quantity = 2,
                Size = "45"
            };
            AddProductToCartModel addProductToCartModelTwo = new AddProductToCartModel()
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
        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Database.EnsureDeleted();
        }
    }
}
