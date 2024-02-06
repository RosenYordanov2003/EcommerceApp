namespace EcommerceApp.Core.Models.AdminModels.Promotion
{
    using System.ComponentModel.DataAnnotations;
    using static EcommerceApp.GlobalConstants.EntityValidation.PromotionEntity;
    public class AddPromotionModel
    {
        public DateTime ExpirationTime { get; set; }
        [Range(maximum:PromotionMaxValue, minimum:PromotionMinValue)]
        public decimal Percentages { get; set; }
        public int? ShoesId { get; set; }
        public int? ProductId { get; set; }
    }
}
