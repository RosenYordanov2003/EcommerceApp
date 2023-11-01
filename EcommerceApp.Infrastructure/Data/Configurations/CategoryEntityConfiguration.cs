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
               },
               new MainCategory()
               {
                   Id = 2,
                   Name = "Jeans",
               },
               new MainCategory()
               {
                   Id = 3,
                   Name = "Jackets",
               },
               new MainCategory()
               {
                   Id = 4,
                   Name = "Coats",
               },
               new MainCategory()
               {
                   Id = 5,
                   Name = "Trousers",
               },
               new MainCategory()
               {
                   Id = 6,
                   Name = "Skirts"
               },
               new MainCategory()
               {
                   Id = 7,
                   Name = "Shorts"
               },
               new MainCategory()
               {
                   Id = 8,
                   Name = "Shirts"
               },
               new MainCategory()
               {
                   Id = 9,
                   Name = "Shoes"
               },
               new MainCategory()
               {
                   Id = 10,
                   Name = "Sweatshirts"
               },
           };
        }
    }
}
