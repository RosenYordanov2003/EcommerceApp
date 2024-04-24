namespace EcommerceApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using Core.Contracts;
    using Core.Models.Products;

    [Route("shoes")]
    [ApiController]
    public class ShoesController : ControllerBase
    {
        private readonly IShoesService shoesService;
        public ShoesController(IShoesService shoesService)
        {
            this.shoesService = shoesService;
        }

        [HttpGet]
        [Route("GetFeatured")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFeaturedShoes([FromQuery] string? userId)
        {
            Guid? userIdResult = ExtractUserId(userId);

            IEnumerable<ProductFeatureModel> featuredShoes = await shoesService.GetFeaturedShoesAsync(userIdResult);

            return Ok(featuredShoes);
        }
        [HttpPost]
        [Authorize]
        [Route("AddToFavorite")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddToFavoriteProducts([FromBody] UserFavoriteProductModel userFavoriteProductModel)
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RemoveFromUserFavorite([FromBody] UserFavoriteProductModel userFavoriteProductModel)
        {
            if (!await shoesService.CheckIfShoesExistsByIdAsync(userFavoriteProductModel.ProductId))
            {
                return BadRequest(new { Error = "Shoes with such an id does not exist" });
            }
            await shoesService.RemoveShoesFromUserFavoriteProductsAsync(userFavoriteProductModel);

            return Ok();
        }
        [HttpGet("About")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProductById([FromQuery] int productId,[FromQuery] string? userId)
        {
            Guid? userIdResult = ExtractUserId(userId);

            if (!await shoesService.CheckIfShoesExistsByIdAsync(productId))
            {
                return NotFound(new { Error = "Product with such an id does not exist" });
            }

            ProductInfoModel<double> productInfo = await shoesService.GetProductByIdAsync(productId, userIdResult);

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
