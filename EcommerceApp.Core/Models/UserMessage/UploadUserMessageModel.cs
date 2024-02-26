namespace EcommerceApp.Core.Models.UserMessage
{
    using System.ComponentModel.DataAnnotations;
    using static GlobalConstants.EntityValidation.UserMessage;
    public class UploadUserMessageModel
    {
        public Guid UserId { get; set; }

        [Required]
        [MinLength(MinLength)]
        [MaxLength(MaxLength)]
        public string Message { get; set; } = null!;
    }
}
