namespace EcommerceApp.Core.Models.AdminModels.ProductStock
{
    using System.ComponentModel.DataAnnotations;
    using static EcommerceApp.GlobalConstants.EntityValidation.ProductStockEntity;
    public class AddProductStockModel
    {
        public int ProductStockId { get; set; }
        public string Size { get; set; } = null!;

        [Range(QuantityMinValue, QuantityMaxValue)]
        public int ProductQuantityToAdd { get; set; }
    }
}
