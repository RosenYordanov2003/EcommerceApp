namespace EcommerceApp.Core.Models.Discount
{
    public abstract class DiscountHandler
    {
        protected DiscountHandler nextDiscountHandler;

        public void SetNextDiscountHandler(DiscountHandler discountHandler)
        {
            this.nextDiscountHandler = discountHandler;
        }
        public abstract decimal GetDiscount(int userOrdersCount);
    }
}
