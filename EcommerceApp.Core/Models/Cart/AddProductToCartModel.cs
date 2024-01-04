namespace EcommerceApp.Core.Models.Cart
{
    public class AddProductToCartModel
    {
        public Guid UserId { get; set; }
        public int ProductId { get; set; }
        public string CategoryName { get; set; } = null!;
    }
}
