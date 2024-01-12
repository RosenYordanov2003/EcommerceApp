namespace EcommerceApp.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.AspNetCore.Mvc;
    using Core.Contracts;
    using Core.Models.Cart;
    using Core.Models.Orders;
    using Infrastructure.Data.Models;
  

    [ApiController]
    [Authorize]
    [Produces("application/json")]
    [Route("api/cart")]
    public class CartController : ControllerBase
    {
        private readonly ICartService cartService;
        private readonly IEmailSender emailSender;
        private readonly IOrderService orderService;
        private readonly UserManager<User> userManager;
        public CartController(ICartService cartService, IEmailSender emailSender, 
            UserManager<User> userManager, IOrderService orderService)
        {
            this.cartService = cartService;
            this.emailSender = emailSender;
            this.userManager = userManager;
            this.orderService = orderService;
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
        [HttpPost]
        [Route("ModifyProducCarttQuantity")]
        public async Task<IActionResult> IncreaseProductQuantity([FromBody] ModifyProductCartQuantityModel modifyProductCartQuantityModel)
        {
            await cartService.IncreaseProductQuantityAsync(modifyProductCartQuantityModel);

            return Ok();
        }
        [HttpPost]
        [Route("FinishOrder")]
        public async Task<IActionResult> FinishOrder([FromBody]OrderModel orderModel)
        {
            if (!await cartService.CheckICartProductsQuantityIsAvailableAsync(orderModel.UserId))
            {
                return Ok(new { Success = false });
            }

            await orderService.MakeOrderAsync(orderModel);
            var user = await userManager.FindByIdAsync(orderModel.UserId.ToString());

            await cartService.ClearUserCartAsyncAfterFinishingOrder(orderModel.UserId);

           await emailSender.SendEmailAsync(user.Email, "Successfully complete your order",
                "<h1>You have successfully completed your order<h1/>");

            return Ok(new { Success = true });
        }
    }
}
