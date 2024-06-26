﻿namespace EcommerceApp.Core.Models.Cart
{
    public class CartProductModel
    {
        public Guid UserId { get; set; }
        public int ProductId { get; set; }
        public string CategoryName { get; set; } = null!;
        public int Quantity { get; set; }
        public string Size { get; set; } = null!;
    }
}
