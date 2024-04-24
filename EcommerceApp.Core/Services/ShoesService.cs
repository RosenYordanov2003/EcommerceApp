namespace EcommerceApp.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using Data;
    using Contracts;
    using Models.Pictures;
    using Models.AdminModels.Clothes;
    using Models.AdminModels.Shoes;
    using Models.Brands;
    using Models.Categories;
    using Models.ProductStocks;
    using Models.Promotion;
    using Models.AdminModels.Pictures;
    using Models.Pager;
    using Infrastructure.Data.Models;
    using Core.Models.Products;
    using Core.Models.Review;

    public class ShoesService : IShoesService
    {
        private readonly ApplicationDbContext applicationDbContext;
        public ShoesService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task AddShoesToUserFavoriteProductsAsync(UserFavoriteProductModel userFavoriteProductModel)
        {
            UserFavoriteShoes userFavoriteProducts = new UserFavoriteShoes()
            {
                UserId = userFavoriteProductModel.UserId,
                ShoesId = userFavoriteProductModel.ProductId
            };
            await applicationDbContext.UserFavoriteShoes.AddAsync(userFavoriteProducts);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task ArchiveShoesAsync(int shoesId)
        {
            Shoes shoes = await applicationDbContext.Shoes.FirstAsync(sh => sh.Id == shoesId);
            shoes.IsArchived = true;
            await applicationDbContext.SaveChangesAsync();
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

        public async Task<IEnumerable<ClothesModel>> GetAllShoesAsync(Pager pager)
        {
            var shoes = applicationDbContext.Shoes.AsQueryable()
                .Skip((pager.CurrentPage - 1) * pager.PageSize)
                .Take(pager.PageSize);

            return await shoes
                .Select(sh => new ClothesModel()
                {
                    Id = sh.Id,
                    ImgUrls = sh.Pictures.Select(p => new AdminPictureModel() { ImgUrl = p.ImgUrl, Id = p.Id }).ToArray(),
                    StarRating = sh.StarRating,
                    IsArchived = sh.IsArchived,
                    Name = sh.Name,
                    Price = sh.Price
                })
                .ToArrayAsync();
        }

        public async Task<int> GetAllShoesCountAsync()
        {
           return await applicationDbContext.Shoes.CountAsync();
        }

        public async Task<IEnumerable<ProductFeatureModel>> GetFeaturedShoesAsync(Guid? userId)
        {
            return await applicationDbContext.Shoes
                .Where(s => s.IsFeatured)
                .Select(s => new ProductFeatureModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    StarRating = s.StarRating,
                    Price = s.Price,
                    Pictures = s.Pictures.Select(p => new PictureModel() { ImgUrl = p.ImgUrl }).Take(2),
                    CategoryName = s.Category.Name,
                    IsFavorite = userId.HasValue ? applicationDbContext.UserFavoriteShoes.
                    Any(us => us.UserId == userId && us.ShoesId == s.Id) : false,
                    DicountPercentage = s.Promotion != null && s.Promotion.ExpireTime >= DateTime.UtcNow ? s.Promotion.PercantageDiscount : 0,
                })
                .ToArrayAsync();
        }

        public async Task<ProductInfoModel<double>> GetProductByIdAsync(int productId, Guid? userId)
        {
            var productInfo = await applicationDbContext.Shoes.Where(shoes => shoes.Id == productId)
                    .Select(shoes => new ProductInfoModel<double>()
                    {
                        Id = shoes.Id,
                        Description = shoes.Description,
                        Name = shoes.Name,
                        Price = shoes.Price,
                        StarRating = shoes.StarRating,
                        Brand = shoes.Brand.Name,
                        CategoryName = shoes.Category.Name,
                        Gender = shoes.Gender,
                        Pictures = shoes.Pictures.Select(p => new PictureModel() { ImgUrl = p.ImgUrl }).ToArray(),
                        ProductStocks = shoes.ShoesStocks.Select(ps => new ProductStock<double> { Size = ps.Size, Quantity = ps.Quantity, Id = ps.Id }).ToArray(),
                        Reviews = shoes.Reviews.Select(r => new ReviewModel() { Content = r.Content, StarEvaluation = r.StarЕvaluation }),
                        IsFavorite = userId.HasValue ? shoes.UserFavoriteShoes.Any(uf => uf.ShoesId == productId && uf.UserId == userId) : false,
                        IsAvalilable = shoes.ShoesStocks.Any(ps => ps.Quantity > 0),
                        DicountPercentage = shoes.Promotion != null && shoes.Promotion.ExpireTime >= DateTime.UtcNow ? shoes.Promotion.PercantageDiscount : 0,
                        TotalMilisecondsDifference = shoes.Promotion == null ? 0 : (long)(shoes.Promotion.ExpireTime - DateTime.UtcNow).TotalMilliseconds

                    })
                .FirstAsync();

            productInfo.RelatedProducts = await applicationDbContext.Shoes
              .Where(sh => (sh.Name == productInfo.Name || sh.Brand.Name == productInfo.Brand) &&
              sh.Gender == productInfo.Gender && sh.Id != productInfo.Id && sh.Category.Name == productInfo.CategoryName)
              .Select(cl => new ProductModel()
              {
                  Description = cl.Description,
                  CategoryName = cl.Category.Name,
                  StarRating = cl.StarRating,
                  Id = cl.Id,
                  Name = cl.Name,
                  Price = cl.Price,
                  Pictures = cl.Pictures.Select(p => new PictureModel() { ImgUrl = p.ImgUrl }).Take(2).ToArray(),
                  IsFavorite = userId.HasValue ? cl.UserFavoriteShoes.Any(uf => uf.ShoesId == cl.Id && uf.UserId == userId) : false

              })
              .OrderByDescending(sh => sh.StarRating)
              .Take(6)
              .ToArrayAsync();

            return productInfo;
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
                ImgUrls = shoes.Pictures.Select(p => new AdminPictureModel() { ImgUrl = p.ImgUrl , Id = p.Id }).ToArray(),
                IsArchived = shoes.IsArchived,
                Name = shoes.Name,
                Price = shoes.Price,
                IsFeatured = shoes.IsFeatured,
                PromotionModel = new PromotionModel() { Id = shoes?.Promotion?.Id, ExpireTime = shoes?.Promotion?.ExpireTime, PercentageDiscount = shoes?.Promotion?.PercantageDiscount },
                StarRating = shoes.StarRating,
                Gender = shoes.Gender,
            };

            productToGet.Brands = await applicationDbContext.Brands
                .Select(b => new BrandModel() { Id = b.Id, Name = b.Name })
                .ToArrayAsync();

            productToGet.Categories = await applicationDbContext
                .Categories.Select(c => new CategoryModel() { Id = c.Id, Name = c.Name })
                .ToArrayAsync();

            return productToGet;
        }

        public async Task RemoveFeaturedShoesByIdAsync(int shoesId)
        {
            Shoes shoes = await applicationDbContext.Shoes.FirstAsync(sh => sh.Id == shoesId);
            shoes.IsFeatured = false;

            await applicationDbContext.SaveChangesAsync();
        }

        public async Task RemoveShoesFromUserFavoriteProductsAsync(UserFavoriteProductModel userFavoriteProductModel)
        {
            UserFavoriteShoes userFavoriteShoesToDelete = await applicationDbContext
                   .UserFavoriteShoes.FirstAsync(ufs => ufs.UserId == userFavoriteProductModel.UserId && ufs.ShoesId == userFavoriteProductModel.ProductId);

            applicationDbContext.UserFavoriteShoes.Remove(userFavoriteShoesToDelete);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task RestoreShoesAsync(int shoesId)
        {
            Shoes shoes = await applicationDbContext.Shoes.FirstAsync(sh => sh.Id == shoesId);
            shoes.IsArchived = false;
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task SetFeatureShoesByIdAsync(int shoesId)
        {
            Shoes shoes = await applicationDbContext.Shoes.FirstAsync(sh => sh.Id == shoesId);
            shoes.IsFeatured = true;

            await applicationDbContext.SaveChangesAsync();
        }
    }
}
