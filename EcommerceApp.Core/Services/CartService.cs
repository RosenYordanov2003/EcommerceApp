namespace EcommerceApp.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using Contracts;
    using Models.Cart;
    using Data;
    using Models.Products;
    using Infrastructure.Data.Models;

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
                userCart.ProductCartEntities.Add(new ProductCartEntity() { ProductId = addProductToCartModel.ProductId, CartId = userCart.Id, Quantity = addProductToCartModel.Quantity, Size = addProductToCartModel.Size});
            }
            else
            {
                Shoes shoesToAdd = await dbContext.Shoes.FirstAsync(sh => sh.Id == addProductToCartModel.ProductId);
                userCart.ShoesCartEntities.Add(new ShoesCartEntity() { ShoesId = addProductToCartModel.ProductId, CartId = userCart.Id, Quantity = addProductToCartModel.Quantity, Size = int.Parse(addProductToCartModel.Size) });
            }
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> CheckICartProductsQuantityIsAvailableAsync(Guid userId)
        {
            User user = await dbContext.Users.FirstAsync(u => u.Id == userId);

            Cart userCart = await dbContext.Carts.Include(c => c.ProductCartEntities).Include(c => c.ShoesCartEntities).Where(c => c.Id == user.CartId).FirstAsync();

            foreach (ProductCartEntity product in userCart.ProductCartEntities)
            {
                ProductStock productStock = await dbContext.ProductStocks.FirstOrDefaultAsync(p => p.ProductId == product.Id && p.Quantity >= product.Quantity);

                if (productStock == null)
                {
                    return false;
                }
                productStock.Quantity-= product.Quantity;
            }

            foreach (ShoesCartEntity shoes in userCart.ShoesCartEntities)
            {
                ShoesStock shoesStock = await dbContext.ShoesStock.FirstOrDefaultAsync(sh => sh.ShoesId == shoes.ShoesId && sh.Quantity >= sh.Quantity && sh.Size == shoes.Size);

                if (shoesStock == null)
                {
                    return false;
                }
                shoesStock.Quantity -= shoes.Quantity;
            }

            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task ClearUserCartAsyncAfterFinishingOrder(Guid userId)
        {
            User user = await dbContext.Users.FirstAsync(u => u.Id == userId);

            Cart userCart = await dbContext.Carts.Include(c => c.ProductCartEntities).Include(c => c.ShoesCartEntities).Where(c => c.Id == user.CartId).FirstAsync();

            userCart.ShoesCartEntities.Clear();
            userCart.ProductCartEntities.Clear();

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
                           Quantity = p.Quantity,
                           Size = p.Size,
                       })
                       .ToArray(),
                       CartShoes = uc.Cart.ShoesCartEntities.Select(sh => new ProductCartModel()
                       {
                           Id = sh.Shoes.Id,
                           CategoryName = sh.Shoes.Category.Name,
                           ImgUrl = sh.Shoes.Pictures.First().ImgUrl,
                           Name = sh.Shoes.Name,
                           Price = sh.Shoes.Price,
                           Quantity = sh.Quantity,
                           Size = sh.Size.ToString()
                       })
                       .ToArray()

                   })
                   .FirstOrDefaultAsync();

            return userCart;

        }

        public async Task IncreaseProductQuantityAsync(ModifyProductCartQuantityModel modifyProductCartQuantityModel)
        {
            User user = await dbContext.Users.FirstAsync(u => u.Id == modifyProductCartQuantityModel.UserId);

            Cart userCart = await dbContext.Carts.Include(c => c.ProductCartEntities).Include(c => c.ShoesCartEntities).Where(c => c.Id == user.CartId).FirstAsync();

            if (modifyProductCartQuantityModel.ProductCategoryName.ToLower() != "shoes")
            {
                ProductCartEntity productToModify = userCart.ProductCartEntities.FirstOrDefault(p => p.ProductId == modifyProductCartQuantityModel.ProductId);
                if (modifyProductCartQuantityModel.Operation == "increase")
                {
                    productToModify.Quantity++;
                }
                else
                {
                    productToModify.Quantity --;
                }
            }
            else
            {
                ShoesCartEntity productToModify = userCart.ShoesCartEntities.FirstOrDefault(sh => sh.ShoesId == modifyProductCartQuantityModel.ProductId);
                if (modifyProductCartQuantityModel.Operation == "increase")
                {
                    productToModify.Quantity++;
                }
                else
                {
                    productToModify.Quantity--;
                }
            }
            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveProductFromUserCartAsync(RemoveCartProductModel removeCartProductModel)
        {

            User user = await dbContext.Users.FirstAsync(u => u.Id == removeCartProductModel.UserId);

            Cart userCart = await dbContext.Carts.Include(c => c.ShoesCartEntities).Include(c => c.ProductCartEntities).Where(c => c.Id == user.CartId).FirstAsync();

            if (removeCartProductModel.CategoryName.ToLower() == "shoes")
            {
                userCart.ShoesCartEntities = userCart.ShoesCartEntities.Where(sh => sh.ShoesId != removeCartProductModel.ProductId).ToList();
            }
            else
            {
                userCart.ProductCartEntities = userCart.ProductCartEntities.Where(pc => pc.ProductId != removeCartProductModel.ProductId).ToList();
            }
            await dbContext.SaveChangesAsync();
        }
    }
}
