namespace EcommerceApp.Core.Models.Products
{
    using Models.Brands;
    using Models.Categories;
    using Models.Shoes;
    public class AllProductsModel
    {
        public AllProductsModel()
        {
            Products = new List<FilterProductModel>();
            Shoes = new List<ShoesFilterModel>();
            Brands = new List<BrandModel>();
            Categories = new List<CategoryModel>();
        }
        public IEnumerable<FilterProductModel> Products { get; set; }

        public IEnumerable<ShoesFilterModel> Shoes { get; set; }

        public IEnumerable<BrandModel> Brands { get; set; }

        public IEnumerable<CategoryModel> Categories { get; set; }
    }
}
