namespace EcommerceApp.Tests.IntegrationTests
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.Extensions.DependencyInjection;
    using Moq;
    using Core.Contracts;
    using Core.Models.Categories;

    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        private Mock<ICategoryService> categoryService;
        public CustomWebApplicationFactory()
        {
            Config();
        }
        private void Config()
        {
            categoryService = new Mock<ICategoryService>();
            IEnumerable<CategoryModel> categoryModelCollectionMen = new CategoryModel[2] { new CategoryModel() { Id = 1, Name = "Shoes" }, new CategoryModel() { Id = 2, Name = "Trousers" } };
            IEnumerable<CategoryModel> categoryModelCollectionWomen = new CategoryModel[2] { new CategoryModel() { Id = 1, Name = "Shoes" }, new CategoryModel() { Id = 2, Name = "Skirts" } };
            categoryService = new Mock<ICategoryService>();
            categoryService.Setup(x => x.GetCategoriesByGender("men")).ReturnsAsync(categoryModelCollectionMen);
            categoryService.Setup(x => x.GetCategoriesByGender("women")).ReturnsAsync(categoryModelCollectionWomen);
        }
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);
            builder.ConfigureServices(services =>
            {
                services.AddSingleton(categoryService.Object);
            });
        }
    }
}
