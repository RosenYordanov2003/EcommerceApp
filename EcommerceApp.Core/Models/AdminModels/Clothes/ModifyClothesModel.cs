namespace EcommerceApp.Core.Models.AdminModels.Clothes
{
    using ProductStocks;
    using Promotion;
    public class ModifyClothesModel : ClothesModel
    {
        public ModifyClothesModel()
        {
            ProductStocks = new List<ProductStock<string>>();
        }
        public string? Description { get; set; }
        public bool isArchived { get; set; }
        public PromotionModel? PromotionModel { get; set; }
        public string Brand { get; set; } = null!;
        public string Category { get; set; } = null!;
        public IEnumerable<ProductStock<string>> ProductStocks { get; set; }
    }
}
