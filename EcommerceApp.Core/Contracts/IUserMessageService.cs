namespace EcommerceApp.Core.Contracts
{
    using Core.Models.UserMessage;
    public interface IUserMessageService
    {
        Task UploadUserMessageAsync(UploadUserMessageModel uploadUserMessageModel);
    }
}
