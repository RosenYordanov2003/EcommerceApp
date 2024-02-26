namespace EcommerceApp.Controllers.Admin
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Core.Models.UserMessage;
    using Core.Contracts;
    using static Common.GeneralApplicationConstants;

    [Route("api/userMessage")]
    [Authorize(Roles = AdminRoleName)]
    [ApiController]
    [Produces("application/json")]
    public class UserMessageController : ControllerBase
    {
        private readonly IUserMessageService userMessageService;
        public UserMessageController(IUserMessageService userMessageService)
        {
            this.userMessageService = userMessageService;
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

            return Ok(new {Success = true});
        }
    }
}
