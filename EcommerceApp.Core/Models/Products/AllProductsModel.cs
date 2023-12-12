namespace EcommerceApp.Core.Models.Products
{
    using Models.Brands;
    using Models.Categories;
    using Models.Shoes;
    public class AllProductsModel
    {
        public AllProductsModel()
        {
            Products = new List<ProductModel>();
            Shoes = new List<ShoesFeatureModel>();
            Brands = new List<BrandModel>();
            Categories = new List<CategoryModel>();
        }
        public IEnumerable<ProductModel> Products { get; set; }

        public IEnumerable<ShoesFeatureModel> Shoes { get; set; }

        public IEnumerable<BrandModel> Brands { get; set; }

        public IEnumerable<CategoryModel> Categories { get; set; }
    }
}
