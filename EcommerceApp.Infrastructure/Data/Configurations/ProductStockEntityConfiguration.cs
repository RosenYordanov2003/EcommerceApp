namespace EcommerceApp.Infrastructure.Data.Configurations
{
    using EcommerceApp.Infrastructure.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    public class ProductStockEntityConfiguration : IEntityTypeConfiguration<ProductStock>
    {
        private static string[] sizes = new string[] { "S", "M", "L", "XL", "XXL" };

        public void Configure(EntityTypeBuilder<ProductStock> builder)
        {
            builder.HasData(GenereateProductStocks());
        }

        private IEnumerable<ProductStock> GenereateProductStocks()
        {
            Random random = new Random();
            List<ProductStock> productStocks = new List<ProductStock>();
            int key = 1;
            for (int productId = 1; productId <= 12; productId++)
            {
                for (int productSize = 0; productSize < sizes.Length; productSize++)
                {
                    productStocks.Add(new ProductStock()
                    {
                        Id = key,
                        ProductId = productId,
                        Size = sizes[productSize],
                        Quantity = random.Next(21)
                    });
                    key++;
                }
            }
            return productStocks;
        }
    }
}
