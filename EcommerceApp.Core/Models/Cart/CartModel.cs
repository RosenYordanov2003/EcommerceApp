namespace EcommerceApp.Core.Models.Cart
{
    using Models.Products;
    public class CartModel
    {
        public CartModel()
        {
            CartProducts = new List<ProductCartModel>();
            CartShoes = new List<ProductCartModel>();
        }

        public Guid? CartId { get; set; }
        public ICollection<ProductCartModel> CartProducts { get; set; }
        public ICollection<ProductCartModel> CartShoes { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
