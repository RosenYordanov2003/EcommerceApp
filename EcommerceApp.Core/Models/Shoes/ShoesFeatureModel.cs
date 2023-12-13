﻿namespace EcommerceApp.Core.Models.Shoes
{
    using Pictures;
    public class ShoesFeatureModel
    {
        public ShoesFeatureModel()
        {
            Pictures = new List<PictureModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int StarRating { get; set; }
        public decimal Price { get; set; }
        public string? Category { get; set; }
        public string SubCategory { get; set; }
        public IEnumerable<PictureModel> Pictures { get; set; }
    }
}
