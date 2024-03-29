﻿namespace EcommerceApp.Infrastructure.Data.Configurations
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

            List<ShoesStock> shoesStocks = new List<ShoesStock>();
            int key = 7;
            for (int shoesId = 1; shoesId <= 16; shoesId++)
            {
                for (int shoesSize = 37; shoesSize <= 46; shoesSize++)
                {
                    shoesStocks.Add(new ShoesStock()
                    {
                        Id = key,
                        ShoesId = shoesId,
                        Quantity = 15,
                        Size = shoesSize
                    });
                    key++;
                }
            }
            return shoesStocks;
        }
    }
}
