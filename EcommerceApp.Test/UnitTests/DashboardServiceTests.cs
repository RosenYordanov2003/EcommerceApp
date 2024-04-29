namespace EcommerceApp.Tests.UnitTests
{
    using Microsoft.EntityFrameworkCore;
    using Core.Contracts;
    using Data;
    using Core.Services;
    using static DatabaseSeeder;
    using EcommerceApp.Core.Models.AdminModels.Dashboard;
    using EcommerceApp.Core.Models.AdminModels.Orders;

    [TestFixture]
    public class DashboardServiceTests
    {
        private ApplicationDbContext applicationDbContext;
        private IDashboardService dashboardService;
        private DbContextOptions<ApplicationDbContext> dbContextOptions;
        [SetUp]
        public void SetUp()
        {
            dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
             .UseInMemoryDatabase("EcommerceAppInMemoryDatabase" + Guid.NewGuid().ToString())
             .Options;
            applicationDbContext = new ApplicationDbContext(dbContextOptions, false);
            SeedDatabase(applicationDbContext);
            dashboardService = new DashboardService(applicationDbContext);
        }
        [Test]
        public async Task TestGetAllOrdersAsync()
        {
            var expectedIds = new Guid[5] { order1.Id, order2.Id, order3.Id, order4.Id, order5.Id };
            string[] expectedStatuses = Enumerable.Repeat("Delivered", 5).ToArray();
            decimal[] expectedprices = new decimal[5] { order1.Price, order2.Price, order3.Price, order4.Price, order5.Price };

            var actualResult = await dashboardService.GetAllOrdersAsync();

            CollectionAssert.AreEqual(expectedIds, actualResult.Select(x => x.Id));
            CollectionAssert.AreEqual(expectedStatuses, actualResult.Select(x => x.Status));
            CollectionAssert.AreEqual(expectedprices, actualResult.Select(x => x.Price));
        }
        [Test]
        public async Task TestGetDashboardInfoAsync()
        {
            DashboardModel expectedModel = new DashboardModel()
            {
                UserMessagesCount = 2,
                TotalSales = 800,
                TotalSalesForTheMonth = 0,
                Orders = new List<OrderModel>()
                {
                    new OrderModel()
                    {
                        Id = order1.Id,
                        Price = order1.Price,
                        Status = "Delivered"
                    },
                    new OrderModel()
                    {
                        Id = order2.Id,
                        Price = order2.Price,
                        Status = "Delivered"
                    },
                    new OrderModel()
                    {
                        Id = order3.Id,
                        Price = order3.Price,
                        Status = "Delivered"
                    },
                    new OrderModel()
                    {
                        Id = order4.Id,
                        Price = order4.Price,
                        Status = "Delivered"
                    },
                    new OrderModel()
                    {
                        Id = order5.Id,
                        Price = order5.Price,
                        Status = "Delivered"
                    }
                }
            };
            var actualModel = await dashboardService.GetDashboardInfoAsync(null, null);

            Assert.That(expectedModel.UserMessagesCount, Is.EqualTo(actualModel.UserMessagesCount));
            Assert.That(expectedModel.TotalSales, Is.EqualTo(actualModel.TotalSales));
            CollectionAssert.AreEqual(actualModel.Orders.Select(x => x.Id), expectedModel.Orders.Select(x => x.Id));
            CollectionAssert.AreEqual(actualModel.Orders.Select(x => x.Price), expectedModel.Orders.Select(x => x.Price));
            CollectionAssert.AreEqual(actualModel.Orders.Select(x => x.Status), expectedModel.Orders.Select(x => x.Status));
        }
        [Test]
        public async Task TestGetDashboardInfoAsyncWithParticularDateParameter()
        {
            DashboardModel expectedModel = new DashboardModel()
            {
                UserMessagesCount = 2,
                TotalSales = 800,
                TotalSalesForTheMonth = 0,
                Orders = new List<OrderModel>()
                {
                    new OrderModel()
                    {
                        Id = order1.Id,
                        Price = order1.Price,
                        Status = "Delivered"
                    },
                    new OrderModel()
                    {
                        Id = order2.Id,
                        Price = order2.Price,
                        Status = "Delivered"
                    },
                    new OrderModel()
                    {
                        Id = order3.Id,
                        Price = order3.Price,
                        Status = "Delivered"
                    },
                    new OrderModel()
                    {
                        Id = order4.Id,
                        Price = order4.Price,
                        Status = "Delivered"
                    },
                    new OrderModel()
                    {
                        Id = order5.Id,
                        Price = order5.Price,
                        Status = "Delivered"
                    }
                },
                TotalSalesForParticularDay = 800
            };
            var actualModel = await dashboardService.GetDashboardInfoAsync(new DateTime(2024, 3, 10), null);

            Assert.That(expectedModel.UserMessagesCount, Is.EqualTo(actualModel.UserMessagesCount));
            Assert.That(expectedModel.TotalSales, Is.EqualTo(actualModel.TotalSales));
            Assert.That(expectedModel.TotalSales, Is.EqualTo(actualModel.TotalSales));
            Assert.That(expectedModel.TotalSalesForParticularDay, Is.EqualTo(actualModel.TotalSalesForParticularDay));
            CollectionAssert.AreEqual(actualModel.Orders.Select(x => x.Id), expectedModel.Orders.Select(x => x.Id));
            CollectionAssert.AreEqual(actualModel.Orders.Select(x => x.Price), expectedModel.Orders.Select(x => x.Price));
            CollectionAssert.AreEqual(actualModel.Orders.Select(x => x.Status), expectedModel.Orders.Select(x => x.Status));
        }
        [Test]
        public async Task TestGetDashboardInfoAsyncWithParticularMotnhParameter()
        {
            DashboardModel expectedModel = new DashboardModel()
            {
                UserMessagesCount = 2,
                TotalSales = 800,
                TotalSalesForTheMonth = 0,
                Orders = new List<OrderModel>()
                {
                    new OrderModel()
                    {
                        Id = order1.Id,
                        Price = order1.Price,
                        Status = "Delivered"
                    },
                    new OrderModel()
                    {
                        Id = order2.Id,
                        Price = order2.Price,
                        Status = "Delivered"
                    },
                    new OrderModel()
                    {
                        Id = order3.Id,
                        Price = order3.Price,
                        Status = "Delivered"
                    },
                    new OrderModel()
                    {
                        Id = order4.Id,
                        Price = order4.Price,
                        Status = "Delivered"
                    },
                    new OrderModel()
                    {
                        Id = order5.Id,
                        Price = order5.Price,
                        Status = "Delivered"
                    }
                },
                TotalSalesForParticulMonth = 800
            };
            var actualModel = await dashboardService.GetDashboardInfoAsync(null, new DateTime(2024, 3, 10));

            Assert.That(expectedModel.UserMessagesCount, Is.EqualTo(actualModel.UserMessagesCount));
            Assert.That(expectedModel.TotalSales, Is.EqualTo(actualModel.TotalSales));
            Assert.That(expectedModel.TotalSales, Is.EqualTo(actualModel.TotalSales));
            Assert.That(expectedModel.TotalSalesForParticulMonth, Is.EqualTo(actualModel.TotalSalesForParticulMonth));
            CollectionAssert.AreEqual(actualModel.Orders.Select(x => x.Id), expectedModel.Orders.Select(x => x.Id));
            CollectionAssert.AreEqual(actualModel.Orders.Select(x => x.Price), expectedModel.Orders.Select(x => x.Price));
            CollectionAssert.AreEqual(actualModel.Orders.Select(x => x.Status), expectedModel.Orders.Select(x => x.Status));
        }
        [Test]
        public async Task TestGetRecentOrdersAsync()
        {
            var expectedIds = new Guid[5] { order1.Id, order2.Id, order3.Id, order4.Id, order5.Id };
            string[] expectedStatuses = Enumerable.Repeat("Delivered", 5).ToArray();
            decimal[] expectedprices = new decimal[5] { order1.Price, order2.Price, order3.Price, order4.Price, order5.Price };

            var actualResult = await dashboardService.GetRecentOrdersAsync();

            CollectionAssert.AreEqual(expectedIds, actualResult.Select(x => x.Id));
            CollectionAssert.AreEqual(expectedStatuses, actualResult.Select(x => x.Status));
            CollectionAssert.AreEqual(expectedprices, actualResult.Select(x => x.Price));
        }
        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Dispose();
        }
    }
}
