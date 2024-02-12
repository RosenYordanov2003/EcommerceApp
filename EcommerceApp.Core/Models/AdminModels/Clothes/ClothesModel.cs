namespace EcommerceApp.Core.Models.AdminModels.Clothes
{
    using Pictures;
    public class ClothesModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int StarRating { get; set; }
        public bool IsArchived { get; set; }
        public IEnumerable<AdminPictureModel> ImgUrls { get; set; } = null!; 
    }
}
