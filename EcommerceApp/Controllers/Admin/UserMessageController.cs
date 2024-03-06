namespace EcommerceApp.Controllers.Admin
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using SignalR;
    using Core.Models.UserMessage;
    using Core.Contracts;
    using Microsoft.AspNetCore.SignalR;
    using Core.Models.AdminModels.UserMessages;
    using Infrastructure.Data.Models;
    using static Common.GeneralApplicationConstants;
    using EcommerceApp.Core.Models.Pager;

    [Route("api/userMessage")]
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    public class UserMessageController : ControllerBase
    {
        private readonly IUserMessageService userMessageService;
        private readonly IHubContext<NotificationsHub> hubContext;
        private readonly UserManager<User> userManager;
        private readonly IEmailSender emailSender;
        public UserMessageController(IUserMessageService userMessageService, IHubContext<NotificationsHub> hubContext
            ,UserManager<User> userManager, IEmailSender emailSender)
        {
            this.userMessageService = userMessageService;
            this.hubContext = hubContext;
            this.userManager = userManager;
            this.emailSender = emailSender;
        }

        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> UploadMessage([FromBody] UploadUserMessageModel model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new { Success = false });
            }
            await userMessageService.UploadUserMessageAsync(model);

            await hubContext.Clients.All.SendAsync("UserMessagesModification");


            return Ok(new {Success = true});
        }
        [HttpGet]
        [Route("GetCount")]
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> GetMessageCount()
        {
            int messageCount = await userMessageService.GetMessageCountAsync();

            return Ok(messageCount);
        }
        [HttpGet]
        [Route("GetAll")]
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> GetAllMessages([FromQuery] int currentPage)
        {
            if (currentPage < 0) 
            {
                currentPage = 1;
            }
            int totalUserMessages = await userMessageService.GetMessageCountAsync();
            Pager pager = new Pager(totalUserMessages, currentPage, DefaultUserMessagesPageSize);

            IEnumerable<UserMessageCardModel> messages = await userMessageService.GetUserMessagesAsync(pager);

            return Ok(new {Messages = messages, PagerObject = pager});
        }
        [HttpPost]
        [Route("Respond")]
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> RespondToUserMessage([FromBody] RespondUserMessageModel model)
        {
            if (!await userMessageService.CheckIfMessageExistsByIdAsync(model.MessageId))
            {
                return BadRequest();
            }

            User user = await userManager.FindByIdAsync(model.UserId.ToString());

            string messageRespond = $"<main style=\"font-family: Arial, Helvetica, sans-serif; display: flex; flex-direction: column; align-items: center; justify-content: center;\">\r\n        <h1>Hello I'm {user.UserName} and I will respond to your question</h1>\r\n        <section style=\"display: flex; align-items: center; gap: 20px; flex-wrap: wrap;\">\r\n            <p style=\"font-size: 26px; margin-right: 10px;\">Your question was: <b>\"{model.Message}\"</b></p>\r\n            <p style=\"font-size: 26px\">{model.ResponseMessage}</p>\r\n        </section>\r\n        \r\n    </main>";
            await userMessageService.MarkMessageAsRespondedByIdAsync(model.MessageId);
            string email = await userMessageService.GetUserEmailByMessageIdAsync(model.MessageId);
            await emailSender.SendEmailAsync(email, "Response to your question" , messageRespond);

            return Ok();
        }
        [HttpDelete]
        [Route("Delete")]
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> DeleteUserMessage([FromBody] Guid id)
        {
            if(!await userMessageService.CheckIfMessageExistsByIdAsync(id))
            {
                return BadRequest();
            }
            await userMessageService.DeleteMessageAsync(id);

            return Ok();
        }
    }
}
