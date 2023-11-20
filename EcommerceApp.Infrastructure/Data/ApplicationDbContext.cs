using EcommerceApp.Infrastructure.Data.Configurations;
using EcommerceApp.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<MainCategory> Categories { get; set; }
        public DbSet<Shoes> Shoes { get; set; }
        public DbSet<Clothes> Clothes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new BrandEntityConfiguration());
            builder.ApplyConfiguration(new MainCategoryEntityConfiguration());
            builder.ApplyConfiguration(new SubCategoryEntityConfiguration());
            builder.ApplyConfiguration(new ShoesEntityConfiguration());
            builder.ApplyConfiguration(new ClothesEntityConfiguration());
            builder.ApplyConfiguration(new PictureEntityConfiguration());
        }
    }
}