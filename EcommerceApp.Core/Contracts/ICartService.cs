namespace EcommerceApp.Core.Contracts
{
    using Models.Cart;
    public  interface ICartService
    {
        Task<CartModel>GetUserCartByUserIdAsync(Guid userId);
        Task AddProductToUserCartAsync(AddProductToCartModel addProductToCartModel);
        Task RemoveProductFromUserCartAsync(RemoveCartProductModel removeCartProductModel);
        Task IncreaseProductCartQuantityAsync (ModifyProductCartQuantityModel model);
        Task<bool> CheckICartProductsQuantityIsAvailableAsync(Guid userId);
        Task ClearUserCartAsyncAfterFinishingOrder(Guid userId);
        Task CreateUserCartAsync(Guid userId);
        Task DecreaseProductCartQuantityAsync(ModifyProductCartQuantityModel model);
    }
}
