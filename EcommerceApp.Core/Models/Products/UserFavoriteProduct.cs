﻿namespace EcommerceApp.Core.Models.Products
{
    public class UserFavoriteProduct
    {
        public Guid UserId { get; set; }
        public int ProductId { get; set; }
        public string CategoryName { get; set; } = null!;
    }
}
