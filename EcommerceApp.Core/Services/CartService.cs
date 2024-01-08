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
            User user = await dbContext.Users.FirstAsync(u => u.Id == addProductToCartModel.UserId);
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
                userCart.ProductCartEntities.Add(new ProductCartEntity() { ProductId = addProductToCartModel.ProductId, CartId = userCart.Id, Quantity = addProductToCartModel.Quantity});
            }
            else
            {
                Shoes shoesToAdd = await dbContext.Shoes.FirstAsync(sh => sh.Id == addProductToCartModel.ProductId);
                userCart.ShoesCartEntities.Add(new ShoesCartEntity() { ShoesId = addProductToCartModel.ProductId, CartId = userCart.Id, Quantity = addProductToCartModel.Quantity });
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
                       CartProducts = uc.Cart.ProductCartEntities.Select(p => new ProductCartModel()
                       {
                           Id = p.Id,
                           CategoryName = p.Product.Category.Name,
                           ImgUrl = p.Product.Pictures.First().ImgUrl,
                           Name = p.Product.Name,
                           Price = p.Product.Price,
                           Quantity = p.Quantity
                       })
                       .ToArray(),
                       CartShoes = uc.Cart.ShoesCartEntities.Select(sh => new ProductCartModel()
                       {
                           Id = sh.Shoes.Id,
                           CategoryName = sh.Shoes.Category.Name,
                           ImgUrl = sh.Shoes.Pictures.First().ImgUrl,
                           Name = sh.Shoes.Name,
                           Price = sh.Shoes.Price,
                           Quantity = sh.Quantity
                       })
                       .ToArray()

                   })
                   .FirstOrDefaultAsync();

            return userCart;

        }
    }
}
