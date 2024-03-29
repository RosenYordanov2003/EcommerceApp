﻿namespace EcommerceApp.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static GlobalConstants.EntityValidation.ReviewEntity;

    public class Review
    {
        [Key]
        public int Id { get; set; } 
        public int StarЕvaluation { get; set; }
        [MaxLength(ContentMaxValue)]
        public string Content { get; set; } = null!;
        [MaxLength(SubjectMaxValue)]
        public string Subject { get; set; } = null!;

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        [ForeignKey(nameof(Product))]
        public int? ProductId { get; set; }
        public Product? Product { get; set; }

        [ForeignKey(nameof(Shoes))]
        public int? ShoesId { get; set; }
        public Shoes? Shoes { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
