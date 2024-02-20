namespace EcommerceApp.Core.Models.Shoes
{
    using EcommerceApp.Core.Models.Promotion;
    using Pictures;
    public class ShoesFeatureModel
    {
        public ShoesFeatureModel()
        {
            Pictures = new List<PictureModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int StarRating { get; set; }
        public decimal Price { get; set; }
        public IEnumerable<PictureModel> Pictures { get; set; }
        public string CategoryName { get; set; } = null!;
        public bool IsFavorite { get; set; }
        public decimal DicountPercentage { get; set; }
    }
}
