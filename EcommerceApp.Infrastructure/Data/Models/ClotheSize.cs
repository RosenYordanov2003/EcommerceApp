namespace EcommerceApp.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static EcommerceApp.GlobalConstants.EntityValidation.ClothesSizeEntity;
    public class ClotheSize
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(SizeMaxLength)]
        public string Size { get; set; } = null!;
    }
}
