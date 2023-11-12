namespace EcommerceApp.Config
{
    public class AuthResult
    {
        public AuthResult()
        {
            Errors = new List<string>();
        }
        public string Token { get; set; } = null!;
        public bool Success { get; set; }
        public ICollection<string> Errors { get; set; }
    }
}
