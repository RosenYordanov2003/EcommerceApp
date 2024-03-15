namespace EcommerceApp.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using Contracts;
    using Models.Pictures;
    using Data;
    using Models.Products;
    using Core.Models.Shoes;
    using Models.Brands;
    using Models.Categories;
    using Models.ProductStocks;
    using Models.Review;
    using Infrastructure.Data.Models;
    using Models.AdminModels.Clothes;
    using Models.Promotion;
    using Models.AdminModels.Pictures;
    using Core.Models.Pager;
    using Microsoft.EntityFrameworkCore.Infrastructure;

    public class ProductService : IProductSevice
    {
        private readonly ApplicationDbContext applicationDbContext;
        public ProductService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task AddProductToUserFavoritesListAsync(UserFavoriteProduct userFavoriteProductmodel)
        {
            UserFavoriteProducts userFavoriteProducts = new UserFavoriteProducts()
            {
                UserId = userFavoriteProductmodel.UserId,
                ProductId = userFavoriteProductmodel.ProductId
            };
            await applicationDbContext.UserFavoriteProducts.AddAsync(userFavoriteProducts);

            await applicationDbContext.SaveChangesAsync();
        }
        //TODO:

        public async Task<bool> CheckIfProductExistsByIdAsync(int productId)
        {
            if (await applicationDbContext.Clothes.AnyAsync(cl => cl.Id == productId) || await applicationDbContext.Shoes
                .AnyAsync(sh => sh.Id == productId))
            {
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<ProductModel>> GetFeaturedClothesAsync(Guid? userId)
        {
            return await applicationDbContext.Clothes
                .Where(c => c.IsFeatured)
                .Select(c => new ProductModel()
                {
                    Id = c.Id,
                    Description = c.Description,
                    Name = c.Name,
                    Price = c.Price,
                    StarRating = c.StarRating,
                    Pictures = c.Pictures.Select(p => new PictureModel() { ImgUrl = p.ImgUrl }).Take(2),
                    CategoryName = c.Category.Name,
                    DicountPercentage = c.Promotion == null ? 0 : c.Promotion.PercantageDiscount,
                    IsFavorite = userId.HasValue ? applicationDbContext.UserFavoriteProducts.
                    Any(us => us.UserId == userId && us.ProductId == c.Id) : false,
                })
                .ToArrayAsync();
        }

        public async Task<AllProductsModel> GetProductByGender(string gender, Guid? userId)
        {
            gender = gender.ToLower();
            AllProductsModel productModel = new AllProductsModel();

            productModel.Products = await applicationDbContext.Clothes
                  .Where(cl => (cl.Gender.ToLower() == gender) || (cl.Gender == "Unisex"))
                  .Select(cl => new FilterProductModel()
                  {
                      Id = cl.Id,
                      Name = cl.Name,
                      Description = cl.Description,
                      Pictures = cl.Pictures.Select(p => new PictureModel() { ImgUrl = p.ImgUrl }).Take(2),
                      Price = cl.Price,
                      StarRating = cl.StarRating,
                      CategoryName = cl.Category.Name,
                      Brand = cl.Brand.Name,
                      DicountPercentage = cl.Promotion == null ? 0 : cl.Promotion.PercantageDiscount,
                      IsFavorite = userId.HasValue ? cl.UserFavoriteProducts.Any(ufcl => ufcl.UserId == userId && ufcl.ProductId == cl.Id) : false,
                  })
                  .ToListAsync();

            productModel.Shoes = await applicationDbContext.Shoes
                .Where(sh => (sh.Gender.ToLower() == gender) || (sh.Gender == "Unisex"))
                .Select(sh => new ShoesFilterModel()
                {
                    Id = sh.Id,
                    Name = sh.Name,
                    Pictures = sh.Pictures.Select(p => new PictureModel() { ImgUrl = p.ImgUrl }).Take(2),
                    StarRating = sh.StarRating,
                    Price = sh.Price,
                    CategoryName = sh.Category.Name,
                    Brand = sh.Brand.Name,
                    DicountPercentage = sh.Promotion == null ? 0 : sh.Promotion.PercantageDiscount,
                    IsFavorite = userId.HasValue ? sh.UserFavoriteShoes.Any(ufsh => ufsh.UserId == userId && ufsh.ShoesId == sh.Id) : false,
                })
                .ToListAsync();

            productModel.Brands = await applicationDbContext.Brands.Select(b => new BrandModel()
            {
                Id = b.Id,
                Name = b.Name
            })
            .ToListAsync();

            productModel.Categories = await applicationDbContext.Categories
                 .Where(c => (c.Gender.ToLower() == gender) || (c.Gender == "Unisex"))
                 .Select(c => new CategoryModel()
                 {
                     Id = c.Id,
                     Name = c.Name,
                 })
                 .ToListAsync();

            return productModel;
        }

        public async Task<ProductInfo<string>> GetProductByIdAsync(int productId, Guid? userId)
        {
            var productInfo = await applicationDbContext.Clothes.Where(cl => cl.Id == productId).Select(cl => new ProductInfo<string>()
            {
                Id = cl.Id,
                Description = cl.Description,
                Name = cl.Name,
                Price = cl.Price,
                Gender = cl.Gender,
                StarRating = cl.StarRating,
                Brand = cl.Brand.Name,
                CategoryName = cl.Category.Name,
                Pictures = cl.Pictures.Select(p => new PictureModel() { ImgUrl = p.ImgUrl }).ToArray(),
                ProductStocks = cl.ProductStocks.Select(ps => new ProductStock<string>() { Size = ps.Size, Quantity = ps.Quantity, Id = ps.Id }).ToArray(),
                Reviews = cl.Reviews.Select(r => new ReviewModel() { Content = r.Content, StarEvaluation = r.StarЕvaluation }),
                IsFavorite = userId.HasValue ? cl.UserFavoriteProducts.Any(uf => uf.ProductId == productId && uf.UserId == userId) : false,
                IsAvalilable = cl.ProductStocks.Any(ps => ps.Quantity > 0),
                DicountPercentage = cl.Promotion == null ? 0 : cl.Promotion.PercantageDiscount,
                TotalMilisecondsDifference = cl.Promotion == null ? 0 : (long)(cl.Promotion.ExpireTime - DateTime.UtcNow).TotalMilliseconds
            })
             .FirstAsync();

            productInfo.RelatedProducts = await applicationDbContext.Clothes
                .Where(cl => (cl.Name == productInfo.Name || cl.Brand.Name == productInfo.Brand) &&
                 cl.Gender == productInfo.Gender && cl.Id != productInfo.Id && cl.Category.Name == productInfo.CategoryName)
                .Select(cl => new ProductModel()
                {
                    Description = cl.Description,
                    CategoryName = cl.Category.Name,
                    StarRating = cl.StarRating,
                    Id = cl.Id,
                    Name = cl.Name,
                    Price = cl.Price,
                    Pictures = cl.Pictures.Select(p => new PictureModel() { ImgUrl = p.ImgUrl }).Take(2).ToArray(),
                    IsFavorite = userId.HasValue ? cl.UserFavoriteProducts.Any(uf => uf.ProductId == cl.Id && uf.UserId == userId) : false,
                })
                .OrderByDescending(cl => cl.StarRating)
                .Take(3)
                .ToArrayAsync();

            return productInfo;
        }

        public async Task<ICollection<GetUserFavoriteProductModel>> GetUserFavoriteProductsAsync(Guid userId)
        {
            ICollection<GetUserFavoriteProductModel> getUserFavoriteProductModels =
                 await applicationDbContext.UserFavoriteProducts
                 .Where(uf => uf.UserId == userId)
                 .Select(uf => new GetUserFavoriteProductModel()
                 {
                     ImgUrl = uf.Product.Pictures.FirstOrDefault() == null ? "" : uf.Product.Pictures.FirstOrDefault().ImgUrl,
                     ProductId = uf.ProductId,
                     ProductName = uf.Product.Name,
                     CategoryName = uf.Product.Category.Name
                 }).ToArrayAsync();

            ICollection<GetUserFavoriteProductModel> getUserFavoriteShoes =
                await applicationDbContext.UserFavoriteShoes
                .Where(uf => uf.UserId == userId)
                .Select(uf => new GetUserFavoriteProductModel()
                {
                    ImgUrl = uf.Shoes.Pictures.FirstOrDefault() == null ? "" : uf.Shoes.Pictures.FirstOrDefault().ImgUrl,
                    ProductId = uf.ShoesId,
                    ProductName = uf.Shoes.Name,
                    CategoryName = uf.Shoes.Category.Name
                }).ToArrayAsync();

            List<GetUserFavoriteProductModel> favoriteProducts = new List<GetUserFavoriteProductModel>();

            favoriteProducts.AddRange(getUserFavoriteProductModels);
            favoriteProducts.AddRange(getUserFavoriteShoes);

            return favoriteProducts;
        }

        public async Task<IEnumerable<ClothesModel>> LoadAllClothesAsync(Pager pager)
        {

            var clothes = applicationDbContext.Clothes.
            AsQueryable().
            Skip((pager.CurrentPage - 1) * pager.PageSize).
            Take(pager.PageSize);

            return await clothes
               .Select(cl => new ClothesModel()
               {
                   Id = cl.Id,
                   Name = cl.Name,
                   Price = cl.Price,
                   StarRating = cl.StarRating,
                   ImgUrls = cl.Pictures.Select(x => new AdminPictureModel() { ImgUrl = x.ImgUrl, Id = x.Id }).ToArray()
               })
               .ToArrayAsync();
        }

        public async Task<IEnumerable<ProductFeatureModel>> LoadUserFavoriteProductsAsync(Guid userId)
        {
            IEnumerable<ProductFeatureModel> shoes = await applicationDbContext.UserFavoriteShoes
                 .Where(fsh => fsh.UserId == userId)
                 .Select(fsh => new ProductFeatureModel()
                 {
                     Id = fsh.ShoesId,
                     Pictures = fsh.Shoes.Pictures.Select(p => new PictureModel() { ImgUrl = p.ImgUrl }).ToArray(),
                     CategoryName = fsh.Shoes.Category.Name,
                     IsFavorite = true,
                     Name = fsh.Shoes.Name,
                     Price = fsh.Shoes.Price,
                     StarRating = fsh.Shoes.StarRating

                 })
                 .ToArrayAsync();


            IEnumerable<ProductFeatureModel> clothes = await applicationDbContext.UserFavoriteProducts
           .Where(fsh => fsh.UserId == userId)
           .Select(fp => new ProductFeatureModel()
           {
               Id = fp.ProductId,
               Pictures = fp.Product.Pictures.Select(p => new PictureModel() { ImgUrl = p.ImgUrl }).ToArray(),
               CategoryName = fp.Product.Category.Name,
               IsFavorite = true,
               Name = fp.Product.Name,
               Price = fp.Product.Price,
               StarRating = fp.Product.StarRating

           })
           .ToArrayAsync();

            List<ProductFeatureModel> result = new List<ProductFeatureModel>();

            result.AddRange(clothes);
            result.AddRange(shoes);

            return result;
        }

        public async Task RemoveProductFromUserFavoriteListAsync(UserFavoriteProduct userFavoriteProductModel)
        {

            UserFavoriteProducts userFavoriteProductsToDelete = await applicationDbContext
              .UserFavoriteProducts.FirstAsync(ufs => ufs.UserId == userFavoriteProductModel.UserId && ufs.ProductId == userFavoriteProductModel.ProductId);

            applicationDbContext.UserFavoriteProducts.Remove(userFavoriteProductsToDelete);
            await applicationDbContext.SaveChangesAsync();
        }
        public async Task<ModifyClothesModel> GetProductToModifyAsync(int productId)
        {
            Product product = await
                 applicationDbContext
                .Clothes
                .Include(p => p.ProductStocks)
                .Include(p => p.Promotion)
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.Pictures)
                .FirstAsync(cl => cl.Id == productId);

            ModifyClothesModel productToGet = new ModifyClothesModel()
            {
                ProductStocks = product.ProductStocks.Select(ps => new ProductStock<string>() { Id = ps.Id, Quantity = ps.Quantity, Size = ps.Size }),
                SelectedBrandId = product.BrandId,
                Description = product.Description,
                Id = product.Id,
                SelectedCategoryId = product.CategoryId,
                ImgUrls = product.Pictures.Select(p => new AdminPictureModel() { ImgUrl = p.ImgUrl, Id = p.Id }).ToArray(),
                IsArchived = product.IsArchived,
                Name = product.Name,
                Price = product.Price,
                PromotionModel = new PromotionModel() { Id = product?.Promotion?.Id, ExpireTime = product?.Promotion?.ExpireTime, PercentageDiscount = product?.Promotion?.PercantageDiscount },
                StarRating = product.StarRating,
                IsFeatured = product.IsFeatured,
                Gender = product.Gender,
            };

            productToGet.Brands = await applicationDbContext.Brands
                .Select(b => new BrandModel() { Id = b.Id, Name = b.Name })
                .ToArrayAsync();

            productToGet.Categories = await applicationDbContext
                .Categories.Select(c => new CategoryModel() { Id = c.Id, Name = c.Name })
                .ToArrayAsync();

            return productToGet;
        }

        public async Task EditProductAsync(EditProductModel model)
        {
            Product product = await
                applicationDbContext
               .Clothes
               .Include(p => p.ProductStocks)
               .Include(p => p.Promotion)
               .Include(p => p.Brand)
               .Include(p => p.Category)
               .Include(p => p.Pictures)
               .FirstAsync(cl => cl.Id == model.Id);

            if (model.CategoryId != product.CategoryId)
            {
                Category category = await applicationDbContext
                    .Categories.Include(c => c.Clothes).FirstAsync(c => c.Id == model.CategoryId);
                category.Clothes.Remove(product);

                product.CategoryId = model.CategoryId;
            }
            if (model.BrandId != product.BrandId)
            {
                Brand brand = await applicationDbContext
                    .Brands.Include(c => c.Clothes).FirstAsync(c => c.Id == model.CategoryId);
                brand.Clothes.Remove(product);

                product.BrandId = model.BrandId;
            }

            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;

            await applicationDbContext.SaveChangesAsync();
        }

        public async Task ArchiveProductAsync(int productId)
        {
            Product product = await applicationDbContext.Clothes.FirstAsync(cl => cl.Id == productId);
            product.IsArchived = true;

            await applicationDbContext.SaveChangesAsync();
        }

        public async Task RestoreProductAsync(int productId)
        {
            Product product = await applicationDbContext.Clothes.FirstAsync(cl => cl.Id == productId);
            product.IsArchived = false;

            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<int> CreateProductAsync(CreateProductModel model)
        {
            if (model.CategoryId == 9)
            {
                Shoes shoes = new Shoes()
                {
                    BrandId = model.BrandId,
                    CategoryId = model.CategoryId,
                    Description = model.Description,
                    Gender = model.Gender,
                    IsArchived = false,
                    IsFeatured = false,
                    Price = model.Price,
                    Name = model.Name,
                    StarRating = model.StarRating,
                };
                await applicationDbContext.Shoes.AddAsync(shoes);
                await applicationDbContext.SaveChangesAsync();

                return shoes.Id;
            }
            Product product = new Product()
            {
                BrandId = model.BrandId,
                CategoryId = model.CategoryId,
                Description = model.Description == null ? "" : model.Description,
                Gender = model.Gender,
                IsArchived = false,
                IsFeatured = false,
                Price = model.Price,
                Name = model.Name,
                StarRating = model.StarRating,
            };
            await applicationDbContext.Clothes.AddAsync(product);
            await applicationDbContext.SaveChangesAsync();

            return product.Id;
        }

        public async Task SetProductToBeFeaturedByIdAsync(int productId)
        {
            Product product = await applicationDbContext.Clothes.FirstAsync(cl => cl.Id == productId);
            product.IsFeatured = true;
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task RemoveProductFromBeFeaturedProductsByIdAsync(int productId)
        {
            Product product = await applicationDbContext.Clothes.FirstAsync(cl => cl.Id == productId);
            product.IsFeatured = false;
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<int> GetAllClothesCountAsync()
        {
            return await applicationDbContext.Clothes.CountAsync();
        }
    }
}
