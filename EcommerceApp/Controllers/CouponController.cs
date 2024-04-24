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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("Apply")]
        public async Task<IActionResult> ApplyCuppon([FromBody] PromotionCodeApplyModel promotionCodeApplyModel)
        {
            if (!await promotionCodeService.CheckIfCouponExistByIdAsync(promotionCodeApplyModel.CouponId))
            {
                return NotFound(new { Error = "Invalid cuppon" });
            }
            if (!await promotionCodeService.CheckIfCouponIsRelatedWithParticularUserAsync(promotionCodeApplyModel.CouponId, promotionCodeApplyModel.UserId))
            {
                return BadRequest(new { Error = "Invalid cuppon" });
            }
            if (await promotionCodeService.CheckIfCouponHasExpiredByIdAsync(promotionCodeApplyModel.CouponId))
            {
                return Ok(new { Error = "Invalid cuppon" });
            }
            CouponModel coupon = await promotionCodeService.GetCouponByIdAsync(promotionCodeApplyModel.CouponId);

            return Ok(new { Success = true, Cuppon = coupon });
        }
    }
}
