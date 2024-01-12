namespace EcommerceApp.Core.Contracts
{
    using Models.Orders;
    public interface IOrderService
    {
        Task MakeOrderAsync(OrderModel orderModel);
    }
}
