namespace EcommerceApp.Controllers.Admin
{
    using EcommerceApp.Core.Contracts;
    using EcommerceApp.Core.Models.AdminModels.Clothes;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static EcommerceApp.Common.GeneralApplicationConstants;

    [ApiController]
    [Authorize(Roles = AdminRoleName)]
    [Produces("application/json")]
    [Route("api/clothes")]
    public class ClothesController : ControllerBase
    {
        private readonly IProductSevice productSevice;

        public ClothesController(IProductSevice productSevice)
        {
            this.productSevice = productSevice;
        }

        [HttpGet]
        [Route("LoadAllClothes")]
        public async Task<IActionResult> LoadAllClothes()
        {
            var allClothes = await productSevice.LoadAllClothesAsync();
            return Ok(allClothes);
        }
        [HttpGet]
        [Route("GetProductToModify")]
        public async Task<IActionResult> GetProductToModify([FromQuery] int productId)
        {
           var product = await productSevice.GetProductToModifyAsync(productId);
           return Ok(product);
        }
        [HttpPut]
        [Route("EditProduct")]
        public async Task<IActionResult> EditProductInfo([FromBody] EditProductModel editProductModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await productSevice.EditProductAsync(editProductModel);

            return Ok();
        }
    }
}
