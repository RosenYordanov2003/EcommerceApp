namespace EcommerceApp.Core.Models.Cart
{
    public class RemoveCartProductModel
    {
        public Guid UserId { get; set; }
        public string CategoryName { get; set; } = null!;
        public int ProductId { get; set; }
    }
}
