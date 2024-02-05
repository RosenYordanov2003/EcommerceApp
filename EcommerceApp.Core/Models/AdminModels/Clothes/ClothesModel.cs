namespace EcommerceApp.Core.Models.AdminModels.Clothes
{
    using Pictures;
    public class ClothesModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int StarRating { get; set; }
        public IEnumerable<PictureModel> ImgUrls { get; set; } = null!; 
    }
}
