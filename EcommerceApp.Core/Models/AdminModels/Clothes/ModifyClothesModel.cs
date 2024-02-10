namespace EcommerceApp.Core.Models.AdminModels.Clothes
{
    using ProductStocks;
    public class ModifyClothesModel : ModifyModel
    {
        public ModifyClothesModel()
        {
            ProductStocks = new List<ProductStock<string>>();
        }
        public IEnumerable<ProductStock<string>> ProductStocks { get; set; }
    }
}
