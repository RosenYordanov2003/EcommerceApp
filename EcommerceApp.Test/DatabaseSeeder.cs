namespace EcommerceApp.Tests
{
    using EcommerceApp.Data;
    using Infrastructure.Data.Models;


    public class DatabaseSeeder
    {
        public static Brand brand1;
        public static Brand brand2;

        public static Category category1;
        public static Category category2;
        public static Category category3;

        public static Shoes shoes1;
        public static Shoes shoes2;
        public static Shoes shoes3;

        public static Product product1;
        public static Product product2;
        public static Product product3;

        public static Promotion promotion1;
        public static Promotion promotion2;

        public static ProductStock productStock1;
        public static ProductStock productStock2;
        public static ProductStock productStock3;

        public static ShoesStock shoesStock1;
        public static ShoesStock shoesStock2;
        public static ShoesStock shoesStock3;

        public static Cart Cart;
        public static User User;

        public static Guid UserId = Guid.Parse("AFDEAF68-5DEA-4107-AD18-858071D354D7");


        public static void SeedDatabase(ApplicationDbContext dbContext)
        {
            dbContext.Brands.AddRange(SeedBrands());
            dbContext.Categories.AddRange(SeedCategories());
            dbContext.Shoes.AddRange(SeedShoes());
            dbContext.Clothes.AddRange(SeedProducts());
            dbContext.Users.Add(SeedUser());
            dbContext.Carts.Add(SeedCart());
            dbContext.UserFavoriteShoes.AddRange(SeedUserFavoriteShoes());
            dbContext.Promotions.AddRange(SeedPromotions());
            dbContext.SaveChanges();
        }

        private static IEnumerable<Shoes> SeedShoes()
        {
            shoes1 = new Shoes()
            {
                Id = 1,
                Name = "Nike Air Force 1 '07 LV8",
                StarRating = 5,
                CategoryId = 2,
                BrandId = 1,
                Price = 130,
                IsFeatured = true,
                PromotionId = Guid.Parse("EA99BAEFC49D4A19BC82DFF62231AFE9"),
                Gender = "Men",
                Description = "The radiance lives on in the Nike Air Force 1 '07 LV8. Crossing hardwood comfort with off-court flair, these kicks put a fresh spin on a hoops classic. Soft suede overlays pair with era-echoing '80s construction and reflective-design Swoosh logos to bring you nothing-but-net style while hidden full-length Air units add the legendary comfort you know and love."
            };
            shoes2 = new Shoes()
            {
                Id = 2,
                Name = "Nike Mercurial Vapor 15 Pro",
                StarRating = 5,
                CategoryId = 2,
                Price = 160,
                BrandId = 1,
                IsFeatured = true,
                Gender = "Men",
                Description = "The pitch is yours when you lace up in the Vapor 15 Pro AG-Pro. It's loaded with a Zoom Air unit, so you can dominate in the waning minutes of a match—when it matters most. Fast is in the Air."
            };
            shoes3 = new Shoes()
            {
                Id = 3,
                Name = "Nike Mercurial Superfly 9 Elite",
                StarRating = 5,
                CategoryId = 2,
                Price = 250,
                Gender = "Men",
                IsArchived = false,
                BrandId = 1,
                Description = "Instantly tilt the pitch in the bold design of the Superfly 9 Elite SG-Pro. We added a Zoom Air unit, made specifically for football, and grippy texture up top for exceptional touch, so you can dominate in the waning minutes of a match—when it matters most. Feel the explosive speed as you race around the pitch, making the critical plays with velocity and pace. Fast is in the Air. This version has Anti-Clog Traction on the soleplate, which helps prevent mud from sticking."
            };

            return new List<Shoes>() { shoes1, shoes2, shoes3 };
        }

        private static IEnumerable<Product> SeedProducts()
        {
            product1 = new Product()
            {
                Id = 1,
                BrandId = 1,
                Name = "Chicago Bulls Essential",
                Description = "Men's Jordan NBA Long-Sleeve T-Shirt",
                CategoryId = 1,
                Gender = "M",
                Price = 40,
                StarRating = 4
            };
            product2 = new Product()
            {
                Id = 2,
                BrandId = 1,
                Name = "Chicago Bulls Essential",
                Description = "Men's Jordan NBA Long-Sleeve T-Shirt",
                CategoryId = 1,
                Gender = "M",
                Price = 40,
                StarRating = 4
            };
            product3 = new Product()
            {
                Id = 3,
                BrandId = 1,
                Name = "Nike Air x Marcus Rashford",
                Price = 38,
                StarRating = 5,
                CategoryId = 1,
                Gender = "M",
                Description = "From the pitch to the streets, you can celebrate Marcus Rashford's passion for sport in comfort with this sweat-wicking tee. Soft fabric and a relaxed fit help keep you dry and comfortable, while retro branding and an \"MR\" logo add the perfect finishing touches."
            };
            return new List<Product>() { product1, product2, product3 };
        }
        private static IEnumerable<Brand> SeedBrands()
        {
            brand1 = new Brand()
            {
                Id = 1,
                Name = "Nike",
                LogoUrl = "https://static.vecteezy.com/system/resources/previews/010/994/412/non_2x/nike-logo-black-with-name-clothes-design-icon-abstract-football-illustration-with-white-background-free-vector.jpg"
            };
            brand2 = new Brand()
            {
                Id = 2,
                Name = "Adidas",
                LogoUrl = "https://galleriaburgas.bg/?go=_common&p=companylogo&type=big&companyId=166"
            };
            return new List<Brand>() { brand1, brand2 };
        }
        private static IEnumerable<Category> SeedCategories()
        {
            category1 = new Category()
            {
                Id = 1,
                Name = "T-Shirts",
                Gender = "W M"
            };
            category2 = new Category()
            {
                Id = 2,
                Name = "Shoes",
                Gender = "W M"
            };
            category3 = new Category()
            {
                Id = 3,
                Name = "Trousers",
                Gender = "W M"
            };

            return new List<Category> { category1, category2, category3 };
        }
        private static User SeedUser()
        {
            return new User()
            {
                Id = UserId,
                CartId = Guid.Parse("742C4C45-5A51-4053-8F5E-7062135175A3"),
                UserName = "Test123",
                NormalizedUserName = "TEST123",
                Email = "test123@gmail.com",
                NormalizedEmail = "TEST123@GMAIL.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
            };
        }
        private static Cart SeedCart()
        {
            return new Cart()
            {
                Id = Guid.Parse("742C4C45-5A51-4053-8F5E-7062135175A3"),
                UserId = UserId
            };
        }
        private static IEnumerable<UserFavoriteShoes> SeedUserFavoriteShoes()
        {
            var result = new List<UserFavoriteShoes>()
            {
                new UserFavoriteShoes()
                {
                    UserId = UserId,
                    ShoesId = 1
                },
                new UserFavoriteShoes()
                {
                    UserId = UserId,
                    ShoesId = 2
                }
            };

            return result;
        }
        private static IEnumerable<Promotion> SeedPromotions()
        {
            promotion1 = new Promotion()
            {
                ShoesId = 1,
                Id = Guid.Parse("EA99BAEFC49D4A19BC82DFF62231AFE9"),
                ExpireTime = new DateTime(2024, 8, 4),
                PercantageDiscount = 25.50m
            };
            var result = new List<Promotion>();
            result.Add(promotion1);

            return result;
        }

    }
}
