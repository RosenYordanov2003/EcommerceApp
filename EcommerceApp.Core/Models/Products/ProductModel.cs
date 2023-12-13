namespace EcommerceApp.Core.Models.Products
{
    using Shoes;
    public class ProductModel : ShoesFeatureModel
    {
        public ProductModel()
        {
            SubCategories = new List<string>();
        }
        public string Description { get; set; } = null!;
        public ICollection<string> SubCategories { get; set; }
    }
}
