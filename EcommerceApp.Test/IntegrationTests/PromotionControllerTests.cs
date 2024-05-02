using EcommerceApp.Core.Models.AdminModels.Promotion;
using EcommerceApp.Core.Models.Pager;
using Moq;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using System.Text;

namespace EcommerceApp.Tests.IntegrationTests
{
    public class PromotionControllerTests
    {
        private CustomWebApplicationFactory factory;
        private HttpClient client;

        [SetUp]
        public void SetUp()
        {
            factory = new CustomWebApplicationFactory();
            client = factory.CreateClient();
        }
        [Test]
        public async Task TestAddPromotionShouldReturnsBadRequest()
        {
            AddPromotionModel model = new AddPromotionModel()
            {
                ProductCategory = "Shoes",
                ExpirationTime = DateTime.Now.AddMonths(2),
                Percentages = 0,
                ProductId = 1
            };
            var request = await client.PostAsync("api/promotion/AddPromotion", JsonContent.Create(model));

            Assert.That(request.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }
        [Test]
        public async Task TestAddPromotionShouldReturnsOk()
        {
            AddPromotionModel model = new AddPromotionModel()
            {
                ProductCategory = "Shoes",
                ExpirationTime = DateTime.Now.AddMonths(2),
                Percentages = 10,
                ProductId = 1
            };
            var request = await client.PostAsync("api/promotion/AddPromotion", JsonContent.Create(model));

            Assert.That(request.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public async Task TestRemovePromotionShouldReturnsNotFound()
        {
            var json = JsonConvert.SerializeObject(Guid.Parse("BB84FB8E-8977-4CDE-8F8E-D76B07260BF0"));

            factory.PromotionServiceMock.Setup(x => x.CheckIfPromotionExistsByIdAsync(It.IsAny<Guid>())).ReturnsAsync(false);

            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json"),
                Method = HttpMethod.Delete,
                RequestUri = new Uri("http://localhost/api/promotion/RemovePromotion")
            };
            var result = await client.SendAsync(request);

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
        [Test]
        public async Task TestRemovePromotionShouldReturnsOk()
        {
            var json = JsonConvert.SerializeObject(Guid.Parse("BB84FB8E-8977-4CDE-8F8E-D76B07260BF0"));

            factory.PromotionServiceMock.Setup(x => x.CheckIfPromotionExistsByIdAsync(It.IsAny<Guid>())).ReturnsAsync(true);

            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json"),
                Method = HttpMethod.Delete,
                RequestUri = new Uri("http://localhost/api/promotion/RemovePromotion")
            };
            var result = await client.SendAsync(request);

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public async Task TestClearExpiredPromotionscShouldReturnsOk()
        {
            var request = await client.PostAsync("api/promotion/Clear", JsonContent.Create(1));

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
