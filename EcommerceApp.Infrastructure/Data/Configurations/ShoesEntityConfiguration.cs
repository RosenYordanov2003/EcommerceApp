namespace EcommerceApp.Infrastructure.Data.Configurations
{
    using EcommerceApp.Infrastructure.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ShoesEntityConfiguration : IEntityTypeConfiguration<Shoes>
    {
        public void Configure(EntityTypeBuilder<Shoes> builder)
        {
            builder.HasMany(s => s.Pictures)
                 .WithOne(p => p.Shoes)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(GenerateShoes());
        }

        private IEnumerable<Shoes> GenerateShoes()
        {
            return new List<Shoes>()
            {
                new Shoes()
                {
                    Id = 1,
                    Name = "Nike Air Force 1 '07 LV8",
                    StarRating = 5,
                    CategoryId = 9,
                    Color = "Black",
                    BrandId = 1,
                    Price = 130,
                    SubCategoryId = 3,
                    Gender = "Men",
                    Description = "The radiance lives on in the Nike Air Force 1 '07 LV8. Crossing hardwood comfort with off-court flair, these kicks put a fresh spin on a hoops classic. Soft suede overlays pair with era-echoing '80s construction and reflective-design Swoosh logos to bring you nothing-but-net style while hidden full-length Air units add the legendary comfort you know and love."
                },
                new Shoes()
                {
                    Id = 2,
                    Name = "Nike Mercurial Vapor 15 Pro",
                    StarRating= 5,
                    CategoryId = 9,
                    SubCategoryId = 4,
                    Price = 160,
                    Color = "White",
                    BrandId = 1,
                    Gender = "Men",
                    Description = "The pitch is yours when you lace up in the Vapor 15 Pro AG-Pro. It's loaded with a Zoom Air unit, so you can dominate in the waning minutes of a match—when it matters most. Fast is in the Air."
                },
                new Shoes()
                {
                    Id = 3,
                    Name = "Nike Mercurial Superfly 9 Elite",
                    StarRating= 5,
                    CategoryId = 9,
                    SubCategoryId = 4,
                    Price = 250,
                    Color = "Black",
                    Gender = "Men",
                    BrandId = 1,
                    Description = "Instantly tilt the pitch in the bold design of the Superfly 9 Elite SG-Pro. We added a Zoom Air unit, made specifically for football, and grippy texture up top for exceptional touch, so you can dominate in the waning minutes of a match—when it matters most. Feel the explosive speed as you race around the pitch, making the critical plays with velocity and pace. Fast is in the Air. This version has Anti-Clog Traction on the soleplate, which helps prevent mud from sticking."
                },
                new Shoes()
                {
                    Id = 4,
                    Name = "Nike Air Max TW",
                    StarRating = 5,
                    CategoryId = 9,
                    SubCategoryId = 3,
                    Color = "Black",
                    Gender = "Men",
                    BrandId = 1,
                    Description = "So you're in love with the classic look of the '90s, but you've got a thing for today's fast-paced culture. Meet the Air Max TW. Inspired by the treasured franchise that brought Nike Air cushioning to the world and laid the foundation for the track-to-street aesthetic, its eye-catching design delivers a 1–2 punch of comfort and fashion. Ready to highlight any 'fit, its lightweight upper pairs angular and organic lines to create an entrancing haptic effect. The contrasting colourways make it easy to style. And if you're ready for the next step, the 5 windows underfoot deliver a modern edge to visible Air cushioning."
                },
                new Shoes()
                {
                    Id = 5,
                    Name = "Nike Air Max Scorpion Flyknit",
                    StarRating = 5,
                    Gender = "Women",
                    BrandId = 1,
                    SubCategoryId = 3,
                    Color = "Black",
                    Price = 160,
                    Description = "We looked into the future and it's gonna be comfy. Featuring a \"point-loaded\" Air unit (cushioning that forms to your every step), the Air Max Scorpion Flyknit delivers a futuristic sensation. And because looks count, we've crafted the upper from incredibly soft chenille-like fabric."
                },
                new Shoes()
                {
                    Id = 6,
                    Name = "Nike Air VaporMax Plus",
                    StarRating = 5,
                    Gender = "Men",
                    Color = "Blue",
                    CategoryId = 9,
                    SubCategoryId = 3,
                    BrandId = 1,
                    Price = 180,
                    Description = "The Nike Air VaporMax Plus looks to the past and propels you into the future. Nodding to the 1998 Air Max Plus with its floating cage, padded upper and heel logo, it adds revolutionary VaporMax Air technology to ramp up the comfort and create a modern look."
                }
            };
        }
    }
}
