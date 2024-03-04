namespace EcommerceApp.Core.Models.Discount
{
    public class TenPercentageDiscountHandler : DiscountHandler
    {
        public override decimal GetDiscount(int userOrdersCount)
        {
            if (userOrdersCount % 10 == 0)
            {
                return 10.00m;
            }
            return nextDiscountHandler?.GetDiscount(userOrdersCount) ?? 0m;
        }
    }
}
