namespace EcommerceApp.Tests.UnitTests
{
    using Microsoft.EntityFrameworkCore;
    using Core.Contracts;
    using Data;
    using static DatabaseSeeder;
    using Core.Services;
    using Infrastructure.Data.Models;
    using Core.Models.PromotionCodes;

    [TestFixture]
    public class CouponServiceTests
    {
        private ApplicationDbContext dbContext;
        private DbContextOptions<ApplicationDbContext> dbContextOptions;
        private ICouponService couponService;

        [SetUp]
        public void SetUp()
        {
            dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
              .UseInMemoryDatabase("EcommerceAppInMemoryDatabase" + Guid.NewGuid().ToString())
              .Options;
            dbContext = new ApplicationDbContext(dbContextOptions, false);
            SeedDatabase(dbContext);
            couponService = new CouponService(dbContext);
        }
        [Test]
        public async Task TestCheckIfCoupponHasExpiredByIdAsyncShouldReturnFalse()
        {
            bool result = await couponService.CheckIfCouponHasExpiredByIdAsync(coupon.Id);

            Assert.IsFalse(result);
        }
        [Test]
        public async Task TestCheckIfCoupponHasExpiredByIdAsyncShouldReturnTrue()
        {
            bool result = await couponService.CheckIfCouponExistByIdAsync(expiredCoupon.Id);

            Assert.IsTrue(result);
        }
        [Test]
        public async Task TestCheckIfCouponExistByIdAsyncShouldReturnTrue()
        {
            bool resultOne = await couponService.CheckIfCouponExistByIdAsync(coupon.Id);
            bool resultTwo = await couponService.CheckIfCouponExistByIdAsync(expiredCoupon.Id);

            Assert.IsTrue(resultOne);
            Assert.IsTrue(resultTwo);
        }
        [Test]
        public async Task TestIfCouponIsRelatedWithParticularUserAsyncShouldReturnTrue()
        {
            bool resultOne = await couponService.CheckIfCouponIsRelatedWithParticularUserAsync(coupon.Id, userId);
            bool resultTwo = await couponService.CheckIfCouponIsRelatedWithParticularUserAsync(expiredCoupon.Id, userId);

            Assert.IsTrue(resultOne);
            Assert.IsTrue(resultTwo);
        }
        [Test]
        public async Task TestIfCouponIsRelatedWithParticularUserAsyncShouldReturnFalse()
        {
            bool result = await couponService.CheckIfCouponIsRelatedWithParticularUserAsync(userId, Guid.NewGuid());

            Assert.IsFalse(result);
        }
        [Test]
        public async Task TestGenerateCouponForUserAsync()
        {
            Coupon expectedCoupon = new Coupon()
            {
                Id = Guid.NewGuid(),
                ExpirationTime = DateTime.UtcNow.AddMonths(1),
                PromotionPercentages = 10,
                UserId = userId
            };
            CouponModel model = await couponService.GenerateCouponForUserAsync(userId, 10);

            Assert.IsNotNull(model);
            Assert.That(model.DiscountPercantages, Is.EqualTo(expectedCoupon.PromotionPercentages));
            Assert.That(model.ExpirationTime.Month, Is.EqualTo(expectedCoupon.ExpirationTime.Month));
            Assert.That(model.ExpirationTime.Day, Is.EqualTo(expectedCoupon.ExpirationTime.Day));
            Assert.That(model.ExpirationTime.Year, Is.EqualTo(expectedCoupon.ExpirationTime.Year));
        }
        [Test]
        public async Task TestGetCouponById()
        {
            CouponModel expectedCouponModel = new CouponModel()
            {
                Id = coupon.Id,
                DiscountPercantages = coupon.PromotionPercentages,
                ExpirationTime = coupon.ExpirationTime
            };

            CouponModel actualCouponModel = await couponService.GetCouponByIdAsync(coupon.Id);

            Assert.That(actualCouponModel.Id, Is.EqualTo(expectedCouponModel.Id));
            Assert.That(actualCouponModel.DiscountPercantages, Is.EqualTo(expectedCouponModel.DiscountPercantages));
            Assert.That(actualCouponModel.ExpirationTime, Is.EqualTo(expectedCouponModel.ExpirationTime));
        }
        [Test]
        public async Task TestRemoveCouponByIdAsync()
        {
            const int expectedCouponsCount = 1;
            await couponService.RemoveCouponByIdAsync(coupon.Id);

            User user = await dbContext.Users.Include(u => u.PromotionCodes).FirstAsync(u => u.Id == userId);

            Assert.That(user.PromotionCodes.Count, Is.EqualTo(expectedCouponsCount));
        }
        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
        }
    }
}
