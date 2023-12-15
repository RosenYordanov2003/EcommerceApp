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

        private static IEnumerable<Shoes> GenerateShoes()
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
                    IsFeatured = true,
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
                    IsFeatured= true,
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
                    Price = 110,
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
                    CategoryId = 9,
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
                    IsFeatured = true,
                    Description = "The Nike Air VaporMax Plus looks to the past and propels you into the future. Nodding to the 1998 Air Max Plus with its floating cage, padded upper and heel logo, it adds revolutionary VaporMax Air technology to ramp up the comfort and create a modern look."
                },
                new Shoes()
                {
                    Id = 7,
                    Name =  "Adidas Alphabounce Beyond Team",
                    StarRating = 4,
                    Gender = "Men",
                    Color = "Dark Blue",
                    CategoryId = 9,
                    SubCategoryId = 1,
                    BrandId = 2,
                    Price = 70,
                    Description = "Designed for athletes who run to stay fit for their sport, these running shoes support multidirectional movements with flexible cushioning and a wide, stable platform in the forefoot and heel. They have a seamless, sock-like mesh upper with targeted areas of support and stretch for an adaptive fit.\r\nRunner type\r\nNeutral shoes for the versatile runner\r\nAdaptive fit\r\nSeamless Forgedmesh upper designed with areas of support and stretch to help ensure a custom fit that adapts to every move\r\nSpringy cushioning\r\nBounce cushioning provides enhanced comfort and flexibility\r\nReliable traction\r\nContinental™ Rubber outsole for extraordinary traction in wet and dry conditions"
                },
                new Shoes()
                {
                    Id = 8,
                    Name = "Adidas Alphabounce Beyond Team",
                    StarRating = 4,
                    Gender = "Men",
                    CategoryId = 9,
                    SubCategoryId = 1,
                    BrandId = 2,
                    Color = "Dark Red",
                    Price = 70,
                    Description = "Designed for athletes who run to stay fit for their sport, these running shoes support multidirectional movements with flexible cushioning and a wide, stable platform in the forefoot and heel. They have a seamless, sock-like mesh upper with targeted areas of support and stretch for an adaptive fit.\r\nRunner type\r\nNeutral shoes for the versatile runner\r\nAdaptive fit\r\nSeamless Forgedmesh upper designed with areas of support and stretch to help ensure a custom fit that adapts to every move\r\nSpringy cushioning\r\nBounce cushioning provides enhanced comfort and flexibility\r\nReliable traction\r\nContinental™ Rubber outsole for extraordinary traction in wet and dry conditions"
                },
                new Shoes()
                {
                    Id = 9,
                    Name = "Adidas ACE 17.3 Firm Ground",
                    BrandId = 2,
                    CategoryId = 9,
                    SubCategoryId = 4,
                    Color = "Orange",
                    Price = 78.41M,
                    Gender = "Men",
                    Description = "Dominate space. Command the play. Create goal-destined shots from impossible angles. Control the game with every touch in ACE. These juniors' soccer cleats have a 3D Control Skin upper that delivers precise control with zero wear-in time. Designed to dominate on firm ground."
                },
                new Shoes()
                {
                    Id = 10,
                    Name = "Adidas Adizero 8.0",
                    BrandId = 2,
                    CategoryId = 9,
                    SubCategoryId = 4,
                    Color = "White",
                    Price = 83.41M,
                    Gender = "Men",
                    Description = "Showcase your playmaking speed in these football cleats. Designed for easy on and off, they feature a textile upper with a sock-like construction for lightweight stability and lockdown as you create havoc at the line of scrimmage. The cleated outsole provides traction for quick cuts and pivots.. These juniors' soccer cleats have a 3D Control Skin upper that delivers precise control with zero wear-in time. Designed to dominate on firm ground."
                },
                new Shoes()
                {
                    Id = 11,
                    Name = "Adidas Predator 19.3 Laceless Firm Ground",
                    BrandId = 2,
                    CategoryId = 9,
                    SubCategoryId = 4,
                    Color = "Red",
                    Price = 83.41M,
                    Gender = "Men",
                    Description = "If your command of the field leaves your rivals' tactics in tatters, you're ready to own Predators. Built for precision on firm ground, these soccer cleats have a supportive mesh upper that wraps around your foot to lock you in. This eliminates the need for laces and leaves more room for ball control. Embossing on the surface adds confidence to every touch."
                },
                new Shoes()
                {
                    Id = 12,
                    Name = "Slipstream Xtreme Sneakers",
                    BrandId = 3,
                    CategoryId = 9,
                    SubCategoryId = 1,
                    Color = "Black",
                    Gender = "Men",
                    Price = 140,
                    Description = "We’re taking Slipstream to the extreme. This disruptive new version features an iconic Slipstream leather upper with elevated details, and a edgier sole with exaggerated proportions and rugged details. This execution features a leather base with nubuck overlays, a suede Formstrip with deep debossed lines and suede details."
                },
                new Shoes()
                {
                    Id = 13,
                    Name = "Slipstream Leather Sneakers",
                    BrandId = 3,
                    CategoryId = 9,
                    SubCategoryId = 1,
                    Color = "White",
                    Gender = "Women",
                    Price = 70,
                    IsFeatured = true,
                    Description = "Back in 1987, the PUMA Slipstream Mid entered the scene as a basketball sneaker. A high-flying, slam-dunking, statement-making basketball sneaker. Now, it’s joined by the Slipstream – a rework of the original that brings an all-new energy to the game while staying true to the OG’s sporting roots."
                },
                new Shoes()
                {
                    Id = 14,
                    Name = "Slipstream Leather Sneakers",
                    BrandId = 3,
                    CategoryId = 9,
                    SubCategoryId = 1,
                    Color = "Red",
                    Gender = "Women",
                    Price = 70,
                    Description = "Back in 1987, the PUMA Slipstream Mid entered the scene as a basketball sneaker. A high-flying, slam-dunking, statement-making basketball sneaker. Now, it’s joined by the Slipstream – a rework of the original that brings an all-new energy to the game while staying true to the OG’s sporting roots."
                },
                new Shoes()
                {
                    Id = 15,
                    Name = "ULTRA ULTIMATE MG Football Cleats Men",
                    BrandId = 3,
                    CategoryId = 9,
                    SubCategoryId = 4,
                    Color = "Green",
                    Gender = "Men",
                    Price = 70,
                    IsFeatured = true,
                    Description = "ULTRA - Not even you knew you could be this fast. Turn seconds into records with the ULTRA ULTIMATE football boot. Lighter means quicker, so the ULTRAWEAVE upper material makes every gram and every second count. Ultra-light. Ultra-fast. ULTRA ULTIMATE."
                },
                new Shoes()
                {
                    Id = 16,
                    Name = "ULTRA PLAY IT Youth Football Boots",
                    BrandId = 3,
                    CategoryId = 9,
                    SubCategoryId = 4,
                    Color = "Blue",
                    Gender = "Men",
                    Price = 60,
                    Description = "ULTRA - Not even you knew you could be this fast. Turn seconds into records with the ULTRA ULTIMATE football boot. Lighter means quicker, so the ULTRAWEAVE upper material makes every gram and every second count. Ultra-light. Ultra-fast. ULTRA ULTIMATE."
                }
            };
        }
    }
}
