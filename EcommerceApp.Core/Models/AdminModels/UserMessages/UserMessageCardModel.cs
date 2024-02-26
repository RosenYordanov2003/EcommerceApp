namespace EcommerceApp.Core.Models.AdminModels.UserMessages
{
    public class UserMessageCardModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public string Message { get; set; } = null!;
    }
}
