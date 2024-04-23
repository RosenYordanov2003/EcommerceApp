namespace EcommerceApp.Tests.IntegrationTests
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.Extensions.DependencyInjection;
    using Moq;
    using Core.Contracts;

    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        public Mock<ICategoryService> CategoryServiceMock { get; set; }
        public CustomWebApplicationFactory()
        {
            CategoryServiceMock = new Mock<ICategoryService>();
        }
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);
            builder.ConfigureServices(services =>
            {
                services.AddSingleton(CategoryServiceMock.Object);
            });
        }
    }
}
