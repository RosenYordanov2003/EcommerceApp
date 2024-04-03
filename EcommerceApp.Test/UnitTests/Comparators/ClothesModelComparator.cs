namespace EcommerceApp.Tests.UnitTests.Comparators
{
    using System.Collections;
    using Core.Models.AdminModels.Clothes;
    internal class ClothesModelComparator : IComparer
    {
        public int Compare(object x, object y)
        {
            var first = (ClothesModel)x;
            var second = (ClothesModel)y;

            if (first.Id == second.Id && first.IsArchived == second.IsArchived
                && first.Price == second.Price && first.StarRating == second.StarRating)
            {
                return 0;
            }
            return 1;
        }
    }
}
