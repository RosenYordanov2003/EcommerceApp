namespace EcommerceApp.Infrastructure.Data.Configurations
{
    using EcommerceApp.Infrastructure.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MainCategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasMany(c => c.Clothes)
                 .WithOne(cl => cl.Category)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(c => c.Shoes)
                .WithOne(sh => sh.Category)
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasData(GenerateCategories());
        }

        private static IEnumerable<Category> GenerateCategories()
        {
           return new List<Category>()
           {
               new Category()
               {
                   Id = 1,
                   Name = "T-Shirts",
                   Gender = "Unisex"
               },
               new Category()
               {
                   Id = 2,
                   Name = "Jeans",
                   Gender = "Unisex"
               },
               new Category()
               {
                   Id = 3,
                   Name = "Jackets",
                   Gender = "Unisex"
               },
               new Category()
               {
                   Id = 4,
                   Name = "Coats",
                   Gender = "Unisex"
               },
               new Category()
               {
                   Id = 5,
                   Name = "Trousers",
                   Gender = "Unisex"
               },
               new Category()
               {
                   Id = 6,
                   Name = "Skirts",
                   Gender = "Women"
               },
               new Category()
               {
                   Id = 7,
                   Name = "Shorts",
                   Gender = "Unisex"
               },
               new Category()
               {
                   Id = 8,
                   Name = "Shirts",
                   Gender = "Unisex"
               },
               new Category()
               {
                   Id = 9,
                   Name = "Shoes",
                   Gender = "Unisex"
               },
               new Category()
               {
                   Id = 10,
                   Name = "Sweatshirts",
                   Gender = "Unisex"
               },
           };
        }
    }
}
