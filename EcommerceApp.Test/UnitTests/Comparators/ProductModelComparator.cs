
namespace EcommerceApp.Tests.UnitTests.Comparators
{
    using Core.Models.Products;
    using System.Collections;
    public class ProductModelComparator : IComparer
    {
        public int Compare(object x, object y)
        {
            var first = (ProductModel)x;
            var second = (ProductModel)y;

            if (first.Name == second.Name && first.DicountPercentage == second.DicountPercentage
                && first.Price == second.Price && first.IsFavorite == second.IsFavorite)
            {
                return 0;
            }
            return 1;
        }
    }
}
