namespace EcommerceApp.Tests.UnitTests.Comparators
{
    using Core.Models.ProductStocks;
    using System.Collections;
    internal class ProductStockComparator : IComparer
    {
        public int Compare(object x, object y)
        {
            var first = (ProductStock<string>)x;
            var second = (ProductStock<string>)y;

            if (first.Size == second.Size && first.Quantity == second.Quantity)
            {
                return 0;
            }
            return 1;
        }
    }
}
