namespace EcommerceApp.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Core.Contracts;
    using Core.Models.PromotionCodes;

    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("api/coupon")]
    public class CouponController : ControllerBase
    {
        private readonly ICouponService promotionCodeService;
        public CouponController(ICouponService promotionCodeService)
        {
            this.promotionCodeService = promotionCodeService;
        }

        [HttpPost]
        [Route("Apply")]
        public async Task<IActionResult> ApplyCuppon([FromBody] PromotionCodeApplyModel promotionCodeApplyModel)
        {
            if (!await promotionCodeService.CheckIfPromotionCodeExistByIdAsync(promotionCodeApplyModel.CouponId))
            {
                return NotFound(new { Error = "Invalid cuppon" });
            }
            if (!await promotionCodeService.CheckIfPromotionCodeIsRelatedWithParticularUserAsync(promotionCodeApplyModel.CouponId, promotionCodeApplyModel.UserId))
            {
                return BadRequest(new { Error = "Invalid cuppon" });
            }
            if (!await promotionCodeService.CheckIfCupponHasExpiredByIdAsync(promotionCodeApplyModel.CouponId))
            {
                return Ok(new { Error = "Invalid cuppon" });
            }
            PromotionCodeModel coupon = await promotionCodeService.GetPromotionCodeByIdAsync(promotionCodeApplyModel.CouponId);

            return Ok(new { Success = true, Cuppon = coupon });
        }
    }
}
