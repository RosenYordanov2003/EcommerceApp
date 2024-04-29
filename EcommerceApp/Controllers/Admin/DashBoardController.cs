namespace EcommerceApp.Controllers.Admin
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using Core.Contracts;
    using Core.Models.AdminModels.Dashboard;
    using static Common.GeneralApplicationConstants;

    [Authorize(Roles = AdminRoleName)]
    [Route("api/dashboard")]
    [ApiController]
    public class DashBoardController : ControllerBase
    {
        private readonly IDashboardService dashboardService;

        public DashBoardController(IDashboardService dashboardService)
        {
            this.dashboardService = dashboardService;
        }

        [HttpGet]
        [Route("Dashboard")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDashboardInfo([FromQuery]string? particularDay, string?particularMonth)
        {
            DateTime? date = null;
            DateTime? monthDate = null;
            if (!string.IsNullOrWhiteSpace(particularDay) && particularDay!="undefined")
            {
                date = DateTime.Parse(particularDay);
            }
            if (!string.IsNullOrWhiteSpace(particularMonth) && particularMonth != "undefined")
            {
                monthDate = DateTime.Parse(particularMonth);
            }
            try
            {
                DashboardModel dashboard = await dashboardService.GetDashboardInfoAsync(date, monthDate);

                return Ok(dashboard);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet]
        [Route("AllOrders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllOrders()
        {
            var allOrders = await dashboardService.GetAllOrdersAsync();

            return Ok(allOrders);
        }
        [HttpGet]
        [Route("RecentOrders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRecentOrders()
        {
            var allOrders = await dashboardService.GetRecentOrdersAsync();

            return Ok(allOrders);
        }
    }
}
