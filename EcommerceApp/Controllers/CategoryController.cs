namespace EcommerceApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Core.Contracts;

    [ApiController]
    [Route("api/categories")]
    [Produces("application/json")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        [Route("get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCategories([FromQuery]string gender)
        {
            var categories = await categoryService.GetCategoriesByGender(gender);
            return Ok(categories);
        }
    }
}
