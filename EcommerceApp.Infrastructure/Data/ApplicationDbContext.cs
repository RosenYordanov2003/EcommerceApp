using EcommerceApp.Infrastructure.Data.Configurations;
using EcommerceApp.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Data
{
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
       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<RefreshToken>()
              .HasOne(u => u.User)
              .WithOne(u => u.RefreshToken)
              .OnDelete(DeleteBehavior.NoAction);

            builder.ApplyConfiguration(new BrandEntityConfiguration());
            builder.ApplyConfiguration(new MainCategoryEntityConfiguration());
            builder.ApplyConfiguration(new SubCategoryEntityConfiguration());
            builder.ApplyConfiguration(new ShoesEntityConfiguration());
            builder.ApplyConfiguration(new ProductEntityConfiguration());
            builder.ApplyConfiguration(new PictureEntityConfiguration());
        }
    }
}