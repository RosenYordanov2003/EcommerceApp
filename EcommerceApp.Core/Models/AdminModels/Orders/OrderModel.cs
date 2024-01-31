namespace EcommerceApp.Core.Models.AdminModels.Orders
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; } = null!;
    }
}
