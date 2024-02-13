namespace EcommerceApp.Core.Contracts
{
    using Models.Categories;
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryModel>> GetCategoriesByGender(string gender);
        Task<IEnumerable<CategoryModel>> LoadAllCategoriesAsync();
    }
}
