namespace EcommerceApp.Infrastructure.Data.Configurations
{
    using EcommerceApp.Infrastructure.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BrandEntityConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasMany(b => b.Shoes)
                 .WithOne(sh => sh.Brand)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(b => b.Clothes)
                .WithOne(cl => cl.Brand)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(GenerateBrands());
        }

        private IEnumerable<Brand> GenerateBrands()
        {
           return new List<Brand>()
           {
               new Brand()
               {
                   Id = 1,
                   Name = "Nike",
                   LogoUrl = "https://static.vecteezy.com/system/resources/previews/010/994/412/non_2x/nike-logo-black-with-name-clothes-design-icon-abstract-football-illustration-with-white-background-free-vector.jpg"
               },
               new Brand()
               {
                   Id = 2,
                   Name = "Adidas",
                   LogoUrl = "https://galleriaburgas.bg/?go=_common&p=companylogo&type=big&companyId=166"
               },
               new Brand()
               {
                   Id = 3,
                   Name = "Puma",
                   LogoUrl = "https://modista.bg/image/catalog/aaaaaaaaa%20loga/PUMA-logo.jpg"
               }, new Brand()
               {
                   Id = 4,
                   Name = "Guess",
                   LogoUrl = "https://img.guess.com/image/upload/q_auto/v1/NA/Asset/North%20America/E-Commerce/Shared/Guess-196x196.png"
               },
               new Brand()
               {
                   Id = 5,
                   Name = "Tommy Hilfiger",
                   LogoUrl = "https://img.freepik.com/premium-vector/tommy-hilfiger-logo-set-top-clothing-brand-editorial-logotype-zdolbuniv-ukraine-april-26-2023_505956-735.jpg?w=2000"
               },
               new Brand()
               {
                   Id = 6,
                   Name = "HUGO BOSS",
                   LogoUrl = "https://www.logo-designer.co/storage/2022/08/2022-hugo-boss-new-logo-design.png"
               },
               new Brand()
               {
                   Id = 7,
                   Name = "Zara",
                   LogoUrl = "https://i.pinimg.com/736x/6d/2c/cd/6d2ccd795e409bb68eec5db364e797ef.jpg"
               }
           };
        }
    }
}
