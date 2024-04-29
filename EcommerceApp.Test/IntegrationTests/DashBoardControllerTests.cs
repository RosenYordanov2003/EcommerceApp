namespace EcommerceApp.Tests.IntegrationTests
{
    using System.Net;
    using Moq;
    using Core.Models.AdminModels.Dashboard;
    using Core.Models.AdminModels.Orders;
    using Newtonsoft.Json;

    [TestFixture]
    public class DashBoardControllerTests
    {
        private CustomWebApplicationFactory factory;
        private HttpClient client;
        private DashboardModel dashboardModel;
        private OrderModel orderModel;

        [SetUp]
        public void SetUp()
        {
            factory = new CustomWebApplicationFactory();
            client = factory.CreateClient();
            orderModel = new OrderModel()
            {
                Id = Guid.Parse("3524875D-0566-4805-A1A8-768F78190E6B"),
                Price = 100,
                Status = "Pending"
            };
            dashboardModel = new DashboardModel()
            {
                UserMessagesCount = 2,
                TotalSales = 800,
                TotalSalesForParticularDay = 0,
                TotalSalesForTheMonth = 0,
                TotalSalesForParticulMonth = 0,
                Orders = new List<OrderModel>() { orderModel }
            };
            factory.DashboardServiceMock.Setup(x => x.GetDashboardInfoAsync(null, null)).ReturnsAsync(dashboardModel);
            factory.DashboardServiceMock.Setup(x => x.GetAllOrdersAsync()).ReturnsAsync(new List<OrderModel>() { orderModel });
            factory.DashboardServiceMock.Setup(x => x.GetRecentOrdersAsync()).ReturnsAsync(new List<OrderModel>() { orderModel});
        }
        [Test]
        public async Task TestGetDashboardShouldReturnsOk()
        {
            var request = await client.GetAsync("api/dashboard/Dashboard");

            Assert.That(request.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public async Task TestGetDashboardShouldReturnsDashboardInfo()
        {
            var request = await client.GetAsync("api/dashboard/Dashboard");

            var response = await request.Content.ReadAsStringAsync();

            var payload = JsonConvert.DeserializeObject<DashboardModel>(response);

            const int expectedOrdersCount = 1;

            Assert.IsNotNull(payload);
            Assert.That(dashboardModel.TotalSales, Is.EqualTo(payload.TotalSales));
            Assert.That(dashboardModel.UserMessagesCount, Is.EqualTo(payload.UserMessagesCount));
            Assert.That(dashboardModel.TotalSalesForParticulMonth, Is.EqualTo(payload.TotalSalesForParticulMonth));
            Assert.That(dashboardModel.TotalSalesForParticularDay, Is.EqualTo(payload.TotalSalesForParticularDay));
            Assert.That(dashboardModel.TotalSalesForTheMonth, Is.EqualTo(payload.TotalSalesForTheMonth));
            Assert.That(dashboardModel.Orders.Count(), Is.EqualTo(expectedOrdersCount));
            Assert.That(request.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public async Task TestGetAllOrdersShouldReturnsOk()
        {
            var request = await client.GetAsync("api/dashboard/AllOrders");

            Assert.That(request.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public async Task TestGetAllOrdersShouldReturnsOrdersPayload()
        {
            var request = await client.GetAsync("api/dashboard/AllOrders");

            var response = await request.Content.ReadAsStringAsync();

            var payload = JsonConvert.DeserializeObject<IEnumerable<OrderModel>>(response);

            Guid[] expectedIds = new Guid[1] { Guid.Parse("3524875D-0566-4805-A1A8-768F78190E6B") };
            string[] expectedStatuses = new string[1] { "Pending" };
            decimal[] expectedPrices = new decimal[1] { 100 };  

            Assert.IsNotNull(payload);
            CollectionAssert.AreEqual(payload.Select(x => x.Id), expectedIds);
            CollectionAssert.AreEqual(payload.Select(x => x.Status), expectedStatuses);
            CollectionAssert.AreEqual(payload.Select(x => x.Price), expectedPrices);

            Assert.That(request.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public async Task TestGetRecentOrdersAsyncShouldReturnsOk()
        {
            var request = await client.GetAsync("api/dashboard/RecentOrders");

            Assert.That(request.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public async Task TestGetRecentOrdersAsyncShouldReturnsOrdersPayload()
        {
            var request = await client.GetAsync("api/dashboard/RecentOrders");

            var response = await request.Content.ReadAsStringAsync();

            var payload = JsonConvert.DeserializeObject<IEnumerable<OrderModel>>(response);

            Guid[] expectedIds = new Guid[1] { Guid.Parse("3524875D-0566-4805-A1A8-768F78190E6B") };
            string[] expectedStatuses = new string[1] { "Pending" };
            decimal[] expectedPrices = new decimal[1] { 100 };

            Assert.IsNotNull(payload);
            CollectionAssert.AreEqual(payload.Select(x => x.Id), expectedIds);
            CollectionAssert.AreEqual(payload.Select(x => x.Status), expectedStatuses);
            CollectionAssert.AreEqual(payload.Select(x => x.Price), expectedPrices);

            Assert.That(request.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [TearDown]
        public void TearDown()
        {
            factory.Dispose();
            client.Dispose();
        }
    }
}
