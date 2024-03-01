namespace EcommerceApp.Core.Contracts
{
    using Models.Orders;
    public interface IOrderService
    {
        Task MakeOrderAsync(OrderModel orderModel);
        Task<bool> CheckIfOrderExistsByIdAsync(Guid id);
        Task<OrderDetailsModel> GetOrderDetailsByIdAsync(Guid id);
    }
}
