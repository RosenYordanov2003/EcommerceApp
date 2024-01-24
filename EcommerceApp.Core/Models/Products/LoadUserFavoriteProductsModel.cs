namespace EcommerceApp.Core.Models.Products
{
    using Shoes;
    public class LoadUserFavoriteProductsModel
    {
        public LoadUserFavoriteProductsModel()
        {
            Products = new List<ShoesFeatureModel>();
        }
        public string UserName { get; set; } = null!;

        public IEnumerable<ShoesFeatureModel> Products { get; set; }
    }
}
