namespace EcommerceApp.Controllers.Admin
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using Core.Contracts;
    using Core.Models.AdminModels.Dashboard;
    using static EcommerceApp.Common.GeneralApplicationConstants;
    using Duende.IdentityServer.Events;
    using Core.Models.AdminModels.Orders;

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
            DashboardModel dashboard = await dashboardService.GetDashboardInfoAsync(date, monthDate);

            return Ok(dashboard);
        }
        [HttpGet]
        [Route("AllOrders")]
        public async Task<IActionResult> GetAllOrders()
        {
            var allOrders = await dashboardService.GetAllOrdersAsync();

            return Ok(allOrders);
        }
        [HttpGet]
        [Route("RecentOrders")]
        public async Task<IActionResult> GetRecentOrders()
        {
            var allOrders = await dashboardService.GetRecentOrdersAsync();

            return Ok(allOrders);
        }
    }
}
