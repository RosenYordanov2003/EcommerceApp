using EcommerceApp.Core.Models.Review;
using EcommerceApp.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Http;

namespace EcommerceApp.Controllers
{
    using Core.Contracts;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Produces("application/json")]
    [Route("api/reviews")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService reviewService;

        public ReviewController(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        [Route("PostReview")]
        public async Task<IActionResult> PostReview([FromBody] CreateReviewModel createReviewModel)
        {
            if (!ModelState.IsValid)
            {
                //return ModelState.AddModelError("");
                var errors = ModelState.Values.SelectMany(ms => ms.Errors);
                return BadRequest(errors);
            }
            await reviewService.PostPoductReviewAsync(createReviewModel);
            return Ok(new { Success = true });
        }
    }
}
