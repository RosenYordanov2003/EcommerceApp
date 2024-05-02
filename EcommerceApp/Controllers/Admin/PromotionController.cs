namespace EcommerceApp.Controllers.Admin
{
    using Core.Contracts;
    using Core.Models.AdminModels.Promotion;
    using SignalR;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddPromotion([FromBody] AddPromotionModel addPromotionModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                await promotionService.ApplyPromotionAsync(addPromotionModel);
                await hubContext.Clients.All.SendAsync("ProductUpdated");

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("RemovePromotion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RemovePromotion([FromBody] Guid promotionId)
        {
            if (!await promotionService.CheckIfPromotionExistsByIdAsync(promotionId))
            {
                return NotFound();
            }
            try
            {
                await promotionService.RemovePromotionAsync(promotionId);
                await hubContext.Clients.All.SendAsync("ProductUpdated");
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("Clear")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ClearExpiredPromotionsc()
        {
            try
            {
                await promotionService.ClearExpiredPrmotionsAsync();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
