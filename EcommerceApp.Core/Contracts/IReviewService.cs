namespace EcommerceApp.Core.Contracts
{
    using Models.Review;
    public interface IReviewService
    {
        Task PostPoductReviewAsync(CreateReviewModel createReviewModel);
        Task<IEnumerable<ReviewModel>> LoadAllReviewsForParticularProductAsync(int productId, string productCategory);
        Task<bool> CheckIfReviewByReviewIdAndUserIdExistsAsync(int reviewId, Guid userId);
        Task<EditReviewModel> GetReviewToEditAsync(int reviewId);
        Task EditReviewAsync(int reviewId, EditReviewModel editReviewModel);
        Task<bool> CheckIfReviewExistsByIdAsync(int reviewId);
    }
}
