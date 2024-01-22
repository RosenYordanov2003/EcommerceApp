namespace EcommerceApp.Core.Services
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Contracts;
    using Data;
    using Models.Cart;
    using EcommerceApp.Infrastructure.Data.Models;

    public class ProductStockService : IProductStockService
    {
        private readonly ApplicationDbContext dbContext;
        public ProductStockService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> CheckForProductQuantityAsync(AddProductToCartModel addProductToCartModel)
        {
            if (addProductToCartModel.CategoryName.ToLower() == "shoes")
            {
                return await dbContext.ShoesStock.AnyAsync(sh => sh.ShoesId == addProductToCartModel.ProductId
                && sh.Size == int.Parse(addProductToCartModel.Size) && sh.Quantity >= addProductToCartModel.Quantity);
            }
            return await dbContext.ProductStocks.AnyAsync
                (ps => ps.ProductId == addProductToCartModel.ProductId
              && ps.Size == addProductToCartModel.Size && ps.Quantity >= addProductToCartModel.Quantity);
        }

        public async Task DecreaseProductStockQuantity(AddProductToCartModel addProductToCartModel)
        {
            if (addProductToCartModel.CategoryName.ToLower() == "shoes")
            {
                ShoesCartEntity shoesCartEntity = await dbContext.ShoesCartEntities.FirstAsync(sh => sh.ShoesId == addProductToCartModel.ProductId 
                && sh.Size == int.Parse(addProductToCartModel.Size));

                shoesCartEntity.Quantity -= addProductToCartModel.Quantity;
            }
            else
            {
                ProductCartEntity productCartEntity = await dbContext.ProductCartEntities.FirstAsync(pc => pc.Id == addProductToCartModel.ProductId
                && pc.Size == addProductToCartModel.Size);

                productCartEntity.Quantity -= addProductToCartModel.Quantity;
            }
            await dbContext.SaveChangesAsync();
        }

        public Task IncreaseProductStockQuantity(AddProductToCartModel addProductToCartModel)
        {
            throw new NotImplementedException();
        }
    }
}
