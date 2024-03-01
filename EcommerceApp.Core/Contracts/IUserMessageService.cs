namespace EcommerceApp.Core.Contracts
{
    using Models.Pager;
    using Models.AdminModels.UserMessages;
    using Models.UserMessage;
    public interface IUserMessageService
    {
        Task UploadUserMessageAsync(UploadUserMessageModel uploadUserMessageModel);
        Task<int> GetMessageCountAsync();
        Task<IEnumerable<UserMessageCardModel>> GetUserMessagesAsync(Pager pager);
        Task<string> GetUserEmailByMessageIdAsync(Guid id);
        Task <bool> CheckIfMessageExistsByIdAsync(Guid id);
        Task DeleteMessageAsync(Guid id);
        Task MarkMessageAsRespondedByIdAsync(Guid id);
    }
}
