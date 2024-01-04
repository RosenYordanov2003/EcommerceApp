namespace EcommerceApp.Core.Models.Cart
{
    using Models.Products;
    public class CartModel
    {
        public CartModel()
        {
            CartProducts = new List<ProductCartModel>();
        }

        public int CartId { get; set; }
        public ICollection<ProductCartModel> CartProducts { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
