namespace EcommerceApp.Core.Contracts
{
    using Models.AdminModels.UserMessages;
    using Models.UserMessage;
    public interface IUserMessageService
    {
        Task UploadUserMessageAsync(UploadUserMessageModel uploadUserMessageModel);
        Task<int> GetMessageCountAsync();
        Task<IEnumerable<UserMessageCardModel>> GetUserMessagesAsync();
        Task<string> GetUserEmailByMessageIdAsync(Guid id);
        Task <bool> CheckIfMessageExistsByIdAsync(Guid id);
        Task DeleteMessageAsync(Guid id);
    }
}
