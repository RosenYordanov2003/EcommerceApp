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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("Details")]
        public async Task<IActionResult> GetOrderDetails([FromQuery] Guid id)
        {
            try
            {
                if (!await orderService.CheckIfOrderExistsByIdAsync(id))
                {
                    return NotFound();
                }
                OrderDetailsModel order = await orderService.GetOrderDetailsByIdAsync(id);

                return Ok(order);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
