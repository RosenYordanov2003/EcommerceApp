namespace EcommerceApp.Tests.UnitTests
{
    using Microsoft.EntityFrameworkCore;
    using Core.Contracts;
    using Core.Services;
    using Data;
    using static DatabaseSeeder;
    using EcommerceApp.Infrastructure.Data.Models;

    [TestFixture]
    public class ProductStockServiceTests
    {
        private ApplicationDbContext applicationDbContext;
        private IProductStockService productStockService;
        private DbContextOptions<ApplicationDbContext> dbContextOptions;

        [SetUp]
        public void Setup()
        {
            dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("EcommerceAppInMemoryDatabase" + Guid.NewGuid().ToString())
               .Options;
            applicationDbContext = new ApplicationDbContext(dbContextOptions, false);
            SeedDatabase(applicationDbContext);
            productStockService = new ProductStockService(applicationDbContext);
        }
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public async Task TestCheckForProductQuantityAsyncWithShoesShouldReturnsTrue(int quantity)
        {
            bool result = await productStockService.CheckForProductQuantityAsync("Shoes", shoes2.Id, "45", quantity);

            Assert.IsTrue(result);
        }
        [Test]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(99)]
        public async Task TestCheckForProductQuantityAsyncWithShoesShouldReturnsFalse(int quantity)
        {
            bool result = await productStockService.CheckForProductQuantityAsync("Shoes", shoes2.Id, "45", quantity);

            Assert.IsFalse(result);
        }
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public async Task TestCheckForProductQuantityAsyncWithClothesShouldReturnsTrue(int quantity)
        {
            bool result = await productStockService.CheckForProductQuantityAsync("T-Shirts", product1.Id, "S", quantity);

            Assert.IsTrue(result);
        }
        [Test]
        [TestCase(99)]
        [TestCase(6)]
        [TestCase(7)]
       
        public async Task TestCheckForProductQuantityAsyncWithClothesShouldReturnsFalse(int quantity)
        {
            bool result = await productStockService.CheckForProductQuantityAsync("T-Shirts", product1.Id, "S", quantity);

            Assert.IsFalse(result);
        }
        [Test]
        public async Task TestDecreaseProductStockQuantityWithShoes()
        {
            await productStockService.DecreaseProductStockQuantity("shoes", shoes2.Id, "45", 2);
            const int expectedResult = 3;
            Assert.That(expectedResult, Is.EqualTo(shoesStock1.Quantity));
        }
        [Test]
        public async Task TestDecreaseProductStockQuantityWithTshirt()
        {
            await productStockService.DecreaseProductStockQuantity("T-Shirts", product1.Id, "S", 5);
            const int expectedResult = 0;
            Assert.That(expectedResult, Is.EqualTo(productStock1.Quantity));
        }
        [Test]
        public async Task TestIncreaseProductStockQuantityWithShoes()
        {
            await productStockService.IncreaseProductStockQuantity("shoes", shoes2.Id, "45", 2);
            const int expectedResult = 7;
            Assert.That(expectedResult, Is.EqualTo(shoesStock1.Quantity));
        }
        [Test]
        public async Task TestIncreaseProductStockQuantityWithClothes()
        {
            await productStockService.IncreaseProductStockQuantity("T-Shirts", product1.Id, "S", 12);
            const int expectedResult = 17;
            Assert.That(expectedResult, Is.EqualTo(productStock1.Quantity));
        }
        [Test]
        public async Task TestAddDefaultQuantityWithShoes()
        {
            await productStockService.AddDefaultQuantity(shoes1.Id, "Shoes");
            ShoesStock stock = await applicationDbContext.ShoesStock.FirstAsync(x => x.ShoesId == shoes1.Id);

            const int expectedResult = 10;

            Assert.That(expectedResult, Is.EqualTo(stock.Quantity));
        }
        [Test]
        public async Task TestAddDefaultQuantityWithClothes()
        {
            await productStockService.AddDefaultQuantity(product3.Id, "T-shirts");
            ProductStock stock = await applicationDbContext.ProductStocks.FirstAsync(x => x.ProductId == product3.Id);

            const int expectedResult = 10;

            Assert.That(expectedResult, Is.EqualTo(stock.Quantity));
        }
        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Dispose();
        }
    }
}
