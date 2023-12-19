namespace EcommerceApp.Core.Models.Products
{
    public class FilterProductModel : ProductModel
    {
        public FilterProductModel()
        {
            SubCategories = new List<string>();
        }
        public ICollection<string> SubCategories { get; set; }
        public string Brand { get; set; } = null!;
    }
}
