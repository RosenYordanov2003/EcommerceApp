namespace EcommerceApp.Core.Models.Discount
{
    public class NewClientDiscountHandler : DiscountHandler
    {
        public override decimal GetDiscount(int userOrdersCount)
        {
            if (userOrdersCount == 1)
            {
                return 5.00m;
            }
            return nextDiscountHandler?.GetDiscount(userOrdersCount) ?? 0m;
        }
    }
}
