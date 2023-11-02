using Duende.IdentityServer.EntityFramework.Options;
using EcommerceApp.Infrastructure.Data.Configurations;
using EcommerceApp.Infrastructure.Data.Models;
using EcommerceApp.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EcommerceApp.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {

        }
        public DbSet<MainCategory> Categories { get; set; }
        public DbSet<Shoes> Shoes { get; set; }
        public DbSet<Clothes> Clothes { get; set; }
        public DbSet<Brand> Brands { get; set; }
       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new BrandEntityConfiguration());
            builder.ApplyConfiguration(new MainCategoryEntityConfiguration());
            builder.ApplyConfiguration(new SubCategoryEntityConfiguration());
            builder.ApplyConfiguration(new ShoesEntityConfiguration());
            builder.ApplyConfiguration(new PictureEntityConfiguration());
        }
    }
}