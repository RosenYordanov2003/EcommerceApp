namespace EcommerceApp.Core.Contracts
{
    using Models.Cart;
    public  interface ICartService
    {
        Task<CartModel>GetUserCartByUserIdAsync(Guid userId);
    }
}
