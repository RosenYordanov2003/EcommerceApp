namespace EcommerceApp.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Infrastructure.Data.Models;
    using Infrastructure.Data.Configurations;
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<MainCategory> Categories { get; set; }
        public DbSet<Shoes> Shoes { get; set; }
        public DbSet<Product> Clothes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbSet<ProductStock> ProductStocks { get; set; }
        public DbSet<ShoesStock> ShoesStock { get; set; }

        public DbSet<Review> Reviews { get; set; }
        public DbSet<Cart> Carts { get; set; }

        public DbSet<UserFavoriteProducts> UserFavoriteProducts { get; set; }
        public DbSet<UserFavoriteShoes> UserFavoriteShoes { get; set; }

        public DbSet<ShoesCartEntity> ShoesCartEntities { get; set; }
        public DbSet<ProductCartEntity> ProductCartEntities { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<PromotionCode> PromotionCodes { get; set; }
       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<RefreshToken>()
              .HasOne(u => u.User)
              .WithOne(u => u.RefreshToken)
              .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<UserFavoriteShoes>()
                .HasKey(ck => new { ck.UserId, ck.ShoesId });

            builder.Entity<UserFavoriteProducts>()
               .HasKey(ck => new { ck.UserId, ck.ProductId });

            builder.Entity<UserFavoriteShoes>()
                .HasOne(us => us.User)
                .WithMany(u => u.UserFavoriteShoes)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<UserFavoriteProducts>()
             .HasOne(us => us.User)
             .WithMany(u => u.UserFavoriteProducts)
             .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<PromotionCode>()
                .HasOne(pc => pc.User)
                .WithMany(u => u.PromotionCodes)
                .OnDelete(DeleteBehavior.NoAction);


            builder.ApplyConfiguration(new BrandEntityConfiguration());
            builder.ApplyConfiguration(new MainCategoryEntityConfiguration());
            builder.ApplyConfiguration(new SubCategoryEntityConfiguration());
            builder.ApplyConfiguration(new ShoesEntityConfiguration());
            builder.ApplyConfiguration(new ProductEntityConfiguration());
            builder.ApplyConfiguration(new PictureEntityConfiguration());
            builder.ApplyConfiguration(new ShoesStockEntityConfiguration());
            builder.ApplyConfiguration(new ProductStockEntityConfiguration());
        }
    }
}