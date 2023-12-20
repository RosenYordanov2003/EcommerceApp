namespace EcommerceApp.Core.Services
{
    using Contracts;
    using EcommerceApp.Data;
    using Infrastructure.Data.Models;
    using Models.Review;

    public class ReviewService : IReviewService
    {
        private readonly ApplicationDbContext dbContext;

        public ReviewService(ApplicationDbContext dbContext)
        {
          this.dbContext = dbContext;
        }
        public async Task PostPoductReviewAsync(CreateReviewModel createReviewModel)
        {

            Review review = new Review()
            {
                Content = createReviewModel.Content,
                StarЕvaluation = createReviewModel.StarRating,
                UserId = createReviewModel.UserId,
                CreatedOn = DateTime.Now
            };

            if (createReviewModel.ProductCategory.ToLower() == "shoes")
            {
                review.ShoesId = createReviewModel.ProductId;
            }
            else
            {
                review.ProductId = createReviewModel.ProductId;
            }

            await dbContext.Reviews.AddAsync(review);
            await dbContext.SaveChangesAsync();
        }
    }
}
