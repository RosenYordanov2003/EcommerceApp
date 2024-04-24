namespace EcommerceApp.Tests
{
    using Data;
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

        public static Cart cart;
        public static User user;

        public static Review review1;
        public static Coupon coupon;
        public static Coupon expiredCoupon;

        public static Guid userId = Guid.Parse("AFDEAF68-5DEA-4107-AD18-858071D354D7");


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
            dbContext.ShoesStock.AddRange(SeedShoesStocks());
            dbContext.ProductStocks.AddRange(SeedProductStocks());
            dbContext.Reviews.AddRange(SeedReviews());
            dbContext.Coupons.AddRange(SeedCoupons());
            dbContext.UserMessages.AddRange(SeedUserMessages());
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
                Gender = "Men",
                Price = 40,
                StarRating = 4,
                IsFeatured = true,
                IsArchived = false,
            };
            product2 = new Product()
            {
                Id = 2,
                BrandId = 1,
                Name = "Chicago Bulls Essential",
                Description = "Men's Jordan NBA Long-Sleeve T-Shirt",
                CategoryId = 1,
                Gender = "Men",
                Price = 40,
                StarRating = 4,
                IsFeatured = false,
                IsArchived = false,
            };
            product3 = new Product()
            {
                Id = 3,
                BrandId = 1,
                Name = "Nike Air x Marcus Rashford",
                Price = 38,
                StarRating = 5,
                CategoryId = 1,
                IsFeatured = true,
                IsArchived = false,
                Gender = "Men",
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
                Gender = "Unisex"
            };
            category2 = new Category()
            {
                Id = 2,
                Name = "Shoes",
                Gender = "Unisex"
            };
            category3 = new Category()
            {
                Id = 3,
                Name = "Trousers",
                Gender = "Unisex"
            };

            return new List<Category> { category1, category2, category3 };
        }
        private static User SeedUser()
        {
            return new User()
            {
                Id = userId,
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
                UserId = userId
            };
        }
        private static IEnumerable<UserFavoriteShoes> SeedUserFavoriteShoes()
        {
            var result = new List<UserFavoriteShoes>()
            {
                new UserFavoriteShoes()
                {
                    UserId = userId,
                    ShoesId = 1
                },
                new UserFavoriteShoes()
                {
                    UserId = userId,
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
        private static IEnumerable<ShoesStock> SeedShoesStocks()
        {
            shoesStock1 = new ShoesStock()
            {
                Id = 1,
                ShoesId = 2,
                Size = 45,
                Quantity = 5,
            };
            shoesStock2 = new ShoesStock()
            {
                Id = 2,
                ShoesId = 2,
                Size = 43,
                Quantity = 4,
            };
            shoesStock3 = new ShoesStock()
            {
                Id = 3,
                ShoesId = 2,
                Size = 41,
                Quantity = 7,
            };

            return new List<ShoesStock>() { shoesStock1, shoesStock2, shoesStock3 };
        }
        private static IEnumerable<ProductStock> SeedProductStocks()
        {
            productStock1 = new ProductStock()
            {
                Id = 1,
                Size = "S",
                ProductId = 1,
                Quantity = 5
            };
            productStock2 = new ProductStock()
            {
                Id = 2,
                Size = "L",
                ProductId = 1,
                Quantity = 10
            };
            productStock3 = new ProductStock()
            {
                Id = 3,
                Size = "M",
                ProductId = 2,
                Quantity = 12
            };

            return new List<ProductStock>() { productStock1, productStock2, productStock3 };
        }
        private static IEnumerable<Review> SeedReviews()
        {
            List<Review> reviews = new List<Review>();
            review1 = new Review()
            {
                Id = 1,
                UserId = userId,
                Content = "Test Review",
                CreatedOn = DateTime.Now,
                StarЕvaluation = 5,
                Subject = "About Product",
                ShoesId = shoes1.Id
            };

            reviews.Add(review1);

            return reviews;
        }
        private static IEnumerable<Coupon> SeedCoupons()
        {
            coupon = new Coupon()
            {
                Id = Guid.Parse("A715677F-E39A-4146-A8E8-6E2D6CE687FA"),
                UserId = userId,
                ExpirationTime = DateTime.Now.AddYears(1),
                PromotionPercentages = 10,
            };
            expiredCoupon = new Coupon()
            {
                Id = Guid.Parse("FDDD9617-8ADB-45F0-AEB8-58F415C6143B"),
                UserId = userId,
                PromotionPercentages = 15,
                ExpirationTime = new DateTime(2023, 12, 14)
            };
            List<Coupon> coupons = new List<Coupon>() { coupon, expiredCoupon };

            return coupons;
        }
        private static IEnumerable<UserMessage> SeedUserMessages()
        {
            List<UserMessage> userMessages = new List<UserMessage>()
            {
                new UserMessage()
                {
                    Id = Guid.Parse("6B3033A9-5840-4A58-898A-F75989EE43C5"),
                    CreatedOn = new DateTime(2023,12, 14),
                    IsResponded = false,
                    Message = "Test Message",
                    UserId = userId
                },
                new UserMessage()
                {
                    Id = Guid.Parse("D15DE586-781C-45E0-85E1-D8634AAB7DA7"),
                    CreatedOn = new DateTime(2023,12, 14),
                    IsResponded = false,
                    Message = "Test Message 2",
                    UserId = userId
                }
            };
            return userMessages;
        }
    }
}
