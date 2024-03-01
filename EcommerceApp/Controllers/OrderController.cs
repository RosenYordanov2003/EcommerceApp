namespace EcommerceApp.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Core.Contracts;
    using Core.Models.Orders;

    [Route("api/order")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        [Route("Details")]
        public async Task<IActionResult> GetOrderDetails([FromQuery] Guid id)
        {
            if (!await orderService.CheckIfOrderExistsByIdAsync(id))
            {
                return BadRequest();
            }
            OrderDetailsModel order = await orderService.GetOrderDetailsByIdAsync(id);

            return Ok(order);
        }
    }
}
