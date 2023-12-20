namespace EcommerceApp.Models.Responses
{
    public class LoginResponse : RegisterResponse
    {
        public string Username { get; set; }
        public Guid Id { get; set; }
    }
}
