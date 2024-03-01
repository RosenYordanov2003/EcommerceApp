namespace EcommerceApp.Core.Models.Orders
{
    using Products;
    public class OrderDetailsModel
    {
        public OrderDetailsModel()
        {
            Products = new List<ProductCartModel>();
        }
        public string ShippingMethod { get; set; } = null!;
        public string ShippingAddress { get; set; } = null!;
        public string City { get; set; } = null!;
        public decimal TotalPrice { get; set; }
        public decimal Discount { get; set; }
        public IEnumerable<ProductCartModel> Products { get; set; }
    }
}
