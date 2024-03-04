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
    using System.Text;
    using Core.Models.PromotionCodes;
    using EcommerceApp.SignalR;
    using Microsoft.AspNetCore.SignalR;

    [ApiController]
    [Authorize]
    [Produces("application/json")]
    [Route("api/cart")]
    public class CartController : ControllerBase
    {
        private readonly ICartService cartService;
        private readonly IEmailSender emailSender;
        private readonly IOrderService orderService;
        private readonly IPromotionCodeService promotionCodeService;
        private readonly IProductStockService productStockService;
        private readonly UserManager<User> userManager;
        private readonly IHubContext<NotificationsHub> hubContext;
        public CartController(ICartService cartService, IEmailSender emailSender,
            UserManager<User> userManager, IOrderService orderService, IPromotionCodeService promotionCodeService
            , IProductStockService productStockService, IHubContext<NotificationsHub> hubContext)
        {
            this.cartService = cartService;
            this.emailSender = emailSender;
            this.userManager = userManager;
            this.orderService = orderService;
            this.promotionCodeService = promotionCodeService;
            this.productStockService = productStockService;
            this.hubContext = hubContext;
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] AddProductToCartModel model)
        {
            if (!await productStockService.CheckForProductQuantityAsync(model.CategoryName, model.ProductId, model.Size, model.Quantity))
            {
                return Ok(new { Success = false, Error = "Not available product quantity" });
            }
            await cartService.AddProductToUserCartAsync(model);
            await productStockService.DecreaseProductStockQuantity(model.CategoryName, model.ProductId, model.Size, model.Quantity);

            return Ok(new { Success = true });
        }
        [HttpPost]
        [Route("RemoveProduct")]
        public async Task<IActionResult> RemoveProductFromUserCart([FromBody] RemoveCartProductModel model)
        {
            await cartService.RemoveProductFromUserCartAsync(model);
            await productStockService.IncreaseProductStockQuantity(model.CategoryName, model.ProductId, model.Size, model.Quantity);

            return Ok();
        }
        [HttpPost]
        [Route("ModifyProducCarttQuantity")]
        public async Task<IActionResult> IncreaseProductQuantity([FromBody] ModifyProductCartQuantityModel model)
        {
            if (model.Operation == "increase")
            {
                if (!await productStockService.CheckForProductQuantityAsync(model.ProductCategoryName, model.ProductId, model.Size, 1))
                {
                    return Ok(new { Success = false, Error = "There is no available product quantity" });
                }
                await cartService.IncreaseProductCartQuantityAsync(model);
                await productStockService.DecreaseProductStockQuantity(model.ProductCategoryName, model.ProductId, model.Size, 1);

                return Ok(new { Success = true });
            }
            await cartService.DecreaseProductCartQuantityAsync(model);
            await productStockService.IncreaseProductStockQuantity(model.ProductCategoryName, model.ProductId, model.Size, 1);

            return Ok(new { Success = true });
        }
        [HttpPost]
        [Route("FinishOrder")]
        public async Task<IActionResult> FinishOrder([FromBody] OrderModel orderModel)
        {
            if (!await cartService.CheckICartProductsQuantityIsAvailableAsync(orderModel.UserId))
            {
                return Ok(new { Success = false });
            }

            await orderService.MakeOrderAsync(orderModel);

            if (orderModel.Cuppon != null)
            {
                await promotionCodeService.RemoveCupponByIdAsync(orderModel.Cuppon.Id);
            }

            var userCart = await cartService.GetUserCartByUserIdAsync(orderModel.UserId);

            await cartService.ClearUserCartAsyncAfterFinishingOrder(orderModel.UserId);

            string htmlEmailContent = GenereateEmailHtmlContent(userCart, orderModel);

            await emailSender.SendEmailAsync(orderModel.UserOrderInfo.Email, "Successfully complete your order", htmlEmailContent);

            decimal discount = await promotionCodeService.CheckWheterUserReachesDiscount(orderModel.UserId);

            if (discount > 0)
            {
                PromotionCodeModel promotionCode = await promotionCodeService.GeneratePromotionCodeForUserAsync(orderModel.UserId, discount);

                await emailSender.SendEmailAsync(orderModel.UserOrderInfo.Email, "Congratulations You Have Earned A Promotion Code",
                    $" <main style=\"font-family: Arial, Helvetica, sans-serif; display: flex; flex-direction: column; align-items: center; justify-content: center;\">\r\n        <h1>You Have Earned A Promotion Code</h1>\r\n        <p>Your Promotion Code:<span style=\"font-weight: bolder; font-size: 1.2rem; display: inline-block; margin-left: 0.3rem;\">{promotionCode.Id}</span> </p>\r\n        <p>Code Discount: <span style=\"font-weight: bolder; font-size: 1.1rem; display: inline-block; margin-left: 0.3rem;\">{promotionCode.DiscountPercantages:F2}%</span> </p>\r\n        <p>The Code Is Valid Till: <span style=\"font-weight: bolder; font-size: 1.1rem; display: inline-block; margin-left: 0.3rem;\">{promotionCode.ExpirationTime.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss")}/span></p>\r\n    </main>");
            }

            await hubContext.Clients.All.SendAsync("PurchaseMade");

            return Ok(new { Success = true });
        }

        private string GenereateEmailHtmlContent(CartModel cartModel, OrderModel orderModel)
        {
            StringBuilder sb = new StringBuilder();

            string result = GenereteProductEmailContent(cartModel);

            sb.AppendLine($"<body>\r\n\r\n    <main style=\"display: flex; flex-direction: column; align-items: center; justify-content: center;\">\r\n        <h2 style=\"margin-bottom: 5rem; font-family: arial, sans-serif;\">Your Order Has Been Completed Successfully</h2>\r\n        <table style=\"border-collapse:collapse;width:100%;font-family: arial, sans-serif; color: black;\">\r\n            <tbody>\r\n               {result}\r\n            </tbody>\r\n        </table>\r\n        <table style=\"border-collapse:collapse;width:100%;font-family: arial, sans-serif; margin-top: 1rem; margin-bottom: 1rem;\">\r\n            <tbody style=\"display: flex;\">\r\n                <tr>\r\n                    <th style=\" border: 1px solid #dddddd; text-align: left;padding: 8px;\">Total</th>\r\n                  </tr>\r\n                  <tr>\r\n                    <td style=\" border: 1px solid #dddddd; text-align: left;padding: 8px;\">${orderModel.TotalPrice:F2}</td>\r\n                  </tr>\r\n            </tbody>\r\n           \r\n        </table>\r\n        <div>\r\n            <h2 style=\"font-family: arial, sans-serif;\">Shipping Information</h2>\r\n            <p style=\"font-family: arial, sans-serif;\">Recipient: {orderModel.UserOrderInfo.FirstName} {orderModel.UserOrderInfo.LastName}</p>\r\n            <div style=\"font-family: arial, sans-serif;\"> \r\n                <p>Shipping to: {orderModel.UserOrderInfo.City},{orderModel.UserOrderInfo.Country},{orderModel.UserOrderInfo.StreetAdress}</p>\r\n            </div>\r\n            <div style=\"font-family: arial, sans-serif;\">\r\n                <p>Shipping Method: {orderModel.ShippingInfo.Method}</p>\r\n                <p>Shipping price: ${orderModel.ShippingInfo.Price:F2}</p>\r\n            </div>\r\n            <p style=\"font-family: arial, sans-serif;\">POSTAL CODE: {orderModel.UserOrderInfo.PostalCode}</p>\r\n        </div>\r\n    </main>\r\n</body>");

            return sb.ToString().TrimEnd();
        }

        private string GenereteProductEmailContent(CartModel cartModel)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(" <tr>\r\n                    <th style=\" border: 1px solid #dddddd; text-align: left;padding: 8px;\">Product</th>\r\n                    <th style=\" border: 1px solid #dddddd; text-align: left;padding: 8px;\">Size</th>\r\n                    <th style=\" border: 1px solid #dddddd; text-align: left;padding: 8px;\">Quantity</th>\r\n                    <th style=\" border: 1px solid #dddddd; text-align: left;padding: 8px;\">Sub Price</th>\r\n                    <th style=\" border: 1px solid #dddddd; text-align: left;padding: 8px;\">Total Price</th>\r\n                  </tr>");

            foreach (var product in cartModel.CartProducts)
            {
                sb.AppendLine($" <tr>\r\n <td style=\" border: 1px solid #dddddd; text-align: left;padding: 8px;\">{product.Name}</td>\r\n  <td style=\" border: 1px solid #dddddd; text-align: left;padding: 8px;\">{product.Size}</td>\r\n <td style=\" border: 1px solid #dddddd; text-align: left;padding: 8px;\">X {product.Quantity}</td>\r\n   <td style=\" border: 1px solid #dddddd; text-align: left;padding: 8px;\">${product.Price:F2}</td>\r\n                    <td style=\" border: 1px solid #dddddd; text-align: left;padding: 8px;\">${product.Price * product.Quantity:F2}</td>\r\n  </tr>");
            }
            foreach (var product in cartModel.CartShoes)
            {
                sb.AppendLine($" <tr>\r\n <td style=\" border: 1px solid #dddddd; text-align: left;padding: 8px;\">{product.Name}</td>\r\n  <td style=\" border: 1px solid #dddddd; text-align: left;padding: 8px;\">{product.Size}</td>\r\n <td style=\" border: 1px solid #dddddd; text-align: left;padding: 8px;\">X {product.Quantity}</td>\r\n   <td style=\" border: 1px solid #dddddd; text-align: left;padding: 8px;\">${product.Price:F2}</td>\r\n                    <td style=\" border: 1px solid #dddddd; text-align: left;padding: 8px;\">${product.Price * product.Quantity:F2}</td>\r\n  </tr>");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
