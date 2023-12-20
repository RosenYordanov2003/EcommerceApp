namespace EcommerceApp.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static EcommerceApp.GlobalConstants.EntityValidation.ReviewEntity;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Review
    {
        [Key]
        public int Id { get; set; } 
        public int StarЕvaluation { get; set; }
        [MaxLength(ContentMaxValue)]
        public string Content { get; set; } = null!;

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        [ForeignKey(nameof(Product))]
        public int? ProductId { get; set; }
        public Product? Product { get; set; }

        [ForeignKey(nameof(Shoes))]
        public int? ShoesId { get; set; }
        public Shoes? Shoes { get; set; }

    }
}
