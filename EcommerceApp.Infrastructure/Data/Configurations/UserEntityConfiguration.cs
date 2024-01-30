namespace EcommerceApp.Infrastructure.Data.Configurations
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    using Infrastructure.Data.Models;
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            IEnumerable<User> users = CreateUsers();
            builder.HasData(users);
        }

        private IEnumerable<User> CreateUsers()
        {
            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            User adminUser = new User()
            {
                Id = Guid.Parse("ED842FDC-C71B-4FBC-8DF5-6F97CB73D622"),
                UserName = "Admin",
                NormalizedUserName = "АDMIN",
                Email = "admin123@gmail.com",
                NormalizedEmail = "ADMIN123@GMAIL.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "admin12345");
            List<User> users = new List<User>() {adminUser };

            return users;
        }
    }
}
