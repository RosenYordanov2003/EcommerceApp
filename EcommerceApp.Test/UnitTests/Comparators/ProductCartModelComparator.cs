namespace EcommerceApp.Tests.UnitTests.Comparators
{
    using Core.Models.Products;
    using System.Collections;

    public class ProductCartModelComparator : IComparer
    {
        public int Compare(object first, object second)
        {
            var x = (ProductCartModel)first;
            var y = (ProductCartModel)second;

            if (x.Name == y.Name && x.ImgUrl == y.ImgUrl && x.Size == y.Size
              && x.CategoryName == y.CategoryName && x.Quantity == y.Quantity && x.Price == y.Price)
            {
                return 0;
            }
            return x.Price < y.Price ? -1 : 1;
        }
    }
}
