namespace EcommerceApp.Core.Services
{
    using Contracts;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models.AdminModels.Dashboard;
    using Models.AdminModels.Orders;
    using System.Collections.Generic;

    public class DashboardService : IDashboardService
    {
        private readonly ApplicationDbContext dbContext;
        public DashboardService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<OrderModel>> GetAllOrdersAsync()
        {
            return await dbContext.Orders
                 .OrderByDescending(order => order.FinishedOn)
                 .Select(order => new OrderModel()
                 {
                     Id = order.Id,
                     Status = order.FinishedOn.AddDays(order.ShippingMethod == "fast" ? 2 : 4) < DateTime.Now ? "Delivered" : "Pending",
                     Price = order.Price
                 })
                 .ToArrayAsync();
        }

        public async Task<DashboardModel> GetDashboardInfoAsync(DateTime? particularDate, DateTime? particularMonth)
        {
            int currentMoth = DateTime.Now.Month;

            DashboardModel dashboardModel = new DashboardModel();

            dashboardModel.TotalSales = await dbContext.Orders.SumAsync(o => o.Price);
            dashboardModel.TotalSalesForTheMonth = await dbContext.Orders
                .Where(order => order.FinishedOn.Month == currentMoth)
                .SumAsync(o => o.Price);

            dashboardModel.Orders = await GetRecentOrdersAsync();

            if (particularDate.HasValue)
            {
                dashboardModel.TotalSalesForParticularDay = await dbContext.Orders
                    .Where(order => order.FinishedOn.Day == particularDate.Value.Day
                    && order.FinishedOn.Month == particularDate.Value.Month
                    && order.FinishedOn.Year == particularDate.Value.Year)
                    .SumAsync(order => order.Price);
            }
            if (particularMonth.HasValue)
            {
                dashboardModel.TotalSalesForParticulMonth = await dbContext.Orders
                   .Where(order => order.FinishedOn.Month == particularMonth.Value.Month
                   && order.FinishedOn.Year == particularMonth.Value.Year)
                   .SumAsync(order => order.Price);
            }

            return dashboardModel;
        }

        public async Task<IEnumerable<OrderModel>> GetRecentOrdersAsync()
        {
            return  await dbContext.Orders
                .OrderByDescending(order => order.FinishedOn)
                .Select(order => new OrderModel()
                {
                    Id = order.Id,
                    Status = order.FinishedOn.AddDays(order.ShippingMethod == "fast" ? 2 : 4) < DateTime.Now ? "Delivered" : "Pending",
                    Price = order.Price
                })
                .Take(7)
                .ToListAsync();
        }
    }
}
