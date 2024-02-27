﻿namespace EcommerceApp.Controllers.Admin
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
        [HttpGet]
        [Route("GetAll")]
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> GetAllMessages()
        {
            IEnumerable<UserMessageCardModel> messages = await userMessageService.GetUserMessagesAsync();

            return Ok(messages);
        }
        [HttpPost]
        [Route("Respond")]
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> RespondToUserMessage([FromBody] RespondUserMessageModel model)
        {
            User user = await userManager.FindByIdAsync(model.UserId.ToString());

            string messageRespond = $"<main style=\"font-family: Arial, Helvetica, sans-serif; display: flex; flex-direction: column; align-items: center; justify-content: center;\">\r\n        <h1>Hello I'm {user.UserName} and I will respond to your question</h1>\r\n        <section style=\"display: flex; align-items: center; gap: 20px; flex-wrap: wrap;\">\r\n            <p style=\"font-size: 26px; margin-right: 10px;\">Your question was: <b>\"{model.Message}\"</b></p>\r\n            <p style=\"font-size: 26px\">{model.ResponseMessage}</p>\r\n        </section>\r\n        \r\n    </main>";

            string email = await userMessageService.GetUserEmailByMessageIdAsync(model.MessageId);
            await emailSender.SendEmailAsync(email, "Response to your question" , messageRespond);

            return Ok();
        }
    }
}
