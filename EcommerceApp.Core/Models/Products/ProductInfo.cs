namespace EcommerceApp.Core.Models.Products
{
    using ProductStocks;
    using Models.Review;
    public class ProductInfo<T> : ProductModel
    {
        public ProductInfo()
        {
            Reviews = new HashSet<ReviewModel>();
            ProductStocks = new HashSet<ProductStock<T>>();
        }

        public IEnumerable<ReviewModel> Reviews { get; set; }

        public IEnumerable<ProductStock<T>> ProductStocks { get; set; }
    }
}
