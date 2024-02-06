namespace EcommerceApp.Core.Models.AdminModels.Clothes
{
    using Brands;
    using Categories;
    using ProductStocks;
    using Promotion;
    public class ModifyClothesModel : ClothesModel
    {
        public ModifyClothesModel()
        {
            ProductStocks = new List<ProductStock<string>>();
            Categories = new List<CategoryModel>();
            Brands = new List<BrandModel>();
        }
        public string? Description { get; set; }
        public bool isArchived { get; set; }
        public PromotionModel? PromotionModel { get; set; }
        public int SelectedBrandId { get; set; }
        public int SelectedCategoryId { get; set; }
        public IEnumerable<ProductStock<string>> ProductStocks { get; set; }
        public IEnumerable<CategoryModel> Categories { get; set; }
        public IEnumerable<BrandModel> Brands { get; set; }
    }
}
