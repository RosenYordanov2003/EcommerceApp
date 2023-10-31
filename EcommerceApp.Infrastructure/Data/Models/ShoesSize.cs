namespace EcommerceApp.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class ShoesSize
    {
        [Key]
        public int Id { get; set; }
        public double Size { get; set; }
    }
}
