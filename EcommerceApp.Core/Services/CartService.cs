namespace EcommerceApp.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using Contracts;
    using Models.Cart;
    using EcommerceApp.Data;
    using EcommerceApp.Core.Models.Products;
    using EcommerceApp.Infrastructure.Data.Models;

    public class CartService : ICartService
    {
        private readonly ApplicationDbContext dbContext;
        public CartService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddProductToUserCartAsync(AddProductToCartModel addProductToCartModel)
        {
            User user =  await dbContext.Users.FirstAsync(u => u.Id == addProductToCartModel.UserId);
            if (user.CartId == null)
            {
                Cart cart = new Cart();
                user.Cart = cart;
                await dbContext.SaveChangesAsync();
            }
            Cart userCart = await dbContext.Carts.Where(c => c.Id == user.CartId).FirstAsync();
            if (addProductToCartModel.CategoryName.ToLower() != "shoes")
            {
                Product productToAdd = await dbContext.Clothes.FirstAsync(p => p.Id == addProductToCartModel.ProductId);
                userCart.ProductStocks.Add(productToAdd);
            }
            else
            {
                Shoes shoesToAdd = await dbContext.Shoes.FirstAsync(sh => sh.Id == addProductToCartModel.ProductId);
                userCart.ShoesStocks.Add(shoesToAdd);
            }
            await dbContext.SaveChangesAsync();
        }

        public async Task<CartModel> GetUserCartByUserIdAsync(Guid userId)
        {
            CartModel? userCart = await dbContext.Users
                   .Where(u => u.Id == userId)
                   .Select(uc => new CartModel()
                   {
                       CartId = uc.CartId,
                       CartProducts = uc.Cart.ProductStocks.Select(p => new ProductCartModel()
                       {
                           Id = p.Id,
                           CategoryName = p.Category.Name,
                           ImgUrl = p.Pictures.First().ImgUrl,
                           Name = p.Name,
                           Price = p.Price
                       })
                       .ToArray(),
                       CartShoes = uc.Cart.ShoesStocks.Select(p => new ProductCartModel()
                       {
                           Id = p.Id,
                           CategoryName = p.Category.Name,
                           ImgUrl = p.Pictures.First().ImgUrl,
                           Name = p.Name,
                           Price = p.Price
                       })
                       .ToArray()

                   })
                   .FirstOrDefaultAsync();

            return userCart;
        }
    }
}
