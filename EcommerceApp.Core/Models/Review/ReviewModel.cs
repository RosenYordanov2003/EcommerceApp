namespace EcommerceApp.Core.Models.Review
{
    public class ReviewModel
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public int StarEvaluation { get; set; }
        public string Username { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public Guid UserId { get; set; }
        public string TimeDifferenceFormat { get; set; } = null!;
    }
}
