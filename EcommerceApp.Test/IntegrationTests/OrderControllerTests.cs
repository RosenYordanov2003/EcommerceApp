namespace EcommerceApp.Tests.IntegrationTests
{
    using EcommerceApp.Core.Models.Orders;
    using Moq;
    using System.Net;

    [TestFixture]
    public class OrderControllerTests : IDisposable
    {
        private CustomWebApplicationFactory webApplicationFactory;
        private HttpClient httpClient;

        [SetUp]
        public void SetUp()
        {
            webApplicationFactory = new CustomWebApplicationFactory();
            httpClient = webApplicationFactory.CreateClient();
        }
        [Test]
        public async Task TestGetOrderDetailsShouldReturnsNotFound()
        {
            webApplicationFactory.OrderServiceMock.Setup(x => x.CheckIfOrderExistsByIdAsync(It.IsAny<Guid>())).ReturnsAsync(false);

            var request = await httpClient.GetAsync("api/order/Details");

            Assert.That(request.StatusCode,  Is.EqualTo(HttpStatusCode.NotFound));
        }
        [Test]
        public async Task TestGetOrderDetailsShouldReturnsOk()
        {
            webApplicationFactory.OrderServiceMock.Setup(x => x.CheckIfOrderExistsByIdAsync(It.IsAny<Guid>())).ReturnsAsync(true);

            OrderDetailsModel model = new OrderDetailsModel()
            {
                City = "Sofia",
                Country = "Bulgarua",
                Discount = 0,
                OrderStatus = "Pending",
                ShippingAddress = "testov",
                TotalPrice = 200,
                ShippingMethod = "fast"
            };

            webApplicationFactory.OrderServiceMock.Setup(x => x.GetOrderDetailsByIdAsync(It.IsAny<Guid>())).ReturnsAsync(model);
            var request = await httpClient.GetAsync("api/order/Details");

            Assert.That(request.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        public void Dispose()
        {
            webApplicationFactory.Dispose();
            httpClient.Dispose();
        }
    }
}
