namespace EcommerceApp.Core.Models.AdminModels.Shoes
{
    using AdminModels.Clothes;
    using ProductStocks;

    public class ModifyShoesModel : ModifyModel
    {
        public ModifyShoesModel()
        {
            ProductStocks = new List<ProductStock<double>>();
        }
        public IEnumerable<ProductStock<double>> ProductStocks { get; set; }
    }
}
