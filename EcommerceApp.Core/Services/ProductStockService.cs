namespace EcommerceApp.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using Contracts;
    using Data;
    using Infrastructure.Data.Models;
    using EcommerceApp.Core.Models.AdminModels.ProductStock;

    public class ProductStockService : IProductStockService
    {
        private readonly ApplicationDbContext dbContext;
        public ProductStockService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> CheckForProductQuantityAsync(string categoryName, int productId, string size, int quantity)
        {
            if (categoryName.ToLower() == "shoes")
            {
                return await dbContext.ShoesStock.AnyAsync(sh => sh.ShoesId == productId
                && sh.Size == int.Parse(size) && sh.Quantity >= quantity);
            }
            return await dbContext.ProductStocks.AnyAsync
                (ps => ps.ProductId == productId
              && ps.Size == size && ps.Quantity >= quantity);
        }

        public async Task DecreaseProductStockQuantity(string categoryName, int productId, string size, int quantity)
        {
            if (categoryName.ToLower() == "shoes")
            {
                ShoesStock shoesCartEntity = await dbContext.ShoesStock.FirstAsync(sh => sh.ShoesId == productId 
                && sh.Size == int.Parse(size));

                shoesCartEntity.Quantity -= quantity;
            }
            else
            {
                ProductStock productCartEntity = await dbContext.ProductStocks.FirstAsync(pc => pc.ProductId == productId
                && pc.Size == size);

                productCartEntity.Quantity -= quantity;
            }
            await dbContext.SaveChangesAsync();
        }

        public async Task IncreaseProductStockQuantity(string categoryName, int productId, string size, int quantity)
        {
            if (categoryName.ToLower() == "shoes")
            {
                ShoesStock shoesCartEntity = await dbContext.ShoesStock.FirstAsync(sh => sh.ShoesId == productId
                && sh.Size == int.Parse(size));

                shoesCartEntity.Quantity += quantity;
            }
            else
            {
                ProductStock productCartEntity = await dbContext.ProductStocks.FirstAsync(pc => pc.ProductId == productId
                && pc.Size == size);

                productCartEntity.Quantity += quantity;
            }
            await dbContext.SaveChangesAsync();
        }
        public async Task IncreaseProductStockQuantity(AddProductStockModel productStockModel)
        {
            var stock = await dbContext.ProductStocks.FirstAsync(ps => ps.Id == productStockModel.ProductStockId);

            stock.Quantity += productStockModel.ProductQuantityToAdd;
            await dbContext.SaveChangesAsync();
        }
    }
}
