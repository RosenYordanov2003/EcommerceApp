namespace EcommerceApp.Tests.UnitTests.Comparators
{
    using System.Collections;
    using Core.Models.Products;
    internal class ProductFeatureModelComparator : IComparer
    {
        public int Compare(object x, object y)
        {
            var first = (ProductFeatureModel)x;
            var second = (ProductFeatureModel)y;

            if (first.Id == second.Id && first.Name == second.Name
                && first.IsFavorite == second.IsFavorite && first.DicountPercentage == second.DicountPercentage
                && first.CategoryName == second.CategoryName)
            {
                return 0;
            }
            return 1;
        }
    }
}
