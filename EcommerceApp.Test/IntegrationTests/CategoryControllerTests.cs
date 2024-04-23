namespace EcommerceApp.Tests.IntegrationTests
{
    using NUnit.Framework;
    using Core.Models.Categories;
    using System.Net;
    using Newtonsoft.Json;

    public class CategoryControllerTests : IDisposable
    {
        private CustomWebApplicationFactory factory;
        private HttpClient httpClient;
        public CategoryControllerTests()
        {
            factory = new CustomWebApplicationFactory();
            httpClient = factory.CreateClient();
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
