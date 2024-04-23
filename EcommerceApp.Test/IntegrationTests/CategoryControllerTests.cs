namespace EcommerceApp.Tests.IntegrationTests
{
    using System.Net;
    using NUnit.Framework;
    using Newtonsoft.Json;
    using Moq;
    using Core.Models.Categories;

    [TestFixture]
    public class CategoryControllerTests : IDisposable
    {
        private CustomWebApplicationFactory factory;
        private HttpClient httpClient;
        public CategoryControllerTests()
        {
            factory = new CustomWebApplicationFactory();
            httpClient = factory.CreateClient();
        }
        [SetUp]
        public void SetUp()
        {
            IEnumerable<CategoryModel> categoryModelCollectionMen = new CategoryModel[2] { new CategoryModel() { Id = 1, Name = "Shoes" }, new CategoryModel() { Id = 2, Name = "Trousers" } };
            IEnumerable<CategoryModel> categoryModelCollectionWomen = new CategoryModel[2] { new CategoryModel() { Id = 1, Name = "Shoes" }, new CategoryModel() { Id = 2, Name = "Skirts" } };

            factory.CategoryServiceMock.Setup(x => x.GetCategoriesByGender("men")).ReturnsAsync(categoryModelCollectionMen);
            factory.CategoryServiceMock.Setup(x => x.GetCategoriesByGender("women")).ReturnsAsync(categoryModelCollectionWomen);
        }
        [Test]
        public async Task TestGetCategoriesByGenderWithMen()
        {
            var response = await httpClient.GetAsync("api/categories/get?gender=men");
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<CategoryModel>>(responseContent);

            int[] expectedIds = new int[2] { 1, 2 };
            string[] expectedNames = new string[2] { "Shoes", "Trousers" };


            Assert.IsNotNull(result);

            CollectionAssert.AreEqual(expectedIds, result.Select(x => x.Id));
            CollectionAssert.AreEqual(expectedNames, result.Select(x => x.Name));

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public async Task TestGetCategoriesByGenderWithWomen()
        {
            var response = await httpClient.GetAsync("api/categories/get?gender=women");
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<CategoryModel>>(responseContent);

            int[] expectedIds = new int[2] { 1, 2 };
            string[] expectedNames = new string[2] { "Shoes", "Skirts" };


            Assert.IsNotNull(result);

            CollectionAssert.AreEqual(expectedIds, result.Select(x => x.Id));
            CollectionAssert.AreEqual(expectedNames, result.Select(x => x.Name));

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        public void Dispose()
        {
            httpClient.Dispose();
            factory.Dispose();
        }
    }
}
