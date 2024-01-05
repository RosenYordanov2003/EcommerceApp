namespace EcommerceApp.Infrastructure.Data.Configurations
{
    using EcommerceApp.Infrastructure.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    public class ProductStockEntityConfiguration : IEntityTypeConfiguration<ProductStockEntityConfiguration>
    {
        private static string[] sizes = new string[] { "S", "M", "L", "XL", "XXL" };
        public void Configure(EntityTypeBuilder<ProductStockEntityConfiguration> builder)
        {
            builder.HasData(GenereateProductStocks());
        }

        private IEnumerable<ProductStock> GenereateProductStocks()
        {
            Random random = new Random();
            List<ProductStock> productStocks = new List<ProductStock>();
            for (int productId = 1; productId <= 12; productId++)
            {
                for (int productSize = 0; productSize < sizes.Length; productSize++)
                {
                    productStocks.Add(new ProductStock()
                    {
                        Id = productId,
                        ProductId = productId,
                        Size = sizes[productSize],
                        Quantity = random.Next(21)
                    });
                }
            }
            return productStocks;
        }
    }
}
