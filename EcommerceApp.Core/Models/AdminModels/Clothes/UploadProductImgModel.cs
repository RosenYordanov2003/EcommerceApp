namespace EcommerceApp.Core.Models.AdminModels.Clothes
{
    using Microsoft.AspNetCore.Http;
    public class UploadProductImgModel
    {
        public int ProductId { get; set; }
        public string ProductCategory { get; set; } = null!;
        public IFormFile PictureFile { get; set; } = null!;
    }
}
