namespace EcommerceApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using Core.Contracts;
    using Core.Models.Products;
    using Core.Models.Review;
    using Core.Models.Pager;

    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("api/reviews")]
    public class ReviewController : ControllerBase
    {
        private readonly IProductSevice productSevice;
        private readonly IReviewService reviewService;
        private readonly IShoesService shoesService;

        public ReviewController(IReviewService reviewService, IProductSevice productSevice, IShoesService shoesService)
        {
            this.reviewService = reviewService;
            this.productSevice = productSevice;
            this.shoesService = shoesService;
        }

        [HttpPost]
        [Route("PostReview")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostReview([FromBody] CreateReviewModel createReviewModel)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(ms => ms.Errors);
                return BadRequest(errors);
            }
            try
            {
                await reviewService.PostPoductReviewAsync(createReviewModel);
                if (createReviewModel.ProductCategory.ToLower() == "shoes")
                {
                    ProductInfoModel<double> shoesproductInfo = await shoesService.GetProductByIdAsync(createReviewModel.ProductId, createReviewModel.UserId);
                    return Ok(new { Success = true, UpdatedProduct = shoesproductInfo });
                }

                ProductInfoModel<string> productInfo = await productSevice.GetProductByIdAsync(createReviewModel.ProductId, createReviewModel.UserId);
                return Ok(new { Success = true, UpdatedProduct = productInfo });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("AllReviews")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AllReviews([FromQuery] int productId, [FromQuery] string productCategory)
        {
            try
            {
                int totalReviewsCount = await reviewService.GetTotalReviewsCountByProductIdAndCategoryNameAsync(productId, productCategory);

                Pager pager = new Pager(totalReviewsCount, 1, 5);

                var reviews = await reviewService.LoadReviewsForParticularProductAsync(productId, productCategory, pager);

                return Ok(new { Reviews = reviews, StartPage = pager.StartPage, EndPage = pager.EndPage });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet]
        [Route("GetReviewToEdit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetReviewToEdit([FromQuery] int reviewId, [FromQuery] Guid userId)
        {
            if (!await reviewService.CheckUserReviewExists(reviewId, userId))
            {
                return NotFound();
            }
            try
            {
                var review = await reviewService.GetReviewToEditAsync(reviewId);
                return Ok(review);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        [Route("EditReview")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EditReview([FromBody] EditReviewModel editReviewModel)
        {
            if (!await reviewService.CheckIfReviewExistsByIdAsync(editReviewModel.Id))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                await reviewService.EditReviewAsync(editReviewModel.Id, editReviewModel);

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        [Route("DeleteReview")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteReview([FromBody] int reviewId)
        {
            try
            {
                if (!await reviewService.CheckIfReviewExistsByIdAsync(reviewId))
                {
                    return NotFound();
                }
                await reviewService.DeleteReviewByIdAsync(reviewId);

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("GetReviewsPerPage")]
        public async Task<IActionResult> GetReviewsPerPage([FromQuery]int currentPage,[FromQuery] string categoryName, [FromQuery] int productId, [FromQuery] int pageSize)
        {
            try
            {
                int totalReviewsCount = await reviewService.GetTotalReviewsCountByProductIdAndCategoryNameAsync(productId, categoryName);

                if (currentPage < 1)
                {
                    currentPage = 1;
                }
                Pager pager = new Pager(totalReviewsCount, currentPage, pageSize);

                var reviews = await reviewService.LoadReviewsForParticularProductAsync(productId, categoryName, pager);

                return Ok(new { Reviews = reviews, StartPage = pager.StartPage, EndPage = pager.EndPage });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
