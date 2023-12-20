namespace EcommerceApp.Core.Contracts
{
    using Models.Review;
    public interface IReviewService
    {
        Task PostPoductReviewAsync(CreateReviewModel createReviewModel);
    }
}
