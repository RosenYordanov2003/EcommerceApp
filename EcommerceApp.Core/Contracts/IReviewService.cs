namespace EcommerceApp.Core.Contracts
{
    using Models.Pager;
    using Models.Review;
    public interface IReviewService
    {
        Task PostPoductReviewAsync(CreateReviewModel createReviewModel);
        Task<IEnumerable<ReviewModel>> LoadReviewsForParticularProductAsync(int productId, string productCategory, Pager pager);
        Task<bool> CheckIfReviewByReviewIdAndUserIdExistsAsync(int reviewId, Guid userId);
        Task<EditReviewModel> GetReviewToEditAsync(int reviewId);
        Task EditReviewAsync(int reviewId, EditReviewModel editReviewModel);
        Task<bool> CheckIfReviewExistsByIdAsync(int reviewId);
        Task DeleteReviewByIdAsync(int reviewId);
        Task<int> GetTotalReviewsCountByProductIdAndCategoryNameAsync(int productId, string categoryName);
    }
}
