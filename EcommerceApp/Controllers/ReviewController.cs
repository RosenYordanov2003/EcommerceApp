namespace EcommerceApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Core.Contracts;
    using Core.Models.Products;
    using Core.Models.Review;

    [ApiController]
    [Produces("application/json")]
    [Route("api/reviews")]
    public class ReviewController : ControllerBase
    {
        private readonly IProductSevice productSevice;
        private readonly IReviewService reviewService;

        public ReviewController(IReviewService reviewService, IProductSevice productSevice)
        {
            this.reviewService = reviewService;
            this.productSevice = productSevice;
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
                ProductInfo<double> shoesproductInfo = await productSevice.GetProductByIdAsync<double>(createReviewModel.ProductId, createReviewModel.ProductCategory, createReviewModel.UserId);
                return Ok(new { Success = true, UpdatedProduct = shoesproductInfo });
            }

            ProductInfo<string> productInfo = await productSevice.GetProductByIdAsync<string>(createReviewModel.ProductId, createReviewModel.ProductCategory, createReviewModel.UserId);
            return Ok(new { Success = true, UpdatedProduct = productInfo });
        }
        [HttpGet]
        [Route("AllReviews")]
        public async Task<IActionResult> AllReviews([FromQuery] int productId, [FromQuery] string productCategory)
        {
            var reviews = await reviewService.LoadAllReviewsForParticularProductAsync(productId, productCategory);

            return Ok(reviews);
        }
    }
}
