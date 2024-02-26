namespace EcommerceApp.Core.Contracts
{
    using Models.UserMessage;
    public interface IUserMessageService
    {
        Task UploadUserMessageAsync(UploadUserMessageModel uploadUserMessageModel);
        Task<int> GetMessageCountAsync();
    }
}
