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
        public async Task<IActionResult> PostReview([FromBody] CreateReviewModel createReviewModel)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(ms => ms.Errors);
                return BadRequest(errors);
            }
            await reviewService.PostPoductReviewAsync(createReviewModel);
            if (createReviewModel.ProductCategory.ToLower() == "shoes")
            {
                ProductInfo<double> shoesproductInfo = await shoesService.GetProductByIdAsync(createReviewModel.ProductId, createReviewModel.UserId);
                return Ok(new { Success = true, UpdatedProduct = shoesproductInfo });
            }

            ProductInfo<string> productInfo = await productSevice.GetProductByIdAsync(createReviewModel.ProductId, createReviewModel.UserId);
            return Ok(new { Success = true, UpdatedProduct = productInfo });
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("AllReviews")]
        public async Task<IActionResult> AllReviews([FromQuery] int productId, [FromQuery] string productCategory)
        {
            int totalReviewsCount = await reviewService.GetTotalReviewsCountByProductIdAndCategoryNameAsync(productId, productCategory);

            Pager pager = new Pager(totalReviewsCount, 1, 5);

            var reviews = await reviewService.LoadReviewsForParticularProductAsync(productId, productCategory, pager);

            return Ok(new {Reviews = reviews, StartPage = pager.StartPage, EndPage = pager.EndPage});
        }
        [HttpGet]
        [Route("GetReviewToEdit")]
        public async Task<IActionResult> GetReviewToEdit([FromQuery] int reviewId, [FromQuery] Guid userId)
        {
            if (!await reviewService.CheckIfReviewByReviewIdAndUserIdExistsAsync(reviewId, userId))
            {
                return Unauthorized();
            }
            var review = await reviewService.GetReviewToEditAsync(reviewId);
            return Ok(review);
        }
        [HttpPost]
        [Route("EditReview")]
        public async Task<IActionResult> EditReview([FromBody] EditReviewModel editReviewModel)
        {
            if (!await reviewService.CheckIfReviewExistsByIdAsync(editReviewModel.Id))
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await reviewService.EditReviewAsync(editReviewModel.Id, editReviewModel);

            return Ok();
        }
        [HttpPost]
        [Route("DeleteReview")]
        public async Task<IActionResult> DeleteReview([FromBody] int reviewId)
        {
            if (!await reviewService.CheckIfReviewExistsByIdAsync(reviewId))
            {
                return BadRequest();
            }
            await reviewService.DeleteReviewByIdAsync(reviewId);

            return Ok();
        }
        [HttpGet]
        [Route("GetReviewsPerPage")]
        public async Task<IActionResult> GetReviewsPerPage([FromQuery]int currentPage,[FromQuery] string categoryName, [FromQuery] int productId, [FromQuery] int pageSize)
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
    }
}
