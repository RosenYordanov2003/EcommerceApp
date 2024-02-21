namespace EcommerceApp.Models.Account
{
    using System.ComponentModel.DataAnnotations;
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]

        public string UserName { get; set; } = null!;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string RepeatPassword { get; set; } = null!;
    }
}
