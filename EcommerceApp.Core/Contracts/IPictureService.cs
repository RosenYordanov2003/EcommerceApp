namespace EcommerceApp.Core.Contracts
{
    using Models.AdminModels.Pictures;
    using Models.AdminModels.Clothes;
    public interface IPictureService
    {
        Task UploadImgAsync(UploadProductImgModel uploadProductImgModel, string path);
        Task<bool> CheckIfImgExistsAsync(int pictureId);
        Task DeleteImgAsync(DeletePictureModel deletePictureModel, string path);
    }
}
