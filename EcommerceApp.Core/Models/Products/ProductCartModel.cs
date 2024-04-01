namespace EcommerceApp.Core.Models.Products
{
    public class ProductCartModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
        public decimal Price { get; set; }
        public string? ImgUrl { get; set; }
        public int Quantity { get; set; }
        public string Size { get; set; } = null!;
    }
}
