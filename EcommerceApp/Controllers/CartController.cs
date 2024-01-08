namespace EcommerceApp.Controllers
{
    using Core.Contracts;
    using Core.Models.Cart;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Produces("application/json")]
    [Route("api/cart")]
    public class CartController : ControllerBase
    {
        private readonly ICartService cartService;
        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] AddProductToCartModel addProductToCartModel)
        {
            await cartService.AddProductToUserCartAsync(addProductToCartModel);

            return Ok();
        }
        [HttpPost]
        [Route("RemoveProduct")]
        public async Task<IActionResult> RemoveProductFromUserCart([FromBody] RemoveCartProductModel removeCartProductModel)
        {
            await cartService.RemoveProductFromUserCartAsync(removeCartProductModel);

            return Ok();
        }
    }
}
