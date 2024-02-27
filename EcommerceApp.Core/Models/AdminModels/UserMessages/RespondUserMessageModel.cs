namespace EcommerceApp.Core.Models.AdminModels.UserMessages
{
    using UserMessage;
    public class RespondUserMessageModel : UploadUserMessageModel
    {
        public string ResponseMessage { get; set; } = null!;
        public Guid MessageId { get; set; }
    }
}
