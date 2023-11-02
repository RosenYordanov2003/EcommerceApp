namespace EcommerceApp.Infrastructure.Data.Configurations
{
    using EcommerceApp.Infrastructure.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MainCategoryEntityConfiguration : IEntityTypeConfiguration<MainCategory>
    {
        public void Configure(EntityTypeBuilder<MainCategory> builder)
        {
            builder.HasMany(c => c.Clothes)
                 .WithOne(cl => cl.Category)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(c => c.Shoes)
                .WithOne(sh => sh.Category)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(mc => mc.SubCategories)
                .WithOne(sc => sc.MainCategory)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(GenerateCategories());
        }

        private static IEnumerable<MainCategory> GenerateCategories()
        {
           return new List<MainCategory>()
           {
               new MainCategory()
               {
                   Id = 1,
                   Name = "T-Shirts",
                   Gender = "W M"
               },
               new MainCategory()
               {
                   Id = 2,
                   Name = "Jeans",
                   Gender = "W M"
               },
               new MainCategory()
               {
                   Id = 3,
                   Name = "Jackets",
                   Gender = "W M"
               },
               new MainCategory()
               {
                   Id = 4,
                   Name = "Coats",
                   Gender = "W M"
               },
               new MainCategory()
               {
                   Id = 5,
                   Name = "Trousers",
                   Gender = "W М"
               },
               new MainCategory()
               {
                   Id = 6,
                   Name = "Skirts",
                   Gender = "W"
               },
               new MainCategory()
               {
                   Id = 7,
                   Name = "Shorts",
                   Gender = "W M"
               },
               new MainCategory()
               {
                   Id = 8,
                   Name = "Shirts",
                   Gender = "W M"
               },
               new MainCategory()
               {
                   Id = 9,
                   Name = "Shoes",
                   Gender = "W M"
               },
               new MainCategory()
               {
                   Id = 10,
                   Name = "Sweatshirts",
                   Gender = "W M"
               },
           };
        }
    }
}
