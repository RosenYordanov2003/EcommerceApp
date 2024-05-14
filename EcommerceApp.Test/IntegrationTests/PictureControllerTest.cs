namespace EcommerceApp.Tests.IntegrationTests
{
    using Microsoft.AspNetCore.Http;
    using Core.Models.AdminModels.Clothes;
    using System.Net.Http.Json;
    using Moq;
    using System.Net;
    using System.Net.Http.Headers;
    using EcommerceApp.Core.Models.AdminModels.Pictures;
    using static Google.Apis.Requests.BatchRequest;
    using System.Text;
    using Newtonsoft.Json;
    using Microsoft.AspNetCore.Mvc;
    using System;

    [TestFixture]
    public class PictureControllerTest : IDisposable
    {
        private CustomWebApplicationFactory factory;
        private HttpClient httpClient;

        [SetUp]
        public void SetUp()
        {
            factory = new CustomWebApplicationFactory();
            httpClient = factory.CreateClient();
        }
        [Test]
        public async Task TestUploadImgShouldReturnsOk()
        {
            factory.PictureServiceMock.Setup(x => x.UploadImgAsync(It.IsAny<UploadProductImgModel>(), It.IsAny<string>()));
            
            // Add File property with file content
            HttpResponseMessage response;

            using (FileStream file = File.OpenRead("C:\\Users\\Home\\Desktop\\Ecomemrce App Remote\\EcommerceApp\\EcommerceApp.Test\\IntegrationTests\\TestPhotos\\pug.png"))
            using (StreamContent content = new StreamContent(file))
            using (MultipartFormDataContent formData = new MultipartFormDataContent())
            {
                // Add file (file, field name, file name)
                formData.Add(content, "PictureFile", "pug.png");
                formData.Add(new StringContent("1"), "ProductId");
                formData.Add(new StringContent("Shoes"), "ProductCategory");

                response = await httpClient.PostAsync("api/picture/UploadImg", formData);
            }

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public async Task TestDeleteImgShouldReturnsBadRequest()
        {
            factory.PictureServiceMock.Setup(x => x.CheckIfImgExistsAsync(It.IsAny<int>())).ReturnsAsync(false);
            DeletePictureModel model = new DeletePictureModel()
            {
                Id = 1,
                PictureProductCategory = "Shoes",
                ImgUrl = "Test123"
            };
            var jsonResult = JsonConvert.SerializeObject(model);
            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = new StringContent(jsonResult, Encoding.UTF8, "application/json"),
                Method = HttpMethod.Delete,
                RequestUri = new Uri("http://localhost/api/picture/DeleteImg")
            };
            var result = await httpClient.SendAsync(request);
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }
        [Test]
        public async Task TestDeleteImgShouldReturnsOk()
        {
            factory.PictureServiceMock.Setup(x => x.CheckIfImgExistsAsync(It.IsAny<int>())).ReturnsAsync(true);
            DeletePictureModel model = new DeletePictureModel()
            {
                Id = 1,
                PictureProductCategory = "Shoes",
                ImgUrl = "Test123"
            };
            var jsonResult = JsonConvert.SerializeObject(model);
            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = new StringContent(jsonResult, Encoding.UTF8, "application/json"),
                Method = HttpMethod.Delete,
                RequestUri = new Uri("http://localhost/api/picture/DeleteImg")
            };
            var result = await httpClient.SendAsync(request);
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        public void Dispose()
        {
            httpClient.Dispose();
            factory.Dispose();
        }
    }
}
