namespace EcommerceApp.Tests.UnitTests
{
    using Microsoft.EntityFrameworkCore;
    using Core.Contracts;
    using Data;
    using static DatabaseSeeder;
    using Core.Services;
    using Core.Models.Orders;
    using Core.Models.Products;
    using Tests.UnitTests.Comparators;

    [TestFixture]
    public class OrderServiceTests
    {
        private ApplicationDbContext applicationDbContext;
        private IOrderService orderService;
        private DbContextOptions<ApplicationDbContext> dbContextOptions;

        [SetUp]
        public void SetUp()
        {
            dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase("EcommerceAppInMemoryDatabase" + Guid.NewGuid().ToString())
           .Options;
            applicationDbContext = new ApplicationDbContext(dbContextOptions, false);
            SeedDatabase(applicationDbContext);
            orderService = new OrderService(applicationDbContext);
        }
        [Test]
        [TestCase("62EF4EDD-0FF0-409D-AC89-F5A9334E9164")]
        [TestCase("8D566C2F-AB49-4BB5-83F2-956E4A2FEDF4")]
        [TestCase("4F7AE404-BE43-439C-9527-2202982EC0F5")]
        [TestCase("4B9F7C4A-525D-44BC-A30F-BEE4AB0390E0")]
        [TestCase("370D8A2A-7466-47F9-A5D1-3D8424E28541")]
        public async Task TestCheckIfOrderExistsByIdAsyncShouldReturnsTrue(string id)
        {
            Guid orderId = Guid.Parse(id);

            bool result = await orderService.CheckIfOrderExistsByIdAsync(orderId);

            Assert.IsTrue(result);
        }
        [Test]
        [TestCase("D43753A5-2452-4EEE-8DE1-8571A0D31B64")]
        [TestCase("19D0CA3B-42A7-45E6-9D85-5501D4CEBAA7")]
        [TestCase("74ADAAC6-5F31-4E97-8AB4-354A1FFE1484")]
        public async Task TestCheckIfOrderExistsByIdAsyncShouldReturnsFalse(string id)
        {
            Guid orderId = Guid.Parse(id);

            bool result = await orderService.CheckIfOrderExistsByIdAsync(orderId);

            Assert.IsFalse(result);
        }
        [Test]
        public async Task TestGetOrderDetailsByIdAsync()
        {
            OrderDetailsModel expectedModel = new OrderDetailsModel()
            {
                City = "Sofia",
                Country = "Bulgaria",
                Discount = 0,
                OrderStatus = "Delivered",
                ShippingAddress = "Test Address",
                TotalPrice = 100,
                Products = new List<ProductCartModel>()
                {
                    new ProductCartModel()
                    {
                        Id = 1,
                        CategoryName = "T-Shirts",
                        ImgUrl = null,
                        Name = product1.Name,
                        Price = product1.Price * 2,
                        Quantity = 2,
                        Size = "S"
                    }
                }
            };
            var actualModel = await orderService.GetOrderDetailsByIdAsync(order1.Id);

            Assert.That(actualModel.City, Is.EqualTo(expectedModel.City));
            Assert.That(actualModel.Country, Is.EqualTo(expectedModel.Country));
            Assert.That(actualModel.Discount, Is.EqualTo(expectedModel.Discount));
            Assert.That(actualModel.OrderStatus, Is.EqualTo(expectedModel.OrderStatus));
            Assert.That(actualModel.ShippingAddress, Is.EqualTo(expectedModel.ShippingAddress));
            Assert.That(actualModel.TotalPrice, Is.EqualTo(expectedModel.TotalPrice));
            CollectionAssert.AreEqual(expectedModel.Products, actualModel.Products, new ProductCartModelComparator());
        }
        [Test]
        public async Task TestMakeOrderAsync()
        {
            OrderModel orderModel = new OrderModel()
            {
                Discount = 0,
                TotalPrice = 100,
                UserId = userId,
                ShippingInfo = new ShippingInfoModel()
                {
                    Method = "Standard",
                    Price = 5
                },
                UserOrderInfo = new UserOrderInfoModel()
                {
                    City = "Sofia",
                    Country = "Bulgaia",
                    PostalCode = 1000,
                    Email = "test123@gmail.com",
                    FirstName = "Test",
                    LastName = "Testov",
                    PhoneNumber = "+35977554488",
                    StreetAdress = "Test Street"
                }
            };
            await orderService.MakeOrderAsync(orderModel);

            const int expectedOrdersCount = 6;
            int actualOrdersCount = await applicationDbContext.Orders.CountAsync();

            Assert.That(actualOrdersCount, Is.EqualTo(expectedOrdersCount));
        }
        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Dispose();
        }
    }
}
