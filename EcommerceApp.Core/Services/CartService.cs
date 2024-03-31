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
            Cart userCart = await dbContext.Carts.Include(c => c.ProductCartEntities).Include(c => c.ShoesCartEntities)
                .Where(c => c.UserId == addProductToCartModel.UserId).FirstAsync();
            if (addProductToCartModel.CategoryName.ToLower() != "shoes")
            {
                Product productToAdd = await dbContext.Clothes.FirstAsync(p => p.Id == addProductToCartModel.ProductId);
                if (await CheckIfProductCartModelAlreadyExists(addProductToCartModel.ProductId, addProductToCartModel.CategoryName, userCart.Id, addProductToCartModel.Size))
                {
                    ProductCartEntity entity = await dbContext.ProductCartEntities
                        .FirstAsync(p => p.CartId == userCart.Id && p.ProductId == addProductToCartModel.ProductId && p.Size == addProductToCartModel.Size);
                    entity.Quantity += addProductToCartModel.Quantity;
                }
                else
                {
                    userCart.ProductCartEntities.Add(new ProductCartEntity()
                    { ProductId = addProductToCartModel.ProductId, CartId = userCart.Id, Quantity = addProductToCartModel.Quantity, Size = addProductToCartModel.Size });
                }

            }
            else
            {
                if (await CheckIfProductCartModelAlreadyExists(addProductToCartModel.ProductId, addProductToCartModel.CategoryName, userCart.Id, addProductToCartModel.Size))
                {
                    ShoesCartEntity entity = await dbContext.ShoesCartEntities
                        .FirstAsync(sh => sh.CartId == userCart.Id && sh.ShoesId == addProductToCartModel.ProductId && sh.Size.ToString() == addProductToCartModel.Size);
                    entity.Quantity += addProductToCartModel.Quantity;
                }
                else
                {
                    Shoes shoesToAdd = await dbContext.Shoes.FirstAsync(sh => sh.Id == addProductToCartModel.ProductId);
                    userCart.ShoesCartEntities.Add(new ShoesCartEntity()
                    { ShoesId = addProductToCartModel.ProductId, CartId = userCart.Id, Quantity = addProductToCartModel.Quantity, Size = int.Parse(addProductToCartModel.Size) });
                }
            }
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> CheckICartProductsQuantityIsAvailableAsync(Guid userId)
        {

            Cart userCart = await dbContext.Carts.Include(c => c.ProductCartEntities).Include(c => c.ShoesCartEntities).Where(c => c.UserId == userId).FirstAsync();

            foreach (ProductCartEntity product in userCart.ProductCartEntities)
            {
                ProductStock productStock = await dbContext.ProductStocks.FirstOrDefaultAsync(p => p.ProductId == product.ProductId && p.Quantity >= product.Quantity);

                if (productStock == null)
                {
                    return false;
                }
                productStock.Quantity -= product.Quantity;
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

            Cart userCart = await dbContext.Carts
                .Include(c => c.ProductCartEntities)
                .Include(c => c.ShoesCartEntities)
                .Where(c => c.UserId == userId).FirstAsync();

            userCart.ShoesCartEntities.Clear();
            userCart.ProductCartEntities.Clear();

            await dbContext.SaveChangesAsync();

            var productCartEntites = await dbContext.ProductCartEntities.Where(p => p.CartId == userCart.Id).ToArrayAsync();
            var shoesCartEntites = await dbContext.ShoesCartEntities.Where(p => p.CartId == userCart.Id).ToArrayAsync();

            foreach (var item in productCartEntites)
            {
                dbContext.ProductCartEntities.Remove(item);
            }
            foreach (var item in shoesCartEntites)
            {
                dbContext.ShoesCartEntities.Remove(item);
            }
            await dbContext.SaveChangesAsync();
        }

        public async Task CreateUserCartAsync(Guid userId)
        {
            if (!await CheckIfUserCartExistAsync(userId))
            {
                Cart userCart = new Cart()
                {
                    UserId = userId,
                };
                await dbContext.Carts.AddAsync(userCart);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task DecreaseProductCartQuantityAsync(ModifyProductCartQuantityModel model)
        {
            Cart userCart = await dbContext.Carts.Include(c => c.ProductCartEntities).Include(c => c.ShoesCartEntities).Where(c => c.UserId == model.UserId)
               .FirstAsync();

            if (model.ProductCategoryName.ToLower() != "shoes")
            {
                ProductCartEntity productToModify = await dbContext.ProductCartEntities.FirstAsync(p => p.ProductId == model.ProductId &&
                p.CartId == userCart.Id && p.Size == model.Size);

                productToModify.Quantity--;

            }
            else
            {
                ShoesCartEntity productToModify = await dbContext.ShoesCartEntities.FirstAsync(sh => sh.ShoesId == model.ProductId &&
                sh.CartId == userCart.Id && sh.Size == int.Parse(model.Size));
                productToModify.Quantity--;
            }
            await dbContext.SaveChangesAsync();
        }

        public async Task<CartModel> GetUserCartByUserIdAsync(Guid userId)
        {
            CartModel userCart = await dbContext.Carts
                   .Where(c => c.UserId == userId)
                   .Select(uc => new CartModel()
                   {
                       CartId = uc.Id,
                       CartProducts = uc.ProductCartEntities.Select(p => new ProductCartModel()
                       {
                           Id = p.ProductId,
                           CategoryName = p.Product.Category.Name,
                           ImgUrl = p.Product.Pictures.First().ImgUrl,
                           Name = p.Product.Name,
                           Price = p.Product.Promotion != null && p.Product.Promotion.ExpireTime >= DateTime.UtcNow ? p.Product.Price - (p.Product.Price * p.Product.Promotion.PercantageDiscount) / 100 : p.Product.Price,
                           Quantity = p.Quantity,
                           Size = p.Size,
                       })
                       .ToArray(),
                       CartShoes = uc.ShoesCartEntities.Select(sh => new ProductCartModel()
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
                   .FirstAsync();

            return userCart;

        }

        public async Task IncreaseProductCartQuantityAsync(ModifyProductCartQuantityModel model)
        {

            Cart userCart = await dbContext.Carts.Include(c => c.ProductCartEntities).Include(c => c.ShoesCartEntities).Where(c => c.UserId == model.UserId)
                .FirstAsync();

            if (model.ProductCategoryName.ToLower() != "shoes")
            {
                ProductCartEntity productToModify = await dbContext.ProductCartEntities.FirstAsync(p => p.CartId == userCart.Id && p.ProductId == model.ProductId);
                productToModify.Quantity++;
            }
            else
            {
                ShoesCartEntity productToModify = await dbContext.ShoesCartEntities.FirstAsync(sh => sh.CartId == userCart.Id && sh.ShoesId == model.ProductId);
                productToModify.Quantity++;
            }
            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveProductFromUserCartAsync(RemoveCartProductModel removeCartProductModel)
        {
            Cart userCart = await dbContext.Carts.Include(c => c.ShoesCartEntities).Include(c => c.ProductCartEntities).Where(c => c.UserId == removeCartProductModel.UserId).FirstAsync();

            if (removeCartProductModel.CategoryName.ToLower() == "shoes")
            {
                ShoesCartEntity productCartEntity = await dbContext.ShoesCartEntities.FirstAsync(pc => pc.CartId == userCart.Id && pc.ShoesId == removeCartProductModel.ProductId
             && pc.Size == int.Parse(removeCartProductModel.Size));

                userCart.ShoesCartEntities.Remove(productCartEntity);
            }
            else
            {
                ProductCartEntity productCartEntity = await dbContext.ProductCartEntities.FirstAsync(pc => pc.CartId == userCart.Id && pc.ProductId == removeCartProductModel.ProductId
              && pc.Size == removeCartProductModel.Size);

                userCart.ProductCartEntities.Remove(productCartEntity);

            }
            await dbContext.SaveChangesAsync();
        }
        private async Task<bool> CheckIfUserCartExistAsync(Guid userId)
        {
            return await dbContext.Carts.AnyAsync(c => c.UserId == userId);
        }
        private async Task<bool> CheckIfProductCartModelAlreadyExists(int productId, string categoryName, Guid userCartId, string size)
        {
            if (categoryName.ToLower() == "shoes")
            {
                return await dbContext.ShoesCartEntities.AnyAsync(sh => sh.ShoesId == productId && sh.CartId == userCartId && sh.Size.ToString() == size);
            }
            return await dbContext.ProductCartEntities.AnyAsync(p => p.ProductId == productId && p.CartId == userCartId && p.Size == size);
        }
    }
}
