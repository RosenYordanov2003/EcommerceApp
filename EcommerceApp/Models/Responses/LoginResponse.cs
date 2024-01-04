namespace EcommerceApp.Models.Responses
{
    using Core.Models.Products;
    using EcommerceApp.Core.Models.Cart;

    public class LoginResponse : RegisterResponse
    {
        public LoginResponse()
        {
            UserFavoriteProducts = new List<GetUserFavoriteProductModel>();
        }
        public string Username { get; set; } = null!;
        public Guid Id { get; set; }
        public ICollection<GetUserFavoriteProductModel> UserFavoriteProducts { get; set; }
        public CartModel? CartModel { get; set; }
    }
}
