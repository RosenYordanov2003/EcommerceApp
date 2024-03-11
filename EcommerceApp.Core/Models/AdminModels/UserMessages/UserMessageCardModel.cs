namespace EcommerceApp.Core.Models.AdminModels.UserMessages
{
    public class UserMessageCardModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public string Message { get; set; } = null!;
        public bool IsResponded { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? ElapsedTime { get; set; }
    }
}
