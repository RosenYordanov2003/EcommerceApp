namespace EcommerceApp.Infrastructure.Data.Configurations
{
    using EcommerceApp.Infrastructure.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    public class SubCategoryEntityConfiguration : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
           builder.HasMany(sc => sc.Clothes)
                .WithOne(sc => sc.SubCategory)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(sc => sc.Shoes)
                .WithOne(sh => sh.SubCategory)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(GenerateSubCategories());
                
        }

        private static IEnumerable<SubCategory> GenerateSubCategories()
        {
            return new List<SubCategory>()
           {
               new SubCategory()
               {
                   Id = 1,
                   Name = "Sports Shoes",
                   MainCategoryId = 9,
               },
               new SubCategory()
               {
                   Id = 2,
                   Name = "Sandals",
                   MainCategoryId = 9,
               },
               new SubCategory()
               {
                   Id = 3,
                   Name = "Trainers",
                   MainCategoryId = 9,
               },
               new SubCategory()
               {
                   Id = 4,
                   Name = "Football Boats",
                   MainCategoryId = 9,
               },
               new SubCategory()
               {
                   Id = 5,
                   Name = "Football Shirts",
                   MainCategoryId = 8
               },
               new SubCategory()
               {
                   Id = 6,
                   Name = "Long sleeve shirts",
                   MainCategoryId = 8,
               },
               new SubCategory()
               {
                   Id = 7,
                   Name = "Short sleeve shirts",
                   MainCategoryId = 8,
               },
               new SubCategory()
               {
                   Id = 8,
                   Name = "Dress Shirts",
                   MainCategoryId = 8
               },
               new SubCategory()
               {
                   Id = 9,
                   MainCategoryId = 7,
                   Name = "Swimming Shorts"
               },
               new SubCategory()
               {
                   Id = 10,
                   MainCategoryId = 7,
                   Name = "Football Shorts"
               },
               new SubCategory()
               {
                   Id = 11,
                   MainCategoryId = 7,
                   Name = "Cargo Shorts"
               },
               new SubCategory()
               {
                   Id = 12,
                   MainCategoryId = 7,
                   Name = "Bermuda Shorts"
               },
               new SubCategory()
               {
                   Id = 13,
                   MainCategoryId = 6,
                   Name = "Line Skirts"
               },
               new SubCategory()
               {
                   Id = 14,
                   MainCategoryId = 6,
                   Name = "Tube Skirts"
               },
               new SubCategory()
               {
                   Id = 15,
                   MainCategoryId = 6,
                   Name = "Cicle Skirts"
               },
               new SubCategory()
               {
                   Id = 16,
                   MainCategoryId = 4,
                   Name = "Wrap Coats"
               },
               new SubCategory()
               {
                   Id = 17,
                   MainCategoryId = 4,
                   Name = "Trench Coats"
               },
               new SubCategory()
               {
                   Id = 18,
                   MainCategoryId = 4,
                   Name = "Fur Coats"
               },
               new SubCategory()
               {
                   Id = 19,
                   MainCategoryId = 3,
                   Name = "Bomber Jackets"
               },
               new SubCategory()
               {
                   Id = 20,
                   MainCategoryId = 3,
                   Name = "Denim Jackets"
               },
               new SubCategory()
               {
                   Id = 21,
                   MainCategoryId = 3,
                   Name = "Biker Jackets"
               },
               new SubCategory()
               {
                   Id = 22,
                   MainCategoryId = 2,
                   Name = "Straight leg jeans"
               },
               new SubCategory()
               {
                   Id = 23,
                   MainCategoryId = 2,
                   Name = "Tapered jeans"
               },
               new SubCategory()
               {
                   Id = 24,
                   MainCategoryId = 1,
                   Name = "Polo T-Shirts"
               },
               new SubCategory()
               {
                   Id = 25,
                   MainCategoryId = 1,
                   Name = "Singlet T-shirts"
               },
               new SubCategory()
               {
                   Id = 26,
                   MainCategoryId = 1,
                   Name = "Pocket T-shirts"
               },
               new SubCategory()
               {
                   Id = 27,
                   MainCategoryId = 10,
                   Name = "Hooded Sweatshirts"
               },
               new SubCategory()
               {
                   Id = 28,
                   MainCategoryId = 10,
                   Name = "Sweatshirts without a hood"
               },
           };
        }
    }
}
