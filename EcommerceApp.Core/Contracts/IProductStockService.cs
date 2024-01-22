namespace EcommerceApp.Core.Contracts
{
    using Models.Cart;
    public interface IProductStockService
    {
        public Task<bool> CheckForProductQuantityAsync(string categoryName, int productId, string size, int quantity);
        public Task DecreaseProductStockQuantity(string categoryName, int productId, string size, int quantity);
        public Task IncreaseProductStockQuantity(string categoryName, int productId, string size, int quantity);
    }
}
