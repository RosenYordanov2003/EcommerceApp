namespace EcommerceApp.Core.Models.AdminModels.Clothes
{
    using Brands;
    using Categories;
    using Models.Promotion;
    public class ModifyModel : ClothesModel
    {
        public ModifyModel()
        {
            Categories = new List<CategoryModel>();
            Brands = new List<BrandModel>();
        }
        public string? Description { get; set; }
        public PromotionModel? PromotionModel { get; set; }
        public int SelectedBrandId { get; set; }
        public int SelectedCategoryId { get; set; }
        public IEnumerable<CategoryModel> Categories { get; set; }
        public IEnumerable<BrandModel> Brands { get; set; }
    }
}
