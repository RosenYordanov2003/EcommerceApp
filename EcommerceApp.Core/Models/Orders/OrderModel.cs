namespace EcommerceApp.Core.Models.Orders
{
    using Models.PromotionCodes;
    public class OrderModel
    {
        public UserOrderInfoModel UserOrderInfo { get; set; } = null!;
        public ShippingInfoModel ShippingInfo { get; set; } = null!;
        public decimal TotalPrice { get; set; }
        public Guid UserId { get; set; }
        public decimal Discount { get; set; }
        public CouponModel? Cuppon { get; set; }
    }
}
