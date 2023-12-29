namespace EcommerceApp.Core.Models.Review
{
    public class ReviewModel
    {
        public string Content { get; set; } = null!;
        public int StarEvaluation { get; set; }
        public string Username { get; set; } = null!;
        public Guid UserId { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
