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
        private readonly IClothesService clothesService;
        public ProductController(IShoesService shoesService, IClothesService clothesService)
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
    }
}
