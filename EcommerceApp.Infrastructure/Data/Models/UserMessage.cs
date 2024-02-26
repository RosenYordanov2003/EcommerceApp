namespace EcommerceApp.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static GlobalConstants.EntityValidation.UserMessage;
    public class UserMessage
    {
        public Guid Id { get; set; }
        [MaxLength(MaxLength)]
        public string Message { get; set; } = null!;
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
