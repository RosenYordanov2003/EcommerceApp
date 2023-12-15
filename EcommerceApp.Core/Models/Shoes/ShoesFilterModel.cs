
namespace EcommerceApp.Core.Models.Shoes
{
    public class ShoesFilterModel : ShoesFeatureModel
    {
        public string Category { get; set; } = null!;
        public string SubCategory { get; set; } = null!;
        public string Brand { get; set; } = null!;
    }
}
