namespace EcommerceApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using EcommerceApp.Core.Contracts;
    using EcommerceApp.Core.Models.Shoes;

    [Route("api/shoes")]
    [ApiController]
    [Produces("application/json")]
    public class ShoesController : ControllerBase
    {
        private readonly IShoesService shoesService;
        public ShoesController(IShoesService shoesService)
        {
            this.shoesService = shoesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFeaturedShoes()
        {
            IEnumerable<ShoesFeatureModel> featuredShoes = await this.shoesService.GetFeaturedShoesAsync();

            return Ok(featuredShoes);
        }
    }
}
