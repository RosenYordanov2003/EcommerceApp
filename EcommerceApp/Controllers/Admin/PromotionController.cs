namespace EcommerceApp.Controllers.Admin
{
    using EcommerceApp.Core.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static Common.GeneralApplicationConstants;

    [Route("api/promotion")]
    [Authorize(Roles = AdminRoleName)]
    [Produces("application/json")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionService promotionService;

        public PromotionController(IPromotionService promotionService)
        {
            this.promotionService = promotionService;
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
            return Ok();
        }
    }
}
