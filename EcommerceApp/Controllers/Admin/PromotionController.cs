namespace EcommerceApp.Controllers.Admin
{
    using EcommerceApp.Core.Contracts;
    using EcommerceApp.Core.Models.AdminModels.Promotion;
    using EcommerceApp.Core.Services;
    using EcommerceApp.SignalR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;
    using static Common.GeneralApplicationConstants;

    [Route("api/promotion")]
    [Authorize(Roles = AdminRoleName)]
    [Produces("application/json")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionService promotionService;
        private readonly IHubContext<NotificationsHub> hubContext;

        public PromotionController(IPromotionService promotionService, IHubContext<NotificationsHub> hubContext)
        {
            this.promotionService = promotionService;
            this.hubContext = hubContext;
        }

        [HttpPost]
        [Route("AddPromotion")]
        public async Task<IActionResult> AddPromotion([FromBody] AddPromotionModel addPromotionModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await promotionService.ApplyPromotionAsync(addPromotionModel);
            await hubContext.Clients.All.SendAsync("ProductUpdated");

            return Ok();
        }

        [HttpDelete]
        [Route("RemovePromotion")]
        public async Task<IActionResult> RemovePromotion([FromBody] Guid promotionId)
        {
            if (!await promotionService.CheckIfPromotionExistsByIdAsync(promotionId))
            {
                return NotFound();
            }
            await promotionService.RemovePromotionAsync(promotionId);
            await hubContext.Clients.All.SendAsync("ProductUpdated");
            return Ok();
        }
        [HttpPost]
        [Route("Clear")]
        [AllowAnonymous]
        public async Task<IActionResult> ClearExpiredPromotionsc()
        {
            await promotionService.ClearExpiredPrmotionsAsync();
            return Ok();
        }
    }
}
