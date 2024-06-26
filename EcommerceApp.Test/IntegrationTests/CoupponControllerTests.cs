﻿namespace EcommerceApp.Tests.IntegrationTests
{
    using System.Net.Http.Json;
    using Moq;
    using Newtonsoft.Json;
    using Core.Models.PromotionCodes;
    using System.Net;

    [TestFixture]
    public class CoupponControllerTests
    {
        private CustomWebApplicationFactory webApplicationFactory;
        private HttpClient httpClient;
        private readonly Guid userId = Guid.Parse("AD66A991-468B-4B38-9E43-C57A6BF580A7");
        private readonly Guid id = Guid.Parse("AD66A991-468B-4B38-9E43-C57A6BF580A7");
        private readonly PromotionCodeApplyModel model = new PromotionCodeApplyModel();

        public CoupponControllerTests()
        {
            webApplicationFactory = new CustomWebApplicationFactory();
            httpClient = webApplicationFactory.CreateClient();
        }
        [SetUp]
        public void SetUp()
        {
            model.CouponId = id;
            model.UserId = userId;
        }
        [Test]
        public async Task TestApplyCupponWithNoExistingCoupon()
        {
            webApplicationFactory.CouponServiceMock.Setup(x => x.CheckIfCouponExistByIdAsync(id)).ReturnsAsync(false);

            var modelAsJson = JsonConvert.SerializeObject(model);
            var request = await httpClient.PostAsync("api/coupon/Apply", JsonContent.Create(model));

            Assert.That(request.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
        [Test]
        public async Task TestApplyCouponWithNoRelatedUser()
        {
            webApplicationFactory.CouponServiceMock.Setup(x => x.CheckIfCouponExistByIdAsync(id)).ReturnsAsync(true);
            webApplicationFactory.CouponServiceMock.Setup(x => x.CheckIfCouponIsRelatedWithParticularUserAsync(id, userId)).ReturnsAsync(false);

            var modelAsJson = JsonConvert.SerializeObject(model);
            var request = await httpClient.PostAsync("api/coupon/Apply", JsonContent.Create(model));

            Assert.That(request.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }
        [Test]
        public async Task TestApplyCouponWithExpiredCoupon()
        {
            webApplicationFactory.CouponServiceMock.Setup(x => x.CheckIfCouponExistByIdAsync(id)).ReturnsAsync(true);
            webApplicationFactory.CouponServiceMock.Setup(x => x.CheckIfCouponIsRelatedWithParticularUserAsync(id, userId)).ReturnsAsync(true);

            var modelAsJson = JsonConvert.SerializeObject(model);
            var request = await httpClient.PostAsync("api/coupon/Apply", JsonContent.Create(model));

            Assert.That(request.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public async Task TestApplyCouponShouldReturnSuccess()
        {

            CouponModel couponModel = new CouponModel() { DiscountPercantages = 10, ExpirationTime = DateTime.Now.AddDays(200), Id = id };

            webApplicationFactory.CouponServiceMock.Setup(x => x.CheckIfCouponExistByIdAsync(id)).ReturnsAsync(true);
            webApplicationFactory.CouponServiceMock.Setup(x => x.CheckIfCouponIsRelatedWithParticularUserAsync(id, userId)).ReturnsAsync(true);
            webApplicationFactory.CouponServiceMock.Setup(x => x.CheckIfCouponHasExpiredByIdAsync(id)).ReturnsAsync(false);
            webApplicationFactory.CouponServiceMock.Setup(x => x.GetCouponByIdAsync(id)).ReturnsAsync(couponModel);

            var modelAsJson = JsonConvert.SerializeObject(model);
            var request = await httpClient.PostAsync("api/coupon/Apply", JsonContent.Create(model));
            var response = await request.Content.ReadAsStringAsync();

            var responseAsJson = JsonConvert.DeserializeObject<Response>(response);

            Assert.IsNotNull(responseAsJson);
            Assert.That(responseAsJson.Cuppon.DiscountPercantages, Is.EqualTo(10));
            Assert.That(request.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.IsTrue(responseAsJson.Success);
        }
        public void Dispose()
        {
            httpClient.Dispose();
            webApplicationFactory.Dispose();
        }
    }
    public class Response
    {
        public bool Success { get; set; }
        public CouponModel Cuppon { get; set; } = null!;
    }
}
