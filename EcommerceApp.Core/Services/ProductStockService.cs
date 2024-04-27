namespace EcommerceApp.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using Contracts;
    using Data;
    using Infrastructure.Data.Models;
    using Models.AdminModels.ProductStock;
    using static Common.GeneralApplicationConstants;

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
            if (productStockModel.ProductCategory.ToLower() != "shoes")
            {
                var stock = await dbContext.ProductStocks.FirstAsync(ps => ps.Id == productStockModel.ProductStockId);

                stock.Quantity += productStockModel.Quantity;
            }
            else
            {
                var stock = await dbContext.ShoesStock.FirstAsync(s => s.Id == productStockModel.ProductStockId);

                stock.Quantity += productStockModel.Quantity;
            }

            await dbContext.SaveChangesAsync();
        }

        public async Task AddDefaultQuantity(int productId, string category)
        {
            if (category.ToLower() == "shoes")
            {
                List<ShoesStock> shoesStocks = new List<ShoesStock>();

                foreach (double size in ShoesSizes)
                {
                    shoesStocks.Add(new ShoesStock() { ShoesId = productId, Quantity = DefaultProductQuantityToAdd, Size = size });
                }
                await dbContext.ShoesStock.AddRangeAsync(shoesStocks);
            }
            else
            {
                List<ProductStock> productStocks = new List<ProductStock>();
                foreach (string size in ProductSizes)
                {
                    productStocks.Add(new ProductStock() { ProductId = productId, Quantity = DefaultProductQuantityToAdd, Size = size });
                }
                await dbContext.ProductStocks.AddRangeAsync(productStocks);
            }
            await dbContext.SaveChangesAsync();
        }
    }
}
