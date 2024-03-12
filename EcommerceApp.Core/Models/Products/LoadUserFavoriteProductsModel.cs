namespace EcommerceApp.Core.Models.Products
{
    using Shoes;
    public class LoadUserFavoriteProductsModel
    {
        public LoadUserFavoriteProductsModel()
        {
            Products = new List<ProductFeatureModel>();
        }
        public string UserName { get; set; } = null!;

        public IEnumerable<ProductFeatureModel> Products { get; set; }
    }
}
