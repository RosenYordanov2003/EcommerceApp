using EcommerceApp.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriyController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoriyController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategories(string gender)
        {
            var categories = await categoryService.GetCategoriesByGender(gender);

            return new JsonResult(categories);
        }
    }
}
