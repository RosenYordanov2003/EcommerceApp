using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApp.Infrastructure.Data.Models
{
    public class ShoesStock
    {
        public int Id { get; set; }
        public double Size { get; set; }
        public int Quantity { get; set; }

        [ForeignKey(nameof(Shoes))]
        public int ShoesId { get; set; }

        public Shoes Shoes { get; set; } = null!;
    }
}
