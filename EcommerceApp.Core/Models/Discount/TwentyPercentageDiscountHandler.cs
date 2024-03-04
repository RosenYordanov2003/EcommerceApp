namespace EcommerceApp.Core.Models.Discount
{
    public class TwentyPercentageDiscountHandler : DiscountHandler
    {
        public override decimal GetDiscount(int userOrdersCount)
        {
            if(userOrdersCount % 20 == 0)
            {
                return 20.00m;
            }
            return nextDiscountHandler?.GetDiscount(userOrdersCount) ?? 0;
        }
    }
}
