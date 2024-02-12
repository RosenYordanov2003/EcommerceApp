namespace EcommerceApp.Core.Models.AdminModels.ProductStock
{
    using System.ComponentModel.DataAnnotations;
    using static GlobalConstants.EntityValidation.ProductStockEntity;
    public class AddProductStockModel
    {
        public int ProductStockId { get; set; }
        [Range(QuantityMinValue, QuantityMaxValue)]
        public int ProductQuantityToAdd { get; set; }
        public string ProductCategory { get; set; } = null!;
    }
}
