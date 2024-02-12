namespace EcommerceApp.Core.Contracts
{
    using Models.AdminModels.Clothes;
    public interface IPictureService
    {
        Task UploadImgAsync(UploadProductImgModel uploadProductImgModel, string path);
    }
}
