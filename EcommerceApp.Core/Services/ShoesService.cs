﻿namespace EcommerceApp.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using EcommerceApp.Data;
    using Contracts;
    using Models.Shoes;
    using Models.Pictures;

    public class ShoesService : IShoesService
    {
        private readonly ApplicationDbContext applicationDbContext;
        public ShoesService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<ShoesFeatureModel>> GetFeaturedShoesAsync(Guid? userId)
        {
            return await applicationDbContext.Shoes
                .Where(s => s.IsFeatured)
                .Select(s => new ShoesFeatureModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    StarRating = s.StarRating,
                    Price = s.Price,
                    Pictures = s.Pictures.Select(p => new PictureModel() { ImgUrl = p.ImgUrl }).Take(2),
                    CategoryName = s.Category.Name,
                    IsFavorite = userId.HasValue ? applicationDbContext.UserFavoriteShoes.
                    Any(us => us.UserId == userId && us.ShoesId == s.Id) : false,
                })
                .ToArrayAsync();
        }
    }
}
