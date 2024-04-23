namespace EcommerceApp.Core.Models.PromotionCodes
{
    public class CouponModel
    {
        public Guid Id { get; set; }
        public decimal DiscountPercantages { get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}
