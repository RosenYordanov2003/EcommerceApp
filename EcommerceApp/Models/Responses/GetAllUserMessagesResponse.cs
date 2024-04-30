namespace EcommerceApp.Models.Responses
{
    using Core.Models.Pager;
    using Core.Models.AdminModels.UserMessages;

    public class GetAllUserMessagesResponse
    {
        public Pager PagerObject { get; set; } = null!;
        public IEnumerable<UserMessageCardModel> Messages { get; set; } = null!;
    }
}
