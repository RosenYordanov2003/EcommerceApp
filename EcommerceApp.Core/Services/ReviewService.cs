namespace EcommerceApp.Core.Services
{
    using System.Net;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using Contracts;
    using Data;
    using Infrastructure.Data.Models;
    using Models.Review;
    using Models.Pager;

    public class ReviewService : IReviewService
    {
        private readonly ApplicationDbContext dbContext;

        public ReviewService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> CheckIfReviewByReviewIdAndUserIdExistsAsync(int reviewId, Guid userId)
        {
            return await dbContext.Reviews.AnyAsync(r => r.Id == reviewId && r.UserId == userId);
        }

        public Task<bool> CheckIfReviewExistsByIdAsync(int reviewId)
        {
            return dbContext.Reviews.AnyAsync(r => r.Id == reviewId);
        }

        public async Task DeleteReviewByIdAsync(int reviewId)
        {
            Review reviewToDelete = await dbContext.Reviews.FirstAsync(r => r.Id == reviewId);
            dbContext.Reviews.Remove(reviewToDelete);

            await dbContext.SaveChangesAsync();
        }

        public async Task EditReviewAsync(int reviewId, EditReviewModel editReviewModel)
        {
            Review reviewToEdit = await dbContext.Reviews.FirstAsync(r => r.Id == reviewId);
            reviewToEdit.Content = WebUtility.HtmlEncode(editReviewModel.Content);
            reviewToEdit.StarЕvaluation = editReviewModel.StarEvaluation;
            reviewToEdit.Subject = WebUtility.HtmlEncode(editReviewModel.Subject);

            await dbContext.SaveChangesAsync();
        }

        public async Task<EditReviewModel> GetReviewToEditAsync(int reviewId)
        {
            return await dbContext.Reviews.
                 Where(r => r.Id == reviewId)
                .Select(r => new EditReviewModel()
                {
                    Id = r.Id,
                    Content = r.Content,
                    StarEvaluation = r.StarЕvaluation,
                    Subject = r.Subject,
                })
                .FirstAsync();
        }

        public async Task<int> GetTotalReviewsCountByProductIdAndCategoryNameAsync(int productId, string categoryName)
        {
            if (categoryName.ToLower() == "shoes")
            {
                return await dbContext.Shoes.Where(sh => sh.Id == productId)
                    .Select(sh => sh.Reviews.Count)
                    .FirstAsync();
            }
            return await dbContext.Clothes.Where(cl => cl.Id == productId)
                  .Select(sh => sh.Reviews.Count)
                  .FirstAsync();
        }

        public async Task<IEnumerable<ReviewModel>> LoadReviewsForParticularProductAsync(int productId, string productCategory,
            Pager pager)
        {
            IQueryable<Review> reviews = dbContext.Reviews.AsQueryable();
            int recordsToSkip = (pager.CurrentPage - 1) * pager.PageSize;

            if (productCategory.ToLower() == "shoes")
            {

                return await reviews
                    .Where(r => r.ShoesId == productId)
                    .Select(r => new ReviewModel()
                    {
                        Id = r.Id,
                        UserId = r.UserId,
                        Content = r.Content,
                        CreatedOn = r.CreatedOn,
                        StarEvaluation = r.StarЕvaluation,
                        Username = r.User.UserName,
                        Subject = r.Subject,
                    })
                    .Skip(recordsToSkip)
                    .Take(pager.PageSize)
                    .ToArrayAsync();

            }
            return await reviews
                     .Where(r => r.ProductId == productId)
                     .Select(r => new ReviewModel()
                     {
                         Id = r.Id,
                         UserId = r.UserId,
                         Content = r.Content,
                         CreatedOn = r.CreatedOn,
                         StarEvaluation = r.StarЕvaluation,
                         Username = r.User.UserName
                     })
                     .Skip(recordsToSkip)
                     .Take(pager.PageSize)
                     .ToArrayAsync();
        }

        public async Task PostPoductReviewAsync(CreateReviewModel createReviewModel)
        {

            Review review = new Review()
            {
                Content = WebUtility.HtmlEncode(createReviewModel.Content),
                StarЕvaluation = createReviewModel.StarRating,
                UserId = createReviewModel.UserId,
                CreatedOn = DateTime.Now,
                Subject = WebUtility.HtmlEncode(createReviewModel.Subject)
            };
            review.ShoesId = createReviewModel.ProductCategory == "shoes" ? createReviewModel.ProductId : null;
            review.ProductId = createReviewModel.ProductCategory != "shoes" ? createReviewModel.ProductId : null;

            await dbContext.Reviews.AddAsync(review);
            await dbContext.SaveChangesAsync();
        }
    }
}
