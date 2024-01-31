namespace EcommerceApp.Core.Contracts
{
    using Models.AdminModels.Dashboard;
    public interface IDashboardService
    {
        Task<DashboardModel> GetDashboardInfoAsync(DateTime? particularDate);
    }
}
