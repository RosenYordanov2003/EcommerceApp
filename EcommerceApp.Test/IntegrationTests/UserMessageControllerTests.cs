namespace EcommerceApp.Tests.IntegrationTests
{
    using System.Net;
    using System.Net.Http.Json;
    using Core.Models.UserMessage;
    using Core.Models.AdminModels.UserMessages;
    using Core.Models.Pager;
    using Models.Responses;
    using Moq;
    using Newtonsoft.Json;
    using Microsoft.AspNetCore.Identity;
    using Infrastructure.Data.Models;
    using System.Net.Http;
    using System.Text;

    [TestFixture]
    public class UserMessageControllerTests
    {
        private CustomWebApplicationFactory factory;
        private HttpClient client;

        [SetUp]
        public void SetUp()
        {
            factory = new CustomWebApplicationFactory();
            client = factory.CreateClient();
            factory.UserMessageServiceMock.Setup(x => x.GetMessageCountAsync()).ReturnsAsync(3);
        }
        [Test]
        public async Task TestUploadMessageShouldReturnsOk()
        {
            UploadUserMessageModel model = new UploadUserMessageModel()
            {
                Message = "Test123",
                UserId = Guid.Parse("AE440EFF-09C2-4900-95F8-8A400763F351")
            };

            var request = await client.PostAsync("api/userMessage/Upload", JsonContent.Create(model));

            Assert.That(request.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public async Task TestGetMessageCountSgouldReturnsOk()
        {
            const int expectedPayloadResult = 3;
            var request = await client.GetAsync("api/userMessage/GetCount");

            var response = await request.Content.ReadAsStringAsync();

            var responseAsJson = JsonConvert.DeserializeObject<int>(response);

            Assert.IsNotNull(responseAsJson);
            Assert.That(responseAsJson, Is.EqualTo(expectedPayloadResult));
            Assert.That(request.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public  async Task TestGetAllMessages()
        {
            List<UserMessageCardModel> model = new List<UserMessageCardModel>()
            {
                new UserMessageCardModel()
                {
                    Id = Guid.Parse("47C5DC97-CB2A-4BC6-B325-2CD8E0E2492D"),
                    ElapsedTime = "1111",
                    IsResponded = false,
                    Message = "My test message",
                    Username = "Test Testov12345"
                },
                new UserMessageCardModel()
                {
                    Id = Guid.Parse("D545378C-6D8A-481C-9EBE-A3718B88B71D"),
                    ElapsedTime = "10000",
                    IsResponded = false,
                    Message = "My test message again",
                    Username = "Test Testov123456"
                },
            };
            factory.UserMessageServiceMock.Setup(x => x.GetUserMessagesAsync(It.IsAny<Pager>())).ReturnsAsync(model);


            var request = await client.GetAsync("api/userMessage/GetAll?currentPage=1");

            var response = await request.Content.ReadAsStringAsync();

            var responseAsJson = JsonConvert.DeserializeObject<GetAllUserMessagesResponse>(response);

            Guid[] expectedIds = new Guid[2] { Guid.Parse("47C5DC97-CB2A-4BC6-B325-2CD8E0E2492D"), Guid.Parse("D545378C-6D8A-481C-9EBE-A3718B88B71D") };

            Assert.That(request.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.IsNotNull(responseAsJson);
            CollectionAssert.AreEqual(expectedIds, responseAsJson.Messages.Select(x => x.Id));
        }
        [Test]
        public async Task TestRespondToUserMessageShouldReturnsBadRequest()
        {
            var model = new RespondUserMessageModel()
            {
                Message = "Test Message Again",
                MessageId = Guid.Parse("0C09C0A3-DA6F-4DB7-82B9-F8BEE9159D47"),
                ResponseMessage = "My response message",
                UserId = Guid.Parse("585D7252-A95A-4493-8CE7-0246849050B7")
            };
            factory.UserMessageServiceMock.Setup(x => x.CheckIfMessageExistsByIdAsync(It.IsAny<Guid>())).ReturnsAsync(false);

            var request = await client.PostAsync("api/userMessage/Respond", JsonContent.Create(model));

            Assert.That(request.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }
        [Test]
        public async Task TestRespondToUserMessageShouldReturnsOk()
        {
            var model = new RespondUserMessageModel()
            {
                Message = "Test Message Again",
                MessageId = Guid.Parse("0C09C0A3-DA6F-4DB7-82B9-F8BEE9159D47"),
                ResponseMessage = "My response message",
                UserId = Guid.Parse("585D7252-A95A-4493-8CE7-0246849050B7")
            };
            factory.UserMessageServiceMock.Setup(x => x.CheckIfMessageExistsByIdAsync(It.IsAny<Guid>())).ReturnsAsync(true);
            factory.UserMessageServiceMock.Setup(x => x.GetUserEmailByMessageIdAsync(It.IsAny<Guid>())).ReturnsAsync("test123@gmail.com");

            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            User user = new User()
            {
                Id = Guid.Parse("ED842FDC-C71B-4FBC-8DF5-6F97CB73D622"),
                UserName = "Pesho",
                NormalizedUserName = "PESHO",
                Email = "pesho123@gmail.com",
                NormalizedEmail = "PESHO123@GMAIL.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            user.PasswordHash = passwordHasher.HashPassword(user, "pesho12345");
            factory.UserManagerMock.Setup(x => x.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(user);

            var request = await client.PostAsync("api/userMessage/Respond", JsonContent.Create(model));

            Assert.That(request.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public async Task TestDeleteShouldReturnsBadRequest()
        {
            factory.UserMessageServiceMock.Setup(x => x.CheckIfMessageExistsByIdAsync(It.IsAny<Guid>())).ReturnsAsync(false);

            var json = JsonConvert.SerializeObject(Guid.Parse("BB84FB8E-8977-4CDE-8F8E-D76B07260BF0"));

            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json"),
                Method = HttpMethod.Delete,
                RequestUri = new Uri("http://localhost/api/userMessage/Delete")
            };
            var result = await client.SendAsync(request);


            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }
        [Test]
        public async Task TestDeleteShouldReturnsOk()
        {
            factory.UserMessageServiceMock.Setup(x => x.CheckIfMessageExistsByIdAsync(It.IsAny<Guid>())).ReturnsAsync(true);

            var json = JsonConvert.SerializeObject(Guid.Parse("BB84FB8E-8977-4CDE-8F8E-D76B07260BF0"));

            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json"),
                Method = HttpMethod.Delete,
                RequestUri = new Uri("http://localhost/api/userMessage/Delete")
            };
            var result = await client.SendAsync(request);


            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [TearDown]
        public void TearDown()
        {
            factory.Dispose();
            client.Dispose();
        }
    }
}
