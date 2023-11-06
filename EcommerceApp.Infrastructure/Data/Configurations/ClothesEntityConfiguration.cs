namespace EcommerceApp.Infrastructure.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
    using System;

    public class ClothesEntityConfiguration : IEntityTypeConfiguration<Clothes>
    {
        public void Configure(EntityTypeBuilder<Clothes> builder)
        {
            builder.HasData(GenerateClothes());
        }

        private IEnumerable<Clothes> GenerateClothes()
        {
            return new List<Clothes>()
            {
                new Clothes()
                {
                    Id = 1,
                    BrandId = 1,
                    Name = "Chicago Bulls Essential",
                    Description = "Men's Jordan NBA Long-Sleeve T-Shirt",
                    CategoryId = 1,
                    SubCategoryId = 6,
                    Gender = "M",
                    Color = "Gray",
                    Price = 40,
                    StarRating = 4
                },
                new Clothes()
                {
                    Id = 2,
                    BrandId = 1,
                    Name = "Chicago Bulls Essential",
                    Description = "Men's Jordan NBA Long-Sleeve T-Shirt",
                    CategoryId = 1,
                    SubCategoryId = 6,
                    Gender = "M",
                    Color = "Black",
                    Price = 40,
                    StarRating = 4
                },
                new Clothes()
                {
                    Id = 3,
                    BrandId = 1,
                    Name = "Nike Air x Marcus Rashford",
                    Price = 38,
                    StarRating = 5,
                    Color = "Black",
                    CategoryId = 1,
                    Gender = "M",
                    SubCategoryId = 7,
                    Description = "From the pitch to the streets, you can celebrate Marcus Rashford's passion for sport in comfort with this sweat-wicking tee. Soft fabric and a relaxed fit help keep you dry and comfortable, while retro branding and an \"MR\" logo add the perfect finishing touches."
                },
                new Clothes()
                {
                    Id = 4,
                    BrandId = 1,
                    Name = "Nike Air x Marcus Rashford",
                    Price = 38,
                    StarRating = 5,
                    Color = "White",
                    CategoryId = 1,
                    Gender = "M",
                    SubCategoryId = 7,
                    Description = "From the pitch to the streets, you can celebrate Marcus Rashford's passion for sport in comfort with this sweat-wicking tee. Soft fabric and a relaxed fit help keep you dry and comfortable, while retro branding and an \"MR\" logo add the perfect finishing touches."
                },
                new Clothes()
                {
                    Id = 5,
                    BrandId = 1,
                    Name = "Women's Long-Sleeve Top",
                    Price = 55,
                    StarRating = 5,
                    Color = "White",
                    CategoryId = 1,
                    Gender = "W",
                    SubCategoryId = 6,
                    Description = "Extra-soft, stretchy ribbed fabric helps make this slim-fitting top an everyday favourite. A mock neck and long sleeves offer a tailored look while the embroidered Swoosh logo and piping details add a touch of heritage style."
                },
                new Clothes()
                {
                    Id = 6,
                    BrandId = 1,
                    Name = "Women's Long-Sleeve Top",
                    Price = 55,
                    StarRating = 5,
                    Color = "Black",
                    CategoryId = 1,
                    Gender = "W",
                    SubCategoryId = 6,
                    IsFeatured = true,
                    Description = "Extra-soft, stretchy ribbed fabric helps make this slim-fitting top an everyday favourite. A mock neck and long sleeves offer a tailored look while the embroidered Swoosh logo and piping details add a touch of heritage style."
                },
                new Clothes()
                {
                    Id = 7,
                    BrandId = 1,
                    Name = "Nike Dri-FIT UV One Luxe",
                    Price = 40,
                    CategoryId = 1,
                    SubCategoryId = 7,
                    Gender = "W",
                    Color = "Wine Red",
                    Description = "The Nike Dri-FIT One Luxe Top is designed for all the ways you work out—from yoga to HIIT to long runs. As part of the Nike Luxe line, this top defines luxury with buttery-soft and smooth fabric that breathes to keep you dry and cool. It's made from at least 75% recycled polyester fibres."
                },
                new Clothes()
                {
                    Id = 8,
                    BrandId = 1,
                    CategoryId = 5,
                    Gender = "M",
                    Name = "Nike Sportswear Tech Fleece",
                    Color = "Midnight Black",
                    Price = 99,
                    StarRating = 5,
                    IsFeatured = true,
                    SubCategoryId = 5,
                    Description = "Ready for cooler weather, the Nike Sportswear Tech Fleece Joggers feature an updated fit perfect for everyday wear. Roomy through the thigh, this tapered design narrows at the knee to give you a comfortable feel without losing the clean, tailored look you love. Tall ribbed cuffs complete the jogger look while a zipped pocket on the right leg provides secure small-item storage and elevates the look."
                },
                new Clothes()
                {
                    Id = 9,
                    BrandId = 1,
                    CategoryId = 5,
                    Gender = "M",
                    Name = "Nike Sportswear Tech Fleece",
                    Color = "Red",
                    Price = 99,
                    StarRating = 5,
                    SubCategoryId = 5,
                    Description = "Ready for cooler weather, the Nike Sportswear Tech Fleece Joggers feature an updated fit perfect for everyday wear. Roomy through the thigh, this tapered design narrows at the knee to give you a comfortable feel without losing the clean, tailored look you love. Tall ribbed cuffs complete the jogger look while a zipped pocket on the right leg provides secure small-item storage and elevates the look."
                },
                new Clothes()
                {
                    Id = 10,
                    BrandId = 1,
                    CategoryId = 5,
                    Gender = "M",
                    Name = "Nike Sportswear Club Fleece",
                    Color = "Slate White",
                    Price = 60,
                    StarRating = 4,
                    SubCategoryId = 5,
                    Description = "A wardrobe staple, the Nike Sportswear Club Fleece Joggers combine a classic look with the soft comfort of fleece for an elevated, everyday look that you can wear every day."
                },
                new Clothes()
                {
                    Id = 11,
                    BrandId = 1,
                    CategoryId = 5,
                    SubCategoryId = 5,
                    Gender = "W",
                    Name = "Nike Sportswear Phoenix Fleece",
                    Color = "Pink",
                    Price = 65,
                    StarRating = 4,
                    Description = "Rise up and transform your fleece wardrobe with strong cosy vibes. These oversized Phoenix Fleece joggers have extra room in the legs for a fit that's comfy and relaxed. The taller ribbed waistline sits higher on your hips for a stay-put, snug feel and a bold look."
                },
                new Clothes()
                {
                    Id = 12,
                    BrandId = 1,
                    CategoryId = 5,
                    SubCategoryId = 5,
                    Gender = "W",
                    Name = "Nike Sportswear Phoenix Fleece",
                    Color = "Green",
                    Price = 65,
                    StarRating = 4,
                    IsFeatured = true,
                    Description = "Rise up and transform your fleece wardrobe with strong cosy vibes. These oversized Phoenix Fleece joggers have extra room in the legs for a fit that's comfy and relaxed. The taller ribbed waistline sits higher on your hips for a stay-put, snug feel and a bold look."
                }
            };
        }
    }
}
