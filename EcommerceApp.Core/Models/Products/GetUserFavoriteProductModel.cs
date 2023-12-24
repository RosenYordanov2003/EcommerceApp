namespace EcommerceApp.Core.Models.Products
{
    public class GetUserFavoriteProductModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string ImgUrl { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
    }
}
