namespace EcommerceApp.Core.Models.Cart
{
    public class ModifyProductCartQuantityModel
    {
        public Guid UserId { get; set; }
        public int ProductId { get; set; }
        public string ProductCategoryName { get; set; } = null!;
        public string Operation { get; set; } = null!;
        public int Quantity { get; set; }
        public string Size { get; set; } = null!;
    }
}
