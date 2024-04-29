namespace EcommerceApp.Tests.IntegrationTests
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.Extensions.DependencyInjection;
    using System.Text;
    using System.IdentityModel.Tokens.Jwt;
    using System.Net.Http.Headers;
    using System.Security.Claims;
    using Microsoft.IdentityModel.Tokens;
    using Moq;
    using Core.Contracts;
    using static Common.GeneralApplicationConstants;


    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        public CustomWebApplicationFactory()
        {
            CategoryServiceMock = new Mock<ICategoryService>();
            CouponServiceMock = new Mock<ICouponService>();
            ShoesServiceMock = new Mock<IShoesService>();
            DashboardServiceMock = new Mock<IDashboardService>();
        }
        public Mock<ICategoryService> CategoryServiceMock { get; set; }
        public Mock<ICouponService> CouponServiceMock { get; set; }
        public Mock<IShoesService> ShoesServiceMock { get; set; }
        public Mock<IDashboardService> DashboardServiceMock { get; set; }
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);
            builder.ConfigureServices(services =>
            {
                services.AddSingleton(CategoryServiceMock.Object);
                services.AddSingleton(CouponServiceMock.Object);
                services.AddSingleton(ShoesServiceMock.Object);
                services.AddSingleton(DashboardServiceMock.Object);
            });
        }
        protected override void ConfigureClient(HttpClient client)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            byte[] key = Encoding.ASCII.GetBytes("ougkfmdmrebzbatmpwnaaqztsselnywn");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, "Gosho"), new Claim(ClaimTypes.Role,AdminRoleName) }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);
           
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
        }
    }
}
