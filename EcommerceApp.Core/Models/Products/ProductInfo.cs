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
            RelatedProducts = new List<ProductModel>();
        }

        public IEnumerable<ReviewModel> Reviews { get; set; }

        public IEnumerable<ProductStock<T>> ProductStocks { get; set; }
        public string Brand { get; set; } = null!;
        public double AverageRating => Reviews.Count() > 0 ? (double)Reviews.Sum(r => r.StarEvaluation) / Reviews.Count() : 0;
        public int TotalReviewsCount => Reviews.Count();
        public string Gender { get; set; } = null!;
        public IEnumerable<ProductModel> RelatedProducts { get; set; }
        public bool IsAvalilable { get; set; }
    }
}
