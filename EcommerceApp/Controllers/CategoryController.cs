using EcommerceApp.Core.Contracts;
using EcommerceApp.Core.Models.Categories;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Controllers
{
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
        public async Task<IActionResult> GetCategories([FromQuery]string gender)
        {
            var categories = await categoryService.GetCategoriesByGender(gender);
            return Ok(categories);
        }
    }
}
