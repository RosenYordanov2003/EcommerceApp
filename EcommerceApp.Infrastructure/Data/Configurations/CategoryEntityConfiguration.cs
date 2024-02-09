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
                   Gender = "W M"
               },
               new Category()
               {
                   Id = 2,
                   Name = "Jeans",
                   Gender = "W M"
               },
               new Category()
               {
                   Id = 3,
                   Name = "Jackets",
                   Gender = "W M"
               },
               new Category()
               {
                   Id = 4,
                   Name = "Coats",
                   Gender = "W M"
               },
               new Category()
               {
                   Id = 5,
                   Name = "Trousers",
                   Gender = "W М"
               },
               new Category()
               {
                   Id = 6,
                   Name = "Skirts",
                   Gender = "W"
               },
               new Category()
               {
                   Id = 7,
                   Name = "Shorts",
                   Gender = "W M"
               },
               new Category()
               {
                   Id = 8,
                   Name = "Shirts",
                   Gender = "W M"
               },
               new Category()
               {
                   Id = 9,
                   Name = "Shoes",
                   Gender = "W M"
               },
               new Category()
               {
                   Id = 10,
                   Name = "Sweatshirts",
                   Gender = "W M"
               },
           };
        }
    }
}
