namespace EcommerceApp.Core.Services
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using Contracts;
    using Data;
    using Infrastructure.Data.Models;
    using Models.Review;

    public class ReviewService : IReviewService
    {
        private readonly ApplicationDbContext dbContext;

        public ReviewService(ApplicationDbContext dbContext)
        {
          this.dbContext = dbContext;
        }

        public async Task<IEnumerable<ReviewModel>> LoadAllReviewsForParticularProductAsync(int productId, string productCategory)
        {
            if (productCategory.ToLower() == "shoes")
            {
                return await dbContext.Reviews.Where(r => r.ShoesId == productId)
                    .Select(r => new ReviewModel()
                    {
                        UserId = r.UserId,
                        Content = r.Content,
                        CreatedOn = r.CreatedOn,
                        StarEvaluation = r.StarЕvaluation,
                        Username = r.User.UserName
                    })
                    .ToArrayAsync();
                    
            }
            return await dbContext.Reviews.Where(r => r.ProductId == productId)
                  .Select(r => new ReviewModel()
                  {
                      UserId = r.UserId,
                      Content = r.Content,
                      CreatedOn = r.CreatedOn,
                      StarEvaluation = r.StarЕvaluation,
                      Username = r.User.UserName
                  })
                  .ToArrayAsync();
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
