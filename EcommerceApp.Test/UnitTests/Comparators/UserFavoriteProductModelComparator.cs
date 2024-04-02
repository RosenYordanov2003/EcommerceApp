namespace EcommerceApp.Tests.UnitTests.Comparators
{
    using Core.Models.Products;
    using System.Collections;
    internal class UserFavoriteProductModelComparator : IComparer
    {
        public int Compare(object x, object y)
        {
           var first = (GetUserFavoriteProductModel)x;
           var second = (GetUserFavoriteProductModel)y;

            if (first.ProductName == second.ProductName && first.ProductId == second.ProductId
                && first.CategoryName == second.CategoryName)
            {
                return 0;
            }
            return 1;
        }
    }
}
