namespace EcommerceApp.Models.Responses
{
    using Core.Models.Products;
    public class LoginResponse : RegisterResponse
    {
        public LoginResponse()
        {
            UserFavoriteProducts = new List<GetUserFavoriteProductModel>();
        }
        public string Username { get; set; } = null!;
        public Guid Id { get; set; }
        public ICollection<GetUserFavoriteProductModel> UserFavoriteProducts { get; set; }
    }
}
