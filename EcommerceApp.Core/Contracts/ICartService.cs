namespace EcommerceApp.Core.Contracts
{
    using Models.Cart;
    public  interface ICartService
    {
        Task<CartModel>GetUserCartByUserIdAsync(Guid userId);
        Task AddProductToUserCartAsync(AddProductToCartModel addProductToCartModel);
        Task RemoveProductFromUserCartAsync(RemoveCartProductModel removeCartProductModel);
        Task IncreaseProductQuantityAsync (ModifyProductCartQuantityModel increaseProductQuantityModel);
        Task<bool> CheckICartProductsQuantityIsAvailableAsync(Guid userId);
        Task ClearUserCartAsyncAfterFinishingOrder(Guid userId);
    }
}
