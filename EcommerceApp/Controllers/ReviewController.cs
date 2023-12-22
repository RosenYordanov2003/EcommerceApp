using EcommerceApp.Core.Models.Review;

namespace EcommerceApp.Controllers
{
    using Core.Contracts;
    using EcommerceApp.Core.Models.Products;
    using EcommerceApp.Infrastructure.Data.Models;
    using Microsoft.AspNetCore.Mvc;

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
                ProductInfo<double> shoesproductInfo = await productSevice.GetProductByIdAsync<double>(createReviewModel.ProductId, createReviewModel.ProductCategory, Guid.NewGuid());
                return Ok(new { Success = true, UpdatedProduct = shoesproductInfo });
            }

            ProductInfo<string> productInfo = await productSevice.GetProductByIdAsync<string>(createReviewModel.ProductId, createReviewModel.ProductCategory, Guid.NewGuid());
            return Ok(new { Success = true, UpdatedProduct = productInfo });
        }
    }
}
