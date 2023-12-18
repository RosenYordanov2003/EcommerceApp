namespace EcommerceApp.Infrastructure.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Infrastructure.Data.Models;
    using System;

    public class ShoesStockEntityConfiguration : IEntityTypeConfiguration<ShoesStock>
    {
        public void Configure(EntityTypeBuilder<ShoesStock> builder)
        {
            builder.HasData(GenerateProductStock());
        }

        private IEnumerable<ShoesStock> GenerateProductStock()
        {
           return new List<ShoesStock>()
           {
               new ShoesStock()
               {
                   Id = 1,
                   ShoesId = 2,
                   Quantity = 3,
                   Size = 40
               },
               new ShoesStock()
               {
                   Id = 2,
                   ShoesId = 2,
                   Quantity = 6,
                   Size = 41
               },
               new ShoesStock()
               {
                   Id = 3,
                   ShoesId = 2,
                   Quantity = 7,
                   Size = 43
               },
               new ShoesStock()
               {
                   Id = 4,
                   ShoesId = 2,
                   Quantity = 8,
                   Size = 44
               },
               new ShoesStock()
               {
                   Id = 5,
                   ShoesId = 2,
                   Quantity = 18,
                   Size = 45
               },
           };
        }
    }
}
