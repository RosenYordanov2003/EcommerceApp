namespace EcommerceApp.Core.Models.Review
{
    public class CreateReviewModel
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Summary { get; set; } = null!;
        public string Content { get; set; } = null!;
    }
}
