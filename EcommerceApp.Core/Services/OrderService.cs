namespace EcommerceApp.Core.Services
{
    using Contracts;
    using EcommerceApp.Data;
    using EcommerceApp.Infrastructure.Data.Models;
    using Models.Orders;
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext dbContext;

        public OrderService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task MakeOrderAsync(OrderModel orderModel)
        {
            Order order = new Order()
            {
                City = orderModel.UserOrderInfo.City,
                Country = orderModel.UserOrderInfo.Country,
                PostalCode = orderModel.UserOrderInfo.PostalCode,
                Adress = orderModel.UserOrderInfo.StreetAdress,
                Discount = orderModel.Discount,
                Email = orderModel.UserOrderInfo.Email,
                FinishedOn = DateTime.UtcNow,
                FirstName = orderModel.UserOrderInfo.FirstName,
                LastName = orderModel.UserOrderInfo.LastName,
                Price = orderModel.TotalPrice,
                ShippingMethod = orderModel.ShippingInfo.Method,
                ShippingPrice = orderModel.ShippingInfo.Price,
                UserId = orderModel.UserId
            };
            await dbContext.Orders.AddAsync(order);
            await dbContext.SaveChangesAsync();
        }
    }
}
