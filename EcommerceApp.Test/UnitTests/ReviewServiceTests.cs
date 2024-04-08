namespace EcommerceApp.Tests.UnitTests
{
    using Microsoft.EntityFrameworkCore;
    using Data;
    using Core.Contracts;
    using static Tests.DatabaseSeeder;
    using static Common.GeneralApplicationConstants;
    using Core.Services;
    using Core.Models.Review;
    using Core.Models.Pager;

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
        [Test]
        public async Task TestGetTotalReviewsCountByProductIdAndCategoryNameAsync()
        {
            int expectedCount = 1;
            int actualCount = await reviewService.GetTotalReviewsCountByProductIdAndCategoryNameAsync(1, "Shoes");

            Assert.That(actualCount, Is.EqualTo(expectedCount));

        }
        [Test]
        public async Task TestGetTotalReviewsCountByProductIdAndCategoryNameAsyncAfterPostAReview()
        {
            int expectedCount = 3;

            CreateReviewModel model = new CreateReviewModel()
            {
                ProductId = 1,
                Content = "Gosho",
                ProductCategory = "shoes",
                StarRating = 5,
                UserName = "Vesko",
                Subject = "About Product",
                UserId = userId
            };

            CreateReviewModel model2 = new CreateReviewModel()
            {
                ProductId = 1,
                Content = "Ceco",
                ProductCategory = "shoes",
                StarRating = 5,
                UserName = "Vesko",
                Subject = "About Product2",
                UserId = userId
            };

            await reviewService.PostPoductReviewAsync(model);
            await reviewService.PostPoductReviewAsync(model2);
            int actualCount = await reviewService.GetTotalReviewsCountByProductIdAndCategoryNameAsync(1, "Shoes");

            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }
        [Test]
        public async Task TestPostReviewsMethodShouldAddReviewsCorrectly()
        {
            CreateReviewModel model = new CreateReviewModel()
            {
                ProductId = 1,
                Content = "Gosho",
                ProductCategory = "shoes",
                StarRating = 5,
                UserName = "Vesko",
                Subject = "About Product",
                UserId = userId
            };

            CreateReviewModel model2 = new CreateReviewModel()
            {
                ProductId = 1,
                Content = "Ceco",
                ProductCategory = "shoes",
                StarRating = 5,
                UserName = "Vesko",
                Subject = "About Product2",
                UserId = userId
            };

            await reviewService.PostPoductReviewAsync(model);
            await reviewService.PostPoductReviewAsync(model2);

            bool reviewOne = await reviewService.CheckIfReviewExistsByIdAsync(2);
            bool reviewTwo = await reviewService.CheckIfReviewExistsByIdAsync(3);

            Assert.IsTrue(reviewOne);
            Assert.IsTrue(reviewTwo);
        }
        [Test]
        public async Task TestLoadReviewsForParticularProductAsync()
        {
            CreateReviewModel model = new CreateReviewModel()
            {
                ProductId = 1,
                Content = "Gosho",
                ProductCategory = "shoes",
                StarRating = 5,
                UserName = "Vesko",
                Subject = "About Product",
                UserId = userId
            };

            CreateReviewModel model2 = new CreateReviewModel()
            {
                ProductId = 1,
                Content = "Ceco",
                ProductCategory = "shoes",
                StarRating = 5,
                UserName = "Vesko",
                Subject = "About Product2",
                UserId = userId
            };

            await reviewService.PostPoductReviewAsync(model);
            await reviewService.PostPoductReviewAsync(model2);

            Pager pager = new Pager(3, 1, DefaultPageSize);

            var result = await reviewService.LoadReviewsForParticularProductAsync(1, "shoes", pager);

            string[] expectedContentsCollection = new string[3] { "Test Review", "Gosho", "Ceco" };

            CollectionAssert.AreEqual(expectedContentsCollection, result.Select(x => x.Content));
        }
        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Database.EnsureDeleted();
        }
    }
}
