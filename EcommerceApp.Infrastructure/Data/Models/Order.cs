namespace EcommerceApp.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static GlobalConstants.EntityValidation.OrderEntity;
    public class Order
    {
        public Order()
        {
            ProductCartEntities = new List<ProductOrderEntity>();
            ShoesCartEntities = new List<ShoesOrderEntity>();
        }
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public ICollection<ProductOrderEntity> ProductCartEntities { get; set; }
        public ICollection<ShoesOrderEntity> ShoesCartEntities { get; set; }
        public DateTime FinishedOn { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        [Required]
        [MaxLength(ShippingMethodMaxLength)]
        public string ShippingMethod { get; set; } = null!;
        public decimal ShippingPrice { get; set; }
        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;
        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string LastName { get; set; } = null!;
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        [MaxLength(AdressMaxLength)]
        public string Adress { get; set; } = null!;
        public int PostalCode { get; set; }
        [Required]
        [MaxLength(CountryMaxLength)]
        public string Country { get; set; } = null!;
        [Required]
        [MaxLength(CityMaxLength)]
        public string City { get; set; } = null!;
    }
}
