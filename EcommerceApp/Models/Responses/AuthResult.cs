namespace EcommerceApp.Models.Responses
{
    public class AuthResult
    {
        public AuthResult()
        {
            Errors = new List<string>();
        }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public bool Success { get; set; }
        public ICollection<string> Errors { get; set; }
    }
}
