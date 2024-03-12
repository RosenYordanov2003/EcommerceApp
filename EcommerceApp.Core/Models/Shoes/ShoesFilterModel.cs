
using EcommerceApp.Core.Models.Products;

namespace EcommerceApp.Core.Models.Shoes
{
    public class ShoesFilterModel : ProductFeatureModel
    {
        public string SubCategory { get; set; } = null!;
        public string Brand { get; set; } = null!;
    }
}
