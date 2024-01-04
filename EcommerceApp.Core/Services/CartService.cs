namespace EcommerceApp.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using Contracts;
    using Models.Cart;
    public class CartService : ICartService
    {
        private readonly DbContext dbContext;
        public CartService(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<CartModel> GetUserCartByUserIdAsync(Guid userId)
        {
            return new CartModel();
        }
    }
}
