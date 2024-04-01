namespace EcommerceApp.Core.Contracts
{
    using Models.Cart;
    public  interface ICartService
    {
        Task<CartModel>GetUserCartByUserIdAsync(Guid userId);
        Task AddProductToUserCartAsync(CartProductModel addProductToCartModel);
        Task RemoveProductFromUserCartAsync(CartProductModel removeCartProductModel);
        Task IncreaseProductCartQuantityAsync (ModifyProductCartQuantityModel model);
        Task<bool> CheckICartProductsQuantityIsAvailableAsync(Guid userId);
        Task ClearUserCartAsyncAfterFinishingOrder(Guid userId);
        Task CreateUserCartAsync(Guid userId);
        Task DecreaseProductCartQuantityAsync(ModifyProductCartQuantityModel model);
    }
}
