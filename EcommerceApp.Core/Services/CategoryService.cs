namespace EcommerceApp.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using Contracts;
    using Data;
    using Models.Categories;

    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext applicationDbContext;
        public CategoryService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<CategoryModel>> GetCategoriesByGender(string gender)
        {
            gender = gender.ToLower();
            return await applicationDbContext.Categories
                  .Where(c => (c.Gender.ToLower() == gender.ToLower()) || c.Gender.ToLower() == "unisex")
                  .Select(c => new CategoryModel()
                  {
                      Id = c.Id,
                      Name = c.Name,
                  })
                  .ToArrayAsync();

        }
        public async Task<IEnumerable<CategoryModel>> LoadAllCategoriesAsync()
        {
            return await applicationDbContext.Categories
                .Select(c => new CategoryModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToArrayAsync();
        }
    }
}
