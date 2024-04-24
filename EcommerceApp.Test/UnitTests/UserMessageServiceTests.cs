namespace EcommerceApp.Tests.UnitTests
{
    using Microsoft.EntityFrameworkCore;
    using Core.Contracts;
    using Core.Services;
    using Data;
    using static DatabaseSeeder;
    using Core.Models.UserMessage;
    using Core.Models.Pager;
    using static Common.GeneralApplicationConstants;

    public class UserMessageServiceTests
    {
        private IUserMessageService userMessageService;
        private ApplicationDbContext dbContext;
        private DbContextOptions<ApplicationDbContext> dbContextOptions;

        [SetUp]
        public void SetUp()
        {
            dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
              .UseInMemoryDatabase("EcommerceAppInMemoryDatabase" + Guid.NewGuid().ToString())
              .Options;
            dbContext = new ApplicationDbContext(dbContextOptions, false);
            dbContext.Database.EnsureCreated();
            SeedDatabase(dbContext);
            userMessageService = new UserMessageService(dbContext);
        }
        [Test]
        public async Task TestGetMessageCountAsync()
        {
            const int expectedCount = 2;

            int actualCount = await userMessageService.GetMessageCountAsync();

            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }
        [Test]
        [TestCase("6B3033A9-5840-4A58-898A-F75989EE43C5")]
        [TestCase("D15DE586-781C-45E0-85E1-D8634AAB7DA7")]
        public async Task TestCheckIfMessageExistsByIdAsyncShouldReturnsTrue(string id)
        {
            bool actualResult = await userMessageService.CheckIfMessageExistsByIdAsync(Guid.Parse(id));

            Assert.IsTrue(actualResult);
        }
        [Test]
        [TestCase("44122213-E394-4A49-9917-E94C7491789F")]
        [TestCase("41DA8808-D86B-4643-A094-2A5871624EC0")]
        public async Task TestCheckIfMessageExistsByIdAsyncShouldReturnsFalse(string id)
        {
            bool actualResult = await userMessageService.CheckIfMessageExistsByIdAsync(Guid.Parse(id));

            Assert.IsFalse(actualResult);
        }
        [Test]
        [TestCase("6B3033A9-5840-4A58-898A-F75989EE43C5")]
        [TestCase("D15DE586-781C-45E0-85E1-D8634AAB7DA7")]
        public async Task TestGetUserEmailByMessageIdAsync(string id)
        {
            const string expectedEmail = "test123@gmail.com";

            string actualEmail = await userMessageService.GetUserEmailByMessageIdAsync(Guid.Parse(id));

            Assert.That(actualEmail, Is.EqualTo(expectedEmail));
        }
        [Test]
        [TestCase("6B3033A9-5840-4A58-898A-F75989EE43C5")]
        [TestCase("D15DE586-781C-45E0-85E1-D8634AAB7DA7")]
        public async Task TestMarkMessageAsRespondedByIdAsync(string id)
        {
            await userMessageService.MarkMessageAsRespondedByIdAsync(Guid.Parse(id));

            var message = await dbContext.UserMessages.FirstAsync(x => x.Id == Guid.Parse(id));

            Assert.IsTrue(message.IsResponded);
        }
        [Test]
        public async Task TestUploadUserMessageAsync()
        {
            UploadUserMessageModel model = new UploadUserMessageModel()
            {
                Message = "Test Message 3",
                UserId = userId
            };
            const int expectedCount = 3;
            await userMessageService.UploadUserMessageAsync(model);

            int actualCount = await userMessageService.GetMessageCountAsync();

            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }
        [Test]
        [TestCase("6B3033A9-5840-4A58-898A-F75989EE43C5")]
        [TestCase("D15DE586-781C-45E0-85E1-D8634AAB7DA7")]
        public async Task TestDeleteMessageAsync(string id)
        {
            const int expectedCount = 1;

            await userMessageService.DeleteMessageAsync(Guid.Parse(id));

            int actualCount = await userMessageService.GetMessageCountAsync();

            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }
        [Test]
        public async Task TestGetUserMessagesAsync()
        {
            const int totalItems = 2;
            const int currentPage = 1;
            Pager pager = new Pager(totalItems, currentPage, DefaultPageSize);

            Guid[] expectedIds = new Guid[2] { Guid.Parse("6B3033A9-5840-4A58-898A-F75989EE43C5"), Guid.Parse("D15DE586-781C-45E0-85E1-D8634AAB7DA7") };

            var actualResult = await userMessageService.GetUserMessagesAsync(pager);

            CollectionAssert.AreEqual(expectedIds, actualResult.Select(x => x.Id));
        }
        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }
    }
}
