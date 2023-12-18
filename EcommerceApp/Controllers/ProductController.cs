namespace EcommerceApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using EcommerceApp.Core.Contracts;
    using EcommerceApp.Core.Models.Shoes;
    using EcommerceApp.Core.Models.Products;

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
        public async Task<IActionResult> GetFeaturedShoes()
        {
            IEnumerable<ShoesFeatureModel> featuredShoes = await shoesService.GetFeaturedShoesAsync();

            return Ok(featuredShoes);
        }
        [HttpGet("GetFeaturedClothes")]
        public async Task<IActionResult> GetFeaturedClothes()
        {
            IEnumerable<ProductModel> featuredProducts = await clothesService.GetFeaturedClothesAsync();

            return Ok(featuredProducts);
        }
        [HttpGet("GetProductsByGender")]
        public async Task<IActionResult> GetProductsByGender([FromQuery]string gender)
        {
            var result = await this.clothesService.GetProductByGender(gender);

            return Ok(result);
        }
        [HttpGet("AboutProduct")]
        public async Task<IActionResult>GetProductById([FromQuery]int productId)
        {
            if (!await clothesService.CheckIfProductExistsByIdAsync(productId))
            {
                return BadRequest(new {Error = "Product with such an id does not exist"});
            }
            if (await clothesService.CheckForProductIsShoesAsync(productId))
            {
                ProductInfo<double> shoesproductInfo = await clothesService.GetProductByIdAsync<double>(productId);

                return Ok(shoesproductInfo);
            }

            ProductInfo<string> productInfo = await clothesService.GetProductByIdAsync<string>(productId);

            return Ok(productInfo);
        }
    }
}
