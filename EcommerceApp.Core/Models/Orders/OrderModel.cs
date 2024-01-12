namespace EcommerceApp.Core.Models.Orders
{
    public class OrderModel
    {
        public UserOrderInfo UserOrderInfo { get; set; } = null!;
        public ShippingInfo ShippingInfo { get; set; } = null!;
        public decimal TotalPrice { get; set; }
        public Guid UserId { get; set; }
        public decimal Discount { get; set; }
    }
}
