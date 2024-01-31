namespace EcommerceApp.Core.Models.AdminModels.Dashboard
{
    using Orders;
    public class DashboardModel
    {
        public DashboardModel()
        {
            Orders = new List<OrderModel>();
        }
        public decimal TotalSales { get; set; }
        public decimal TotalSalesForTheMonth { get; set; }
        public decimal TotalSalesForParticularDay { get; set; }
        public IEnumerable<OrderModel> Orders { get; set; }
    }
}
