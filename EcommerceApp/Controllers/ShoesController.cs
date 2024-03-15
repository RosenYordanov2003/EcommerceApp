namespace EcommerceApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using Core.Contracts;
    using Core.Models.Products;
    using EcommerceApp.Core.Services;

    [Route("shoes")]
    [ApiController]
    public class ShoesController : ControllerBase
    {
        private readonly IShoesService shoesService;
        public ShoesController(IShoesService shoesService)
        {
            this.shoesService = shoesService;
        }

        [HttpGet("GetFeatured")]
        public async Task<IActionResult> GetFeaturedShoes([FromQuery] string? userId)
        {
            Guid? userIdResult = ExtractUserId(userId);

            IEnumerable<ProductFeatureModel> featuredShoes = await shoesService.GetFeaturedShoesAsync(userIdResult);

            return Ok(featuredShoes);
        }
        [HttpPost]
        [Authorize]
        [Route("AddToFavorite")]
        public async Task<IActionResult> AddToFavoriteProducts([FromBody] UserFavoriteProduct userFavoriteProductModel)
        {
            if (!await shoesService.CheckIfShoesExistsByIdAsync(userFavoriteProductModel.ProductId))
            {
                return BadRequest(new { Error = "Shoes with such an id does not exist" });
            }
            await shoesService.AddShoesToUserFavoriteProductsAsync(userFavoriteProductModel);

            return Ok();
        }
        [HttpPost]
        [Route("RemoveFromFavorite")]
        public async Task<IActionResult> RemoveFromUserFavorite([FromBody] UserFavoriteProduct userFavoriteProductModel)
        {
            if (!await shoesService.CheckIfShoesExistsByIdAsync(userFavoriteProductModel.ProductId))
            {
                return BadRequest(new { Error = "Shoes with such an id does not exist" });
            }
            await shoesService.RemoveShoesToUserFavoriteProductsAsync(userFavoriteProductModel);

            return Ok();
        }
        [HttpGet("About")]
        public async Task<IActionResult> GetProductById([FromQuery] int productId,[FromQuery] string? userId)
        {
            Guid? userIdResult = ExtractUserId(userId);

            if (!await shoesService.CheckIfShoesExistsByIdAsync(productId))
            {
                return BadRequest(new { Error = "Product with such an id does not exist" });
            }

            ProductInfo<double> productInfo = await shoesService.GetProductByIdAsync(productId, userIdResult);

            return Ok(productInfo);
        }

        private static Guid? ExtractUserId(string? userId)
        {
            userId = userId?.ToUpper();
            Guid? userIdResult = string.IsNullOrWhiteSpace(userId) ? null : Guid.Parse(userId);
            return userIdResult;
        }
    }
}
