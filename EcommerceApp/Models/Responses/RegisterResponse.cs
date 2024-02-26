namespace EcommerceApp.Models.Responses
{
    public class RegisterResponse
    {
        public RegisterResponse()
        {
            Erros = new List<string>();
        }
        public ICollection<string> Erros { get; set; }
        public string? ErrorMessage { get; set; }
        public bool Success { get; set; }
    }
}
