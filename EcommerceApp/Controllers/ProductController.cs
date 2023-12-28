namespace EcommerceApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using EcommerceApp.Core.Contracts;
    using EcommerceApp.Core.Models.Shoes;
    using EcommerceApp.Core.Models.Products;
    using Microsoft.AspNetCore.Authorization;

    [ApiController]
    [Produces("application/json")]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IShoesService shoesService;
        private readonly IProductSevice clothesService;
        public ProductController(IShoesService shoesService, IProductSevice clothesService)
        {
            this.shoesService = shoesService;
            this.clothesService = clothesService;
        }

        [HttpGet("GetFeaturedShoes")]
        public async Task<IActionResult> GetFeaturedShoes([FromQuery]string? userId)
        {
            userId = userId?.ToUpper();
            Guid? result =  string.IsNullOrWhiteSpace(userId) ? null : Guid.Parse(userId);
            
            IEnumerable<ShoesFeatureModel> featuredShoes = await shoesService.GetFeaturedShoesAsync(result);

            return Ok(featuredShoes);
        }
        [HttpGet("GetFeaturedClothes")]
        public async Task<IActionResult> GetFeaturedClothes([FromQuery]string? userId)
        {
            userId = userId?.ToUpper();
            Guid? result = string.IsNullOrWhiteSpace(userId) ? null : Guid.Parse(userId);

            IEnumerable<ProductModel> featuredProducts = await clothesService.GetFeaturedClothesAsync(result);

            return Ok(featuredProducts);
        }
        [HttpGet("GetProductsByGender")]
        public async Task<IActionResult> GetProductsByGender([FromQuery]string gender)
        {
            var result = await this.clothesService.GetProductByGender(gender);

            return Ok(result);
        }
        [HttpGet("AboutProduct")]
        public async Task<IActionResult>GetProductById([FromQuery]int productId, [FromQuery] string categoryName,[FromQuery] Guid userId)
        {
            if (!await clothesService.CheckIfProductExistsByIdAsync(productId))
            {
                return BadRequest(new {Error = "Product with such an id does not exist"});
            }
            if (categoryName.ToLower() == "shoes")
            {
                ProductInfo<double> shoesproductInfo = await clothesService.GetProductByIdAsync<double>(productId, categoryName, userId);

                return Ok(shoesproductInfo);
            }

            ProductInfo<string> productInfo = await clothesService.GetProductByIdAsync<string>(productId, categoryName, userId);

            return Ok(productInfo);
        }
        [HttpPost]
        [Authorize]
        [Route("AddToFavoriteProducts")]
        public async Task<IActionResult> AddToFavoriteProducts([FromBody]UserFavoriteProduct userFavoriteProductModel)
        {
            if (!await clothesService.CheckIfProductExistsByIdAsync(userFavoriteProductModel.ProductId))
            {
                return BadRequest(new { Error = "Product with such an id does not exist" });
            }
            await clothesService.AddProductToUserFavoritesListAsync(userFavoriteProductModel);

            return Ok();
        }
        [HttpPost]
        [Route("RemoveFromUserFavoriteLists")]
        public async Task<IActionResult> RemoveFromUserFavoriteLists([FromBody] UserFavoriteProduct userFavoriteProductModel)
        {
            if (!await clothesService.CheckIfProductExistsByIdAsync(userFavoriteProductModel.ProductId))
            {
                return BadRequest(new { Error = "Product with such an id does not exist" });
            }
            await clothesService.RemoveProductFromUserFavoriteListAsync(userFavoriteProductModel);

            return Ok();
        }
    }
}
