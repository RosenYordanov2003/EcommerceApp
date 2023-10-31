namespace EcommerceApp.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class ClotheSize
    {
        public int Id { get; set; }
        [Required]
        public string Size { get; set; } = null!;
    }
}
