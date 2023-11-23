namespace EcommerceApp.Models.Responses
{
    public class RegisterResponse
    {
        public RegisterResponse()
        {
            Erros = new List<string>();
        }
        public ICollection<string> Erros { get; set; }
    }
}
