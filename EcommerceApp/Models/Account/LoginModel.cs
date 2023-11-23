namespace EcommerceApp.Models.Account
{
    using System.ComponentModel.DataAnnotations;
    public class LoginModel
    {
        [Required]
        public string Username { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
