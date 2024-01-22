namespace EcommerceApp.Core.Contracts
{
    using Models.Cart;
    public interface IProductStockService
    {
        public Task<bool> CheckForProductQuantityAsync(AddProductToCartModel addProductToCartModel);
        public Task DecreaseProductStockQuantity(AddProductToCartModel addProductToCartModel);
        public Task IncreaseProductStockQuantity(AddProductToCartModel addProductToCartModel);
    }
}
