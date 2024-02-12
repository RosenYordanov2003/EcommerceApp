namespace EcommerceApp.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using Contracts;
    using Data;
    using Infrastructure.Data.Models;
    using Models.AdminModels.Clothes;
    using Models.AdminModels.Pictures;
    using System;

    public class PictureService : IPictureService
    {
        private readonly ApplicationDbContext dbContext;
        public PictureService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> CheckIfImgExistsAsync(int pictureId)
        {
            return await dbContext.Pictures.AnyAsync(p => p.Id == pictureId);
        }

        public async Task DeleteImgAsync(DeletePictureModel deletePictureModel, string path)
        {
            Picture picture = await dbContext.Pictures
                .FirstAsync(p => p.Id == deletePictureModel.Id);

            string[] tokens = picture.ImgUrl.Split("/", StringSplitOptions.RemoveEmptyEntries);

            if (tokens.Length > 1)
            {
                string fileName = tokens[tokens.Length - 1];

                CheckIfImgsIsOnTheDisk(path, fileName);
            }

            dbContext.Pictures.Remove(picture);
            await dbContext.SaveChangesAsync();
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
        public void CheckIfImgsIsOnTheDisk(string path, string fileNameToFind)
        {
            string[] files = Directory.GetFiles(path);

            foreach (string file in files)
            {
                string[] fileTokens = file.Split("\\");
                string fileName = fileTokens[fileTokens.Length - 1];

                if (fileName == fileNameToFind)
                {
                    File.Delete(file);
                    break;
                }
            }
        }
    }
}
