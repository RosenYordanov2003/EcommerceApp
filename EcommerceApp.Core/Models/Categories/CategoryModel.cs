namespace EcommerceApp.Core.Models.Categories
{
    public class CategoryModel
    {
        public CategoryModel()
        {
            SubCategories = new List<CategoryModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public IEnumerable<CategoryModel> SubCategories { get; set; }
    }
}
