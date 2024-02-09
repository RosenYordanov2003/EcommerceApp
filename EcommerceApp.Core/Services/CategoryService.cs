namespace EcommerceApp.Core.Services
{
    using Contracts;
    using EcommerceApp.Data;
    using Microsoft.EntityFrameworkCore;
    using Models.Categories;
    using System.Linq;

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
                  .Where(c => c.Gender.ToLower().IndexOf(gender) > -1)
                  .Select(c => new CategoryModel()
                  {
                      Id = c.Id,
                      Name = c.Name,
                  })
                  .ToArrayAsync();

        }
    }
}
