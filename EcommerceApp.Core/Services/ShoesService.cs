﻿namespace EcommerceApp.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using Data;
    using Contracts;
    using Models.Shoes;
    using Models.Pictures;
    using Models.AdminModels.Clothes;
    using Models.AdminModels.Shoes;
    using Models.Brands;
    using Models.Categories;
    using Models.ProductStocks;
    using Models.Promotion;
    using Models.AdminModels.Pictures;
    using Infrastructure.Data.Models;

    public class ShoesService : IShoesService
    {
        private readonly ApplicationDbContext applicationDbContext;
        public ShoesService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<bool> CheckIfShoesExistsByIdAsync(int shoesId)
        {
            return await applicationDbContext.Shoes.AnyAsync(sh => sh.Id == shoesId);
        }

        public async Task EditShoesAsync(EditProductModel model)
        {
            Shoes shoes = await
               applicationDbContext
              .Shoes
              .Include(p => p.ShoesStocks)
              .Include(p => p.Promotion)
              .Include(p => p.Brand)
              .Include(p => p.Category)
              .Include(p => p.Pictures)
              .FirstAsync(cl => cl.Id == model.Id);

            if (model.CategoryId != shoes.CategoryId)
            {
                Category category = await applicationDbContext
                    .Categories.Include(c => c.Shoes).FirstAsync(c => c.Id == model.CategoryId);
                category.Shoes.Remove(shoes);

                shoes.CategoryId = model.CategoryId;
            }
            if (model.BrandId != shoes.BrandId)
            {
                Brand brand = await applicationDbContext
                    .Brands.Include(c => c.Shoes).FirstAsync(c => c.Id == model.CategoryId);
                brand.Shoes.Remove(shoes);

                shoes.BrandId = model.BrandId;
            }

            shoes.Name = model.Name;
            shoes.Description = model.Description;
            shoes.Price = model.Price;

            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ClothesModel>> GetAllShoesAsync()
        {
            return await applicationDbContext.Shoes
                .Select(sh => new ClothesModel()
                {
                    Id = sh.Id,
                    ImgUrls = sh.Pictures.Select(p => new DeletePictureModel() { ImgUrl = p.ImgUrl, Id = p.Id }).ToArray(),
                    StarRating = sh.StarRating,
                    IsArchived = sh.IsArchived,
                    Name = sh.Name,
                    Price = sh.Price
                })
                .ToArrayAsync();
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

        public async Task<ModifyShoesModel> GetShoesToModifyAsync(int shoesId)
        {
            Shoes shoes = await
                applicationDbContext
            .Shoes
               .Include(p => p.ShoesStocks)
               .Include(p => p.Promotion)
               .Include(p => p.Brand)
               .Include(p => p.Category)
               .Include(p => p.Pictures)
               .FirstAsync(cl => cl.Id == shoesId);

            ModifyShoesModel productToGet = new ModifyShoesModel()
            {
                ProductStocks = shoes.ShoesStocks.Select(ps => new ProductStock<double>() { Id = ps.Id, Quantity = ps.Quantity, Size = ps.Size }),
                SelectedBrandId = shoes.BrandId,
                Description = shoes.Description,
                Id = shoes.Id,
                SelectedCategoryId = shoes.CategoryId,
                ImgUrls = shoes.Pictures.Select(p => new DeletePictureModel() { ImgUrl = p.ImgUrl , Id = p.Id }).ToArray(),
                IsArchived = shoes.IsArchived,
                Name = shoes.Name,
                Price = shoes.Price,
                PromotionModel = new PromotionModel() { Id = shoes?.Promotion?.Id, ExpireTime = shoes?.Promotion?.ExpireTime, PercentageDiscount = shoes?.Promotion?.PercantageDiscount },
                StarRating = shoes.StarRating,
            };

            productToGet.Brands = await applicationDbContext.Brands
                .Select(b => new BrandModel() { Id = b.Id, Name = b.Name })
                .ToArrayAsync();

            productToGet.Categories = await applicationDbContext
                .Categories.Select(c => new CategoryModel() { Id = c.Id, Name = c.Name })
                .ToArrayAsync();

            return productToGet;
        }
    }
}
