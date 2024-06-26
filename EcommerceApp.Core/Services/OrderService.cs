﻿namespace EcommerceApp.Core.Services
{
    using System.Net;
    using Microsoft.EntityFrameworkCore;
    using Contracts;
    using Data;
    using Infrastructure.Data.Models;
    using Models.Orders;
    using Models.Products;

    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext dbContext;

        public OrderService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> CheckIfOrderExistsByIdAsync(Guid id)
        {
            return await dbContext.Orders.AnyAsync(o => o.Id == id);
        }

        public async Task<OrderDetailsModel> GetOrderDetailsByIdAsync(Guid id)
        {
            var producs = new List<ProductCartModel>();

            var shoes = await dbContext.ShoesOrderEntities.Where(sh => sh.OrderId == id)
                .Select(sh => new ProductCartModel()
                {
                    CategoryName = sh.Shoes.Category.Name,
                    ImgUrl = sh.Shoes.Pictures.Count > 0 ? sh.Shoes.Pictures.First().ImgUrl : null,
                    Size = sh.Size.ToString(),
                    Id = sh.Id,
                    Name = sh.Shoes.Name,
                    Price = sh.Shoes.Price * sh.Quantity,
                    Quantity = sh.Quantity
                })
                .ToArrayAsync();

            var products = await dbContext.ProductOrderEntities.Where(p => p.OrderId == id)
              .Select(p => new ProductCartModel()
              {
                  CategoryName = p.Product.Category.Name,
                  ImgUrl = p.Product.Pictures.Count > 0 ? p.Product.Pictures.First().ImgUrl : null,
                  Size = p.Size,
                  Id = p.Id,
                  Name = p.Product.Name,
                  Price = p.Product.Price * p.Quantity,
                  Quantity = p.Quantity

              })
              .ToArrayAsync();

            producs.AddRange(shoes);
            producs.AddRange(products);

            OrderDetailsModel orderDetailsModel = await dbContext
                .Orders
                .Where(o => o.Id == id)
                .Select(o => new OrderDetailsModel()
                {
                    City = o.City,
                    Discount = o.Discount,
                    ShippingAddress = o.Adress,
                    ShippingMethod = o.ShippingMethod,
                    TotalPrice = o.Price,
                    OrderStatus = o.FinishedOn.AddDays(o.ShippingMethod == "fast" ? 2 : 4) < DateTime.Now ? "Delivered" : "Pending",
                    Country = o.Country,
                })
                .FirstAsync();

            orderDetailsModel.Products = producs;

            return orderDetailsModel;
        }

        public async Task MakeOrderAsync(OrderModel orderModel)
        {
            Order order = new Order()
            {
                City = WebUtility.HtmlEncode(orderModel.UserOrderInfo.City),
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

            var products = await dbContext.ProductCartEntities.Where(p => p.Cart.UserId == orderModel.UserId).ToArrayAsync();
            var shoes = await dbContext.ShoesCartEntities.Where(sh => sh.Cart.UserId == orderModel.UserId).ToArrayAsync();

            foreach (var item in products)
            {
                ProductOrderEntity productOrderEntity = new ProductOrderEntity()
                {
                    OrderId = order.Id,
                    Quantity = item.Quantity,
                    ProductId = item.ProductId,
                    Size = item.Size,
                };
                await dbContext.ProductOrderEntities.AddAsync(productOrderEntity);
            }
            foreach (var item in shoes)
            {
                ShoesOrderEntity shoesOrderEntity = new ShoesOrderEntity()
                {
                    OrderId = order.Id,
                    Quantity = item.Quantity,
                    ShoesId = item.ShoesId,
                    Size = item.Size,
                };
                await dbContext.ShoesOrderEntities.AddAsync(shoesOrderEntity);
            }
            await dbContext.SaveChangesAsync();
        }
    }
}
