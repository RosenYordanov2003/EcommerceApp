namespace EcommerceApp.Core.Models.Orders
{
    using System.ComponentModel.DataAnnotations;
    using static EcommerceApp.GlobalConstants.EntityValidation.OrderEntity;
    public class ShippingInfo
    {
        [Required]
        [MaxLength(ShippingMethodMaxLength)]
        public string Method { get; set; } = null!;
        public decimal Price { get; set; }
    }
}