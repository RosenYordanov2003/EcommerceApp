namespace EcommerceApp.Core.Contracts
{
    using Models.AdminModels.Orders;
    using Models.AdminModels.Dashboard;
    public interface IDashboardService
    {
        Task<DashboardModel> GetDashboardInfoAsync(DateTime? particularDate, DateTime? particularMonth);
        Task<IEnumerable<OrderModel>> GetAllOrdersAsync(); 
        Task<IEnumerable<OrderModel>> GetRecentOrdersAsync();
    }
}
