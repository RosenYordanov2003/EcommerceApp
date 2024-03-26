namespace EcommerceApp.Core.Models.AdminModels.Files
{
    using Microsoft.AspNetCore.Http;
    public class FileModel
    {
        public FileModel()
        {
            ImgFiles = new List<IFormFile>();
        }
        public IEnumerable<IFormFile> ImgFiles { get; set; } = null!;
    }
}
