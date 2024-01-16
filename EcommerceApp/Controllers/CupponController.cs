namespace EcommerceApp.Controllers
{
    using EcommerceApp.Core.Contracts;
    using EcommerceApp.Core.Models.PromotionCodes;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("api/cuppons")]
    public class CupponController : ControllerBase
    {
        private readonly IPromotionCodeService promotionCodeService;
        public CupponController(IPromotionCodeService promotionCodeService)
        {
            this.promotionCodeService = promotionCodeService;
        }

        [HttpPost]
        [Route("Apply")]
        public async Task<IActionResult> ApplyCuppon([FromBody] PromotionCodeApplyModel promotionCodeApplyModel)
        {
            if (!await promotionCodeService.CheckIfPromotionCodeExistByIdAsync(promotionCodeApplyModel.CupponId))
            {
                return Ok(new { Error = "Invalid cuppon" });
            }
            if (!await promotionCodeService.CheckIfPromotionCodeIsRelatedWithParticularUserAsync(promotionCodeApplyModel.CupponId, promotionCodeApplyModel.UserId))
            {
                return Ok(new { Error = "Invalid cuppon" });
            }
            PromotionCodeModel cuppon = await promotionCodeService.GetPromotionCodeByIdAsync(promotionCodeApplyModel.CupponId);

            return Ok(new {Success = true, Cuppon = cuppon});
        }
    }
}
