﻿namespace EcommerceApp.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using Core.Contracts;
    using Core.Models.Products;
    using Infrastructure.Data.Models;
    using System.Net;

    [ApiController]
    [Produces("application/json")]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IShoesService shoesService;
        private readonly IProductSevice productService;
        private readonly UserManager<User> userManager;
        public ProductController(IShoesService shoesService, IProductSevice clothesService, UserManager<User> userManager)
        {
            this.shoesService = shoesService;
            this.productService = clothesService;
            this.userManager = userManager;
        }

        [HttpGet("GetFeaturedClothes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFeaturedClothes([FromQuery] string? userId)
        {
            Guid? userIdResult = ExtractUserId(userId);

            IEnumerable<ProductModel> featuredProducts = await productService.GetFeaturedClothesAsync(userIdResult);

            return Ok(featuredProducts);
        }
        [HttpGet("GetProductsByGender")]
        public async Task<IActionResult> GetProductsByGender([FromQuery] string gender, [FromQuery]string? userId)
        {
            Guid? userIdResult = ExtractUserId(userId);
            var result = await productService.GetProductByGender(gender, userIdResult);

            return Ok(result);
        }

        [HttpGet("About")]
        public async Task<IActionResult> GetProductById([FromQuery] int productId, [FromQuery] string? userId)
        {
            Guid? userIdResult = ExtractUserId(userId);

            if (!await productService.CheckIfProductExistsByIdAsync(productId))
            {
                return BadRequest(new { Error = "Product with such an id does not exist" });
            }

            ProductInfoModel<string> productInfo = await productService.GetProductByIdAsync(productId, userIdResult);

            return Ok(productInfo);
        }
        [HttpPost]
        [Authorize]
        [Route("AddToFavoriteProducts")]
        public async Task<IActionResult> AddToFavoriteProducts([FromBody] UserFavoriteProductModel userFavoriteProductModel)
        {
            if (!await productService.CheckIfProductExistsByIdAsync(userFavoriteProductModel.ProductId))
            {
                return BadRequest(new { Error = "Product with such an id does not exist" });
            }
            await productService.AddProductToUserFavoritesListAsync(userFavoriteProductModel);

            return Ok();
        }
        [HttpPost]
        [Route("RemoveFromUserFavoriteLists")]
        public async Task<IActionResult> RemoveFromUserFavoriteLists([FromBody] UserFavoriteProductModel userFavoriteProductModel)
        {
            if (!await productService.CheckIfProductExistsByIdAsync(userFavoriteProductModel.ProductId))
            {
                return BadRequest(new { Error = "Product with such an id does not exist" });
            }
            await productService.RemoveProductFromUserFavoriteListAsync(userFavoriteProductModel);

            return Ok();
        }
        [HttpGet]
        [Route("FavoriteProducts")]
        public async Task<IActionResult> GetUserFavoriteProducts([FromQuery]Guid userId)
        {
            User user = await userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                return BadRequest();
            }

            IEnumerable<ProductFeatureModel> products = await productService.LoadUserFavoriteProductsAsync(userId);

            return Ok(new LoadUserFavoriteProductsModel() { UserName = user.UserName, Products = products });
        }

        private static Guid? ExtractUserId(string? userId)
        {
            userId = userId?.ToUpper();
            Guid? userIdResult = string.IsNullOrWhiteSpace(userId) ? null : Guid.Parse(userId);
            return userIdResult;
        }
    }
}
