namespace EcommerceApp.Core.Services
{
    using System.Net;
    using Contracts;
    using Data;
    using Infrastructure.Data.Models;
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
                City =  WebUtility.HtmlEncode(orderModel.UserOrderInfo.City),
                Country = WebUtility.HtmlEncode(orderModel.UserOrderInfo.Country),
                PostalCode = int.Parse(WebUtility.HtmlEncode(orderModel.UserOrderInfo.PostalCode.ToString())),
                Adress = WebUtility.HtmlEncode(orderModel.UserOrderInfo.StreetAdress),
                Discount = orderModel.Discount,
                Email = WebUtility.HtmlEncode(orderModel.UserOrderInfo.Email),
                FinishedOn = DateTime.UtcNow,
                FirstName = WebUtility.HtmlEncode(orderModel.UserOrderInfo.FirstName),
                LastName = WebUtility.HtmlEncode(orderModel.UserOrderInfo.LastName),
                Price = orderModel.TotalPrice,
                ShippingMethod = WebUtility.HtmlEncode(orderModel.ShippingInfo.Method),
                ShippingPrice = orderModel.ShippingInfo.Price,
                UserId = orderModel.UserId
            };
            await dbContext.Orders.AddAsync(order);
            await dbContext.SaveChangesAsync();
        }
    }
}
