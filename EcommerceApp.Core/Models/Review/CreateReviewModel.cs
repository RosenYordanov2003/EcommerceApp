﻿namespace EcommerceApp.Core.Models.Review
{
    using System.ComponentModel.DataAnnotations;
    using static GlobalConstants.EntityValidation.ReviewEntity;
    public class CreateReviewModel
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; } = null!;
        [MaxLength(SubjectMaxValue)]
        public string Subject { get; set; } = null!;

        [Required]
        [StringLength(ContentMaxValue, MinimumLength = ContentMinValue)]
        public string Content { get; set; } = null!;
        public int ProductId { get; set; }
        public string ProductCategory { get; set; } = null!;

        [Range(StarEvaluationMinValue, StarEvaluationMaxValue)]
        public int StarRating { get; set; }
    }
}
