namespace EcommerceApp.Infrastructure.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasMany(p => p.ProductCartEntities)
                .WithOne(ce => ce.Product)
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasMany(p => p.Reviews)
                .WithOne(r => r.Product)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(p => p.ProductStocks)
                .WithOne(p => p.Product)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasData(GenerateClothes());
        }

        private IEnumerable<Product> GenerateClothes()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    BrandId = 1,
                    Name = "Chicago Bulls Essential",
                    Description = "Men's Jordan NBA Long-Sleeve T-Shirt",
                    CategoryId = 1,
                    Gender = "Men",
                    Price = 40,
                    StarRating = 4
                },
                new Product()
                {
                    Id = 2,
                    BrandId = 1,
                    Name = "Chicago Bulls Essential",
                    Description = "Men's Jordan NBA Long-Sleeve T-Shirt",
                    CategoryId = 1,
                    Gender = "Men",
                    Price = 40,
                    StarRating = 4
                },
                new Product()
                {
                    Id = 3,
                    BrandId = 1,
                    Name = "Nike Air x Marcus Rashford",
                    Price = 38,
                    StarRating = 5,
                    CategoryId = 1,
                    Gender = "Men",
                    Description = "From the pitch to the streets, you can celebrate Marcus Rashford's passion for sport in comfort with this sweat-wicking tee. Soft fabric and a relaxed fit help keep you dry and comfortable, while retro branding and an \"MR\" logo add the perfect finishing touches."
                },
                new Product()
                {
                    Id = 4,
                    BrandId = 1,
                    Name = "Nike Air x Marcus Rashford",
                    Price = 38,
                    StarRating = 5,
                    CategoryId = 1,
                    Gender = "Men",
                    Description = "From the pitch to the streets, you can celebrate Marcus Rashford's passion for sport in comfort with this sweat-wicking tee. Soft fabric and a relaxed fit help keep you dry and comfortable, while retro branding and an \"MR\" logo add the perfect finishing touches."
                },
                new Product()
                {
                    Id = 5,
                    BrandId = 1,
                    Name = "Women's Long-Sleeve Top",
                    Price = 55,
                    StarRating = 5,
                    CategoryId = 1,
                    Gender = "Women",
                    Description = "Extra-soft, stretchy ribbed fabric helps make this slim-fitting top an everyday favourite. A mock neck and long sleeves offer a tailored look while the embroidered Swoosh logo and piping details add a touch of heritage style."
                },
                new Product()
                {
                    Id = 6,
                    BrandId = 1,
                    Name = "Women's Long-Sleeve Top",
                    Price = 55,
                    StarRating = 5,
                    CategoryId = 1,
                    Gender = "Women",
                    IsFeatured = true,
                    Description = "Extra-soft, stretchy ribbed fabric helps make this slim-fitting top an everyday favourite. A mock neck and long sleeves offer a tailored look while the embroidered Swoosh logo and piping details add a touch of heritage style."
                },
                new Product()
                {
                    Id = 7,
                    BrandId = 1,
                    Name = "Nike Dri-FIT UV One Luxe",
                    Price = 40,
                    CategoryId = 1,
                    Gender = "Women",
                    Description = "The Nike Dri-FIT One Luxe Top is designed for all the ways you work out—from yoga to HIIT to long runs. As part of the Nike Luxe line, this top defines luxury with buttery-soft and smooth fabric that breathes to keep you dry and cool. It's made from at least 75% recycled polyester fibres."
                },
                new Product()
                {
                    Id = 8,
                    BrandId = 1,
                    CategoryId = 5,
                    Gender = "Men",
                    Name = "Nike Sportswear Tech Fleece",
                    Price = 99,
                    StarRating = 5,
                    IsFeatured = true,
                    Description = "Ready for cooler weather, the Nike Sportswear Tech Fleece Joggers feature an updated fit perfect for everyday wear. Roomy through the thigh, this tapered design narrows at the knee to give you a comfortable feel without losing the clean, tailored look you love. Tall ribbed cuffs complete the jogger look while a zipped pocket on the right leg provides secure small-item storage and elevates the look."
                },
                new Product()
                {
                    Id = 9,
                    BrandId = 1,
                    CategoryId = 5,
                    Gender = "Men",
                    Name = "Nike Sportswear Tech Fleece",
                    Price = 99,
                    StarRating = 5,
                    Description = "Ready for cooler weather, the Nike Sportswear Tech Fleece Joggers feature an updated fit perfect for everyday wear. Roomy through the thigh, this tapered design narrows at the knee to give you a comfortable feel without losing the clean, tailored look you love. Tall ribbed cuffs complete the jogger look while a zipped pocket on the right leg provides secure small-item storage and elevates the look."
                },
                new Product()
                {
                    Id = 10,
                    BrandId = 1,
                    CategoryId = 5,
                    Gender = "Men",
                    Name = "Nike Sportswear Club Fleece",
                    Price = 60,
                    StarRating = 4,
                    Description = "A wardrobe staple, the Nike Sportswear Club Fleece Joggers combine a classic look with the soft comfort of fleece for an elevated, everyday look that you can wear every day."
                },
                new Product()
                {
                    Id = 11,
                    BrandId = 1,
                    CategoryId = 5,
                    Gender = "Women",
                    Name = "Nike Sportswear Phoenix Fleece",
                    Price = 65,
                    StarRating = 4,
                    Description = "Rise up and transform your fleece wardrobe with strong cosy vibes. These oversized Phoenix Fleece joggers have extra room in the legs for a fit that's comfy and relaxed. The taller ribbed waistline sits higher on your hips for a stay-put, snug feel and a bold look."
                },
                new Product()
                {
                    Id = 12,
                    BrandId = 1,
                    CategoryId = 5,
                    Gender = "Women",
                    Name = "Nike Sportswear Phoenix Fleece",
                    Price = 65,
                    StarRating = 4,
                    IsFeatured = true,
                    Description = "Rise up and transform your fleece wardrobe with strong cosy vibes. These oversized Phoenix Fleece joggers have extra room in the legs for a fit that's comfy and relaxed. The taller ribbed waistline sits higher on your hips for a stay-put, snug feel and a bold look."
                }
            };
        }
    }
}
