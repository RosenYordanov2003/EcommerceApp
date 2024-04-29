namespace EcommerceApp.Core.Models.Orders
{
    using System.ComponentModel.DataAnnotations;
    using static GlobalConstants.EntityValidation.OrderEntity;
    public class ShippingInfoModel
    {
        [Required]
        [MaxLength(ShippingMethodMaxLength)]
        public string Method { get; set; } = null!;
        public decimal Price { get; set; }
    }
}