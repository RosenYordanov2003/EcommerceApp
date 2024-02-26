namespace EcommerceApp.Controllers.Admin
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Core.Models.UserMessage;
    using Core.Contracts;
    using static Common.GeneralApplicationConstants;
    using Microsoft.AspNetCore.SignalR;
    using SignalR;

    [Route("api/userMessage")]
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    public class UserMessageController : ControllerBase
    {
        private readonly IUserMessageService userMessageService;
        private readonly IHubContext<NotificationsHub> hubContext;
        public UserMessageController(IUserMessageService userMessageService, IHubContext<NotificationsHub> hubContext)
        {
            this.userMessageService = userMessageService;
            this.hubContext = hubContext;
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

            await hubContext.Clients.All.SendAsync("UserMessageSent");

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
    }
}
