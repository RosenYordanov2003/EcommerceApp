namespace EcommerceApp.Tests.IntegrationTests
{
    using Moq;
    using Newtonsoft.Json;
    using Core.Models.Pictures;
    using Core.Models.Products;
    using System.Net.Http.Json;
    using System.Net;
    using Microsoft.AspNetCore.Http;
    using EcommerceApp.Core.Models.Review;
    using EcommerceApp.Core.Models.ProductStocks;

    [TestFixture]
    public class ShoesControllerTests
    {
        private CustomWebApplicationFactory webApplicationFactory;
        private HttpClient httpClient;

        public ShoesControllerTests()
        {
            webApplicationFactory = new CustomWebApplicationFactory();
            httpClient = webApplicationFactory.CreateClient();
        }
        [SetUp]
        public void SetUp()
        {
            IEnumerable<ProductFeatureModel> productFeatureModels = new List<ProductFeatureModel>()
            {
                new ProductFeatureModel()
                {
                    Id = 1,
                    CategoryName = "Shoes",
                    DicountPercentage =0,
                    IsFavorite = false,
                    Name = "Test Shoes1",
                    Pictures = new List<PictureModel>(),
                    Price = 150,
                    StarRating = 5
                },
                new ProductFeatureModel()
                {
                    Id = 2,
                    CategoryName = "Shoes",
                    DicountPercentage = 10,
                    IsFavorite = false,
                    Name = "Test Shoes2",
                    Pictures = new List<PictureModel>(),
                    Price = 100,
                    StarRating = 4
                },
            };
            webApplicationFactory.ShoesServiceMock.Setup(x => x.GetFeaturedShoesAsync(null))
                .ReturnsAsync(productFeatureModels);
        }
        [Test]
        public async Task TestGetFeaturedShoes()
        {
            var request = await httpClient.GetAsync("shoes/GetFeatured");

            var response = await request.Content.ReadAsStringAsync();
            var responseAsJson = JsonConvert.DeserializeObject<IEnumerable<ProductFeatureModel>>(response);

            int[] expectedIds = new int[2] { 1, 2 };
            string[] expectedNames = new string[2] { "Test Shoes1", "Test Shoes2" };

            Assert.IsNotNull(responseAsJson);
            CollectionAssert.AreEqual(responseAsJson.Select(x => x.Id), expectedIds);
            CollectionAssert.AreEqual(responseAsJson.Select(x => x.Name), expectedNames);
        }
        [Test]
        public async Task TestRemoveFromUserFavoriteShouldReturnsBadRequest()
        {
            UserFavoriteProductModel model = new UserFavoriteProductModel() { ProductId = 1, UserId = Guid.NewGuid() };
            webApplicationFactory.ShoesServiceMock.Setup(x => x.CheckIfShoesExistsByIdAsync(1)).ReturnsAsync(false);
            var request = await httpClient.PostAsync("shoes/RemoveFromFavorite", JsonContent.Create(model));

            Assert.That(request.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }
        [Test]
        public async Task TestRemoveFromUserFavoriteShouldReturnsOk()
        {
            UserFavoriteProductModel model = new UserFavoriteProductModel() { ProductId = 1, UserId = Guid.NewGuid() };
            webApplicationFactory.ShoesServiceMock.Setup(x => x.CheckIfShoesExistsByIdAsync(1)).ReturnsAsync(true);

            var request = await httpClient.PostAsync("shoes/RemoveFromFavorite", JsonContent.Create(model));

            Assert.That(request.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public async Task TestAddToFavoriteShouldReturnsBadRequest()
        {
            UserFavoriteProductModel model = new UserFavoriteProductModel() { ProductId = 1, UserId = Guid.NewGuid() };
            webApplicationFactory.ShoesServiceMock.Setup(x => x.CheckIfShoesExistsByIdAsync(1)).ReturnsAsync(false);
            var request = await httpClient.PostAsync("shoes/AddToFavorite", JsonContent.Create(model));

            Assert.That(request.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }
        [Test]
        public async Task TestAddToFavoriteShouldReturnsOk()
        {
            UserFavoriteProductModel model = new UserFavoriteProductModel() { ProductId = 1, UserId = Guid.NewGuid() };
            webApplicationFactory.ShoesServiceMock.Setup(x => x.CheckIfShoesExistsByIdAsync(1)).ReturnsAsync(true);

            var request = await httpClient.PostAsync("shoes/AddToFavorite", JsonContent.Create(model));

            Assert.That(request.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public async Task TestAboutShouldReturnsNotFound()
        {
            webApplicationFactory.ShoesServiceMock.Setup(x => x.CheckIfShoesExistsByIdAsync(1)).ReturnsAsync(false);
            var request = await httpClient.GetAsync($"shoes/About?productId=1&&userId={null}");

            Assert.That(request.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
        [Test]
        public async Task TestAboutShouldReturnsOk()
        {
            var expectedModel = new ProductInfoModel<double>()
            {
                CategoryName = "Shoes",
                Brand = "Nike",
                Description = "Test Description",
                Id = 3,
                DicountPercentage = 0,
                Gender = "Men",
                IsAvalilable = true,
                IsFavorite = false,
                Name = "Test",
                Price = 110,
                Pictures = new List<PictureModel>(),
                Reviews = new List<ReviewModel>(),
                ProductStocks = new List<ProductStock<double>>(),
                RelatedProducts = new List<ProductModel>(),
                StarRating = 5,
                TotalMilisecondsDifference = 0,
            };
            webApplicationFactory.ShoesServiceMock.Setup(x => x.CheckIfShoesExistsByIdAsync(1)).ReturnsAsync(true);
            webApplicationFactory.ShoesServiceMock.Setup(x => x.GetProductByIdAsync(1, null)).ReturnsAsync(expectedModel);

            var request = await httpClient.GetAsync($"shoes/About?productId=1&&userId={null}");
            var response = await request.Content.ReadAsStringAsync();
            var responseAsJson = JsonConvert.DeserializeObject<ProductInfoModel<double>>(response);

            Assert.IsNotNull(responseAsJson);
            Assert.That(request.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(responseAsJson.Id, Is.EqualTo(expectedModel.Id));
            Assert.That(responseAsJson.Name, Is.EqualTo(expectedModel.Name)); 
            Assert.That(responseAsJson.Price, Is.EqualTo(expectedModel.Price));
            Assert.That(responseAsJson.CategoryName, Is.EqualTo(expectedModel.CategoryName));
            Assert.That(responseAsJson.Brand, Is.EqualTo(expectedModel.Brand));
            Assert.That(responseAsJson.Gender, Is.EqualTo(expectedModel.Gender));
            Assert.That(responseAsJson.Description, Is.EqualTo(expectedModel.Description));
        }
        public void Dispose()
        {
            httpClient.Dispose();
            webApplicationFactory.Dispose();
        }
    }
}
