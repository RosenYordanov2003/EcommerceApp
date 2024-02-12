namespace EcommerceApp.Core.Services
{
    using Contracts;
    using EcommerceApp.Data;
    using EcommerceApp.Infrastructure.Data.Models;
    using Models.AdminModels.Clothes;
    public class PictureService : IPictureService
    {
        private readonly ApplicationDbContext dbContext;
        public PictureService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task UploadImgAsync(UploadProductImgModel uploadProductImgModel, string path)
        {
            string fileName = string.Format($"{uploadProductImgModel.ProductId}_{uploadProductImgModel.PictureFile.FileName}");
            string filePath = Path.Combine(path, fileName);


            using (FileStream stream = new FileStream(Path.Combine(filePath), FileMode.Create))
            {
                await uploadProductImgModel.PictureFile.CopyToAsync(stream);
            }
            Picture picture = new Picture();


            picture.ShoesId = uploadProductImgModel.ProductCategory == "Shoes" ? uploadProductImgModel.ProductId : null;
            picture.ClothId = uploadProductImgModel.ProductCategory != "Shoes" ? uploadProductImgModel.ProductId : null;
            picture.ImgUrl = uploadProductImgModel.ProductCategory == "Shoes"
                ? $"https://localhost:7122/shoes/{fileName}"
                : $"https://localhost:7122/clothes/{fileName}";

            await dbContext.Pictures.AddAsync(picture);

            await dbContext.SaveChangesAsync();
        }
    }
}
