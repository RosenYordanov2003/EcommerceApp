﻿namespace EcommerceApp.Core.Contracts
{
    using Models.AdminModels.Clothes;
    using Models.Shoes;
    using Models.Products;
    using EcommerceApp.Core.Models.AdminModels.Promotion;
    using Core.Models.Pager;

    public interface IProductSevice
    {
        Task<IEnumerable<ProductModel>> GetFeaturedClothesAsync(Guid? userId);
        Task<AllProductsModel> GetProductByGender(string gedner, Guid? userId);
        Task<bool> CheckIfProductExistsByIdAsync(int productId);
        Task<ProductInfo<string>> GetProductByIdAsync(int productId, Guid? userId);
        Task AddProductToUserFavoritesListAsync(UserFavoriteProduct userFavoriteProductmodel);
        Task RemoveProductFromUserFavoriteListAsync(UserFavoriteProduct userFavoriteProductmodel);
        Task<ICollection<GetUserFavoriteProductModel>> GetUserFavoriteProductsAsync(Guid userId);
        Task<IEnumerable<ProductFeatureModel>> LoadUserFavoriteProductsAsync(Guid userId);
        Task<IEnumerable<ClothesModel>> LoadAllClothesAsync(Pager pager);
        Task<ModifyClothesModel> GetProductToModifyAsync(int productId);
        Task EditProductAsync(EditProductModel model);
        Task ArchiveProductAsync(int productId);
        Task RestoreProductAsync(int productId);
        Task<int> CreateProductAsync(CreateProductModel model);
        Task SetProductToBeFeaturedByIdAsync(int productId);
        Task RemoveProductFromBeFeaturedProductsByIdAsync(int productId);
        Task<int> GetAllClothesCountAsync();
    }
}
