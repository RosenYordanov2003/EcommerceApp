namespace EcommerceApp.Core.Models.Promotion
{
    public class PromotionModel
    {
        public Guid? Id { get; set; }
        public decimal? PercentageDiscount { get; set; }
        public DateTime? ExpireTime { get; set; }
    }
}
