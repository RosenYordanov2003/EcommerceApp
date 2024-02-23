namespace EcommerceApp.Core.Models.Review
{
    using System.ComponentModel.DataAnnotations;
    using static GlobalConstants.EntityValidation.ReviewEntity;
    public class EditReviewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(ContentMaxValue,MinimumLength = ContentMinValue)]
        public string Content { get; set; } = null!;

        [Range(StarEvaluationMinValue,StarEvaluationMaxValue)]
        public int StarEvaluation { get; set; }

        [Required]
        [MaxLength(SubjectMaxValue)]
        public string Subject { get; set; } = null!;
    }
}
