namespace EcommerceApp.Tests.UnitTests
{
    using Microsoft.EntityFrameworkCore;
    using Data;
    using Core.Contracts;
    using static Tests.DatabaseSeeder;
    using Core.Services;
    using EcommerceApp.Core.Models.Review;

    internal class ReviewServiceTests
    {
        private ApplicationDbContext applicationDbContext;
        private DbContextOptions<ApplicationDbContext> dbContextOptions;
        private IReviewService reviewService;

        [SetUp]
        public void SetUp()
        {
            dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
              .UseInMemoryDatabase("EcommerceAppInMemoryDatabase" + Guid.NewGuid().ToString())
              .Options;

            applicationDbContext = new ApplicationDbContext(dbContextOptions, false);
            SeedDatabase(applicationDbContext);
            reviewService = new ReviewService(applicationDbContext);
        }
        [Test]
        public async Task TestCheckWheterReviewByUserExistsAsyncShouldReturnTrue()
        {
            bool result = await reviewService.CheckUserReviewExists(1, userId);

            Assert.IsTrue(result);
        }
        [Test]
        public async Task TestCheckWheterReviewByUserExistsAsyncShouldReturnFalse()
        {
            bool result = await reviewService.CheckUserReviewExists(99, userId);

            Assert.IsFalse(result);
        }
        [Test]
        public async Task TestCheckIfReviewExistsByIdAsyncShouldReturnTrue()
        {
            bool result = await reviewService.CheckIfReviewExistsByIdAsync(1);

            Assert.IsTrue(result);
        }
        [Test]
        public async Task TestCheckIfReviewExistsByIdAsyncShouldReturnFalse()
        {
            bool result = await reviewService.CheckIfReviewExistsByIdAsync(99);

            Assert.IsFalse(result);
        }
        [Test]
        public async Task TestDeleteReviewByIdAsync()
        {
            await reviewService.DeleteReviewByIdAsync(1);
            bool result = await reviewService.CheckIfReviewExistsByIdAsync(99);

            Assert.IsFalse(result);
        }
        [Test]
        public async Task TestDeleteReviewByIdAsyncShouldReturnTheCorrectCount()
        {
            int initialCount = await applicationDbContext.Reviews.CountAsync();
            int expectedCount = initialCount - 1;

            await reviewService.DeleteReviewByIdAsync(1);
            int actualCount = await applicationDbContext.Reviews.CountAsync();

            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }
        [Test]
        public async Task TestEditReviewAsync()
        {
            EditReviewModel model = new EditReviewModel()
            {
                Content = "Test123",
                Id = 1,
                StarEvaluation = 5,
                Subject = "About Prodouct edited"
            };
            await reviewService.EditReviewAsync(1, model);

            Assert.That(review1.Subject, Is.EqualTo(model.Subject));
            Assert.That(review1.Content, Is.EqualTo(model.Content));
            Assert.That(review1.StarЕvaluation, Is.EqualTo(model.StarEvaluation));

        }
        [Test]
        public async Task TestGetReviewToEditAsync()
        {
            EditReviewModel expectedModel = new EditReviewModel()
            {
                Content = "Test Review",
                StarEvaluation = 5,
                Subject = "About Product",
                Id = 1,
            };

            var actualModel = await reviewService.GetReviewToEditAsync(1);

            Assert.That(expectedModel.Id, Is.EqualTo(actualModel.Id));
            Assert.That(expectedModel.Content, Is.EqualTo(actualModel.Content));
            Assert.That(expectedModel.StarEvaluation, Is.EqualTo(actualModel.StarEvaluation));
            Assert.That(expectedModel.Subject, Is.EqualTo(actualModel.Subject));
        }
        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Database.EnsureDeleted();
        }
    }
}
