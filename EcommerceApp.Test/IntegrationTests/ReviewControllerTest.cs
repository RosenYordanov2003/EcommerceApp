using EcommerceApp.Core.Models.Pager;
using EcommerceApp.Core.Models.Products;
using EcommerceApp.Core.Models.Review;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Net;
using System.Net.Http.Json;

namespace EcommerceApp.Tests.IntegrationTests
{
    [TestFixture]
    public class ReviewControllerTest : IDisposable
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
        public async Task TestPostReviewShouldReturnsBadRequest()
        {
            CreateReviewModel model = new CreateReviewModel()
            {
                Content = "Test",
                ProductCategory = "shoes",
                StarRating = 5,
                UserId = Guid.NewGuid(),
                UserName = "test",
                ProductId = 1,
                Subject = "Test1234"
            };
            var request = await httpClient.PostAsync("api/reviews/PostReview", JsonContent.Create(model));

            Assert.That(request.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }
        [Test]
        public async Task TestPostReviewShouldReturnsOk()
        {
            CreateReviewModel model = new CreateReviewModel()
            {
                Content = "Test123",
                ProductCategory = "shoes",
                StarRating = 5,
                UserId = Guid.NewGuid(),
                UserName = "Gosho123",
                ProductId = 1,
                Subject = "About product"
            };
            ProductInfoModel<double> productInfoModel = new ProductInfoModel<double>()
            {
                CategoryName = "Shoes",
                Brand = "Nike",
                Description = "Test description",
                DicountPercentage = 0,
                Gender = "men",
                IsAvalilable = true,
                IsFavorite = false,
                Name = "test",
                Price = 10,
                StarRating = 5,
                TotalMilisecondsDifference = 0,
            };
            var request = await httpClient.PostAsync("api/reviews/PostReview", JsonContent.Create(model));
            webApplicationFactory.ShoesServiceMock.Setup(x => x.GetProductByIdAsync(It.IsAny<int>(), It.IsAny<Guid>())).ReturnsAsync(productInfoModel);
            Assert.That(request.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public async Task TestAllReviewsShouldReturnsOk()
        {
            var result = new List<ReviewModel>()
            {
                new ReviewModel()
                {
                    Content = "Test123",
                    Id = 1,
                    StarEvaluation = 4,
                    TimeDifferenceFormat = "1 day",
                    Subject = "about product",
                    Username = "Gosho",
                    UserId = Guid.NewGuid()
                }
            };

            webApplicationFactory.ReviewServiceMock.Setup(x => x.GetTotalReviewsCountByProductIdAndCategoryNameAsync(It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(1);
            webApplicationFactory.ReviewServiceMock.Setup(x => x.LoadReviewsForParticularProductAsync(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<Pager>())).ReturnsAsync(result);

            var request = await httpClient.GetAsync("api/reviews/AllReviews?productId=1&&productCategory=shoes");
            Assert.That(request.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public async Task TestGetReviewToEditShouldReturnsNotFound()
        {
            Guid userId = Guid.Parse("C27A09C9-F06C-49CB-9FBD-03BA1FA66213");
            int reviewId = 1;

            webApplicationFactory.ReviewServiceMock.Setup(x => x.CheckUserReviewExists(It.IsAny<int>(), It.IsAny<Guid>())).ReturnsAsync(false);

            var request = await httpClient.GetAsync($"api/reviews/GetReviewToEdit?reviewIdId={reviewId}&&userId={userId}");

            Assert.That(request.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
        [Test]
        public async Task TestGetReviewToEditShouldReturnsOk()
        {
            Guid userId = Guid.Parse("C27A09C9-F06C-49CB-9FBD-03BA1FA66213");
            int reviewId = 1;

            webApplicationFactory.ReviewServiceMock.Setup(x => x.CheckUserReviewExists(It.IsAny<int>(), It.IsAny<Guid>())).ReturnsAsync(true);

            EditReviewModel editReviewModel = new EditReviewModel()
            {
                Content = "test123",
                Id = 1,
                StarEvaluation = 4,
                Subject = "about product"
            };
            webApplicationFactory.ReviewServiceMock.Setup(x => x.GetReviewToEditAsync(It.IsAny<int>())).ReturnsAsync(editReviewModel);
            var request = await httpClient.GetAsync($"api/reviews/GetReviewToEdit?reviewIdId={reviewId}&&userId={userId}");

            Assert.That(request.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public async Task TestEditReviewShouldReturnsNotFound()
        {
            EditReviewModel model = new EditReviewModel()
            {
                Content = "test1234",
                Id = 1,
                StarEvaluation = 5,
                Subject = "about product"
            };
            webApplicationFactory.ReviewServiceMock.Setup(x => x.CheckIfReviewExistsByIdAsync(It.IsAny<int>())).ReturnsAsync(false);
            var request = await httpClient.PostAsync("api/reviews/EditReview", JsonContent.Create(model));

            Assert.That(request.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
        [Test]
        public async Task TestEditReviewShouldReturnsOk()
        {
            EditReviewModel model = new EditReviewModel()
            {
                Content = "test1234",
                Id = 1,
                StarEvaluation = 5,
                Subject = "about product"
            };
            webApplicationFactory.ReviewServiceMock.Setup(x => x.CheckIfReviewExistsByIdAsync(It.IsAny<int>())).ReturnsAsync(true);
            var request = await httpClient.PostAsync("api/reviews/EditReview", JsonContent.Create(model));

            Assert.That(request.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public async Task TestDeleteReviewShouldReturnsNotFound()
        {
            webApplicationFactory.ReviewServiceMock.Setup(x => x.CheckIfReviewExistsByIdAsync(It.IsAny<int>())).ReturnsAsync(false);
            var request = await httpClient.PostAsync("api/reviews/DeleteReview", JsonContent.Create(1));

            Assert.That(request.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
        [Test]
        public async Task TestDeleteReviewShouldReturnsOk()
        {
            webApplicationFactory.ReviewServiceMock.Setup(x => x.CheckIfReviewExistsByIdAsync(It.IsAny<int>())).ReturnsAsync(true);
            var request = await httpClient.PostAsync("api/reviews/DeleteReview", JsonContent.Create(1));

            Assert.That(request.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public async Task TestGetReviewsPerPageShouldReturnsOk()
        {
            var result = new List<ReviewModel>()
            {
                new ReviewModel()
                {
                    Content = "Test123",
                    Id = 1,
                    StarEvaluation = 4,
                    TimeDifferenceFormat = "1 day",
                    Subject = "about product",
                    Username = "Gosho",
                    UserId = Guid.NewGuid()
                }
            };

            webApplicationFactory.ReviewServiceMock.Setup(x => x.GetTotalReviewsCountByProductIdAndCategoryNameAsync(It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(1);
            webApplicationFactory.ReviewServiceMock.Setup(x => x.LoadReviewsForParticularProductAsync(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<Pager>())).ReturnsAsync(result);
            var request = await httpClient.GetAsync("api/reviews/GetReviewsPerPage?currentPage=1&&categoryName=shoes&&pageSize=5");

            Assert.That(request.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        public void Dispose()
        {
            webApplicationFactory.Dispose();
            httpClient.Dispose();
        }
    }
}
