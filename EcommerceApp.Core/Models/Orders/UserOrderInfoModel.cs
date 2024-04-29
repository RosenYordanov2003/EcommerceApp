namespace EcommerceApp.Core.Models.Orders
{
    using System.ComponentModel.DataAnnotations;
    using static GlobalConstants.EntityValidation.OrderEntity;
    public class UserOrderInfoModel
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = null!;
        [Required]
        [MinLength(FirstNameMinLength)]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MinLength(FirstNameMinLength)]
        [MaxLength(FirstNameMaxLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [MinLength(CountryMinLength)]
        [MaxLength(CountryMaxLength)]
        public string Country { get; set; } = null!;

        [Required]
        [MinLength(CityMinLength)]
        [MaxLength(CityMaxLength)]
        public string City { get; set; } = null!;

        public int PostalCode { get; set; }

        [Required]
        [MinLength(AdressMinLength)]
        [MaxLength(AdressMaxLength)]
        public string StreetAdress { get; set; } = null!;

    }
}
