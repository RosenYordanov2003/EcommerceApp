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

    public class ProductService : IProductSevice
    {
        private readonly ApplicationDbContext applicationDbContext;
        public ProductService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task AddProductToUserFavoritesListAsync(UserFavoriteProduct userFavoriteProductmodel)
        {
            if (userFavoriteProductmodel.CategoryName.ToLower() == "shoes")
            {
                UserFavoriteShoes userFavoriteShoes = new UserFavoriteShoes()
                {
                    UserId = userFavoriteProductmodel.UserId,
                    ShoesId = userFavoriteProductmodel.ProductId
                };
                await applicationDbContext.UserFavoriteShoes.AddAsync(userFavoriteShoes);
            }
            else
            {
                UserFavoriteProducts userFavoriteProducts = new UserFavoriteProducts()
                {
                    UserId = userFavoriteProductmodel.UserId,
                    ProductId = userFavoriteProductmodel.ProductId
                };
                await applicationDbContext.UserFavoriteProducts.AddAsync(userFavoriteProducts);
            }
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<bool> CheckIfProductExistsByIdAsync(int productId)
        {
            if (await applicationDbContext.Clothes.AnyAsync(cl => cl.Id == productId))
            {
                return true;
            }
            if (await applicationDbContext.Shoes.AnyAsync(sh => sh.Id == productId))
            {
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<ProductModel>> GetFeaturedClothesAsync()
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
                    CategoryName = c.Category.Name
                })
                .ToArrayAsync();
        }

        public async Task<AllProductsModel> GetProductByGender(string gender)
        {
            gender = gender.ToLower();
            string genderLetter = gender[0].ToString().ToLower();
            AllProductsModel productModel = new AllProductsModel();

            productModel.Products = await applicationDbContext.Clothes
                  .Where(cl => cl.Gender.ToLower() == genderLetter)
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
                      SubCategories = cl.Category.SubCategories.Select(subc => subc.Name).ToList()
                  })
                  .ToListAsync();

            productModel.Shoes = await applicationDbContext.Shoes
                .Where(sh => sh.Gender.ToLower() == gender)
                .Select(sh => new ShoesFilterModel()
                {
                    Id = sh.Id,
                    Name = sh.Name,
                    Pictures = sh.Pictures.Select(p => new PictureModel() { ImgUrl = p.ImgUrl }).Take(2),
                    StarRating = sh.StarRating,
                    Price = sh.Price,
                    SubCategory = sh.SubCategory.Name,
                    CategoryName = sh.Category.Name,
                    Brand = sh.Brand.Name
                })
                .ToListAsync();

            productModel.Brands = await applicationDbContext.Brands.Select(b => new BrandModel()
            {
                Id = b.Id,
                Name = b.Name
            })
            .ToListAsync();

            string letter = gender[0].ToString();

            productModel.Categories = await applicationDbContext.Categories
                 .Where(c => c.Gender.ToLower().IndexOf(letter) > -1)
                 .Select(c => new CategoryModel()
                 {
                     Id = c.Id,
                     Name = c.Name,
                     SubCategories = c.SubCategories.Select(sc => new CategoryModel() { Id = sc.Id, Name = sc.Name })
                 })
                 .ToListAsync();


            return productModel;
        }

        public async Task<ProductInfo<T>> GetProductByIdAsync<T>(int productId, string categoryName, Guid userId)
        {

            if (categoryName.ToLower() != "shoes")
            {
                var productInfo = await applicationDbContext.Clothes.Where(cl => cl.Id == productId).Select(cl => new ProductInfo<T>()
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
                    ProductStocks = cl.ProductStocks.Select(ps => new ProductStock<T>() { Size = (T)(object)ps.Size, Quantity = ps.Quantity, Id = ps.Id }).ToArray(),
                    Reviews = cl.Reviews.Select(r => new ReviewModel() { Content = r.Content, StarEvaluation = r.StarЕvaluation }),
                    IsFavorite = cl.UserFavoriteProducts.Any(uf => uf.ProductId == productId && uf.UserId == userId)
                })
                 .FirstAsync();

                productInfo.RelatedProducts = await applicationDbContext.Clothes
                    .Where(cl => (cl.Name == productInfo.Name || cl.Brand.Name == productInfo.Brand) &&
                     cl.Gender == productInfo.Gender && cl.Id != productInfo.Id && cl.Category.Name == categoryName)
                    .Select(cl => new ProductModel()
                    {
                        Description = cl.Description,
                        CategoryName = cl.Category.Name,
                        StarRating = cl.StarRating,
                        Id = cl.Id,
                        Name = cl.Name,
                        Price = cl.Price,
                        Pictures = cl.Pictures.Select(p => new PictureModel() { ImgUrl = p.ImgUrl }).Take(2).ToArray(),
                    })
                    .OrderByDescending(cl => cl.StarRating)
                    .Take(3)
                    .ToArrayAsync();

                return productInfo;
            }
            else
            {
                var productInfo = await applicationDbContext.Shoes.Where(shoes => shoes.Id == productId).Select(shoes => new ProductInfo<T>()
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
                    ProductStocks = shoes.ShoesStocks.Select(ps => new ProductStock<T> { Size = (T)(object)ps.Size, Quantity = ps.Quantity, Id = ps.Id }).ToArray(),
                    Reviews = shoes.Reviews.Select(r => new ReviewModel() { Content = r.Content, StarEvaluation = r.StarЕvaluation }),
                    IsFavorite = shoes.UserFavoriteShoes.Any(uf => uf.ShoesId == productId && uf.UserId == userId)

                })
                .FirstAsync();

                productInfo.RelatedProducts = await applicationDbContext.Shoes
                  .Where(sh => (sh.Name == productInfo.Name || sh.Brand.Name == productInfo.Brand) &&
                  sh.Gender == productInfo.Gender && sh.Id != productInfo.Id && sh.Category.Name == categoryName)
                  .Select(cl => new ProductModel()
                  {
                      Description = cl.Description,
                      CategoryName = cl.Category.Name,
                      StarRating = cl.StarRating,
                      Id = cl.Id,
                      Name = cl.Name,
                      Price = cl.Price,
                      Pictures = cl.Pictures.Select(p => new PictureModel() { ImgUrl = p.ImgUrl }).Take(2).ToArray(),

                  })
                  .OrderByDescending(sh => sh.StarRating)
                  .Take(6)
                  .ToArrayAsync();

                return productInfo;
            }
        }

        public async Task<ICollection<GetUserFavoriteProductModel>> GetUserFavoriteProductsAsync(Guid userId)
        {
            ICollection<GetUserFavoriteProductModel> getUserFavoriteProductModels =
                 await applicationDbContext.UserFavoriteProducts
                 .Where(uf => uf.UserId == userId)
                 .Select(uf => new GetUserFavoriteProductModel()
                 {
                     ImgUrl = uf.Product.Pictures.FirstOrDefault() == null ? "": uf.Product.Pictures.FirstOrDefault().ImgUrl,
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

        public async Task RemoveProductFromUserFavoriteListAsync(UserFavoriteProduct userFavoriteProductmodel)
        {
            if (userFavoriteProductmodel.CategoryName.ToLower() == "shoes")
            {
                UserFavoriteShoes userFavoriteShoesToDelete = await applicationDbContext
                    .UserFavoriteShoes.FirstAsync(ufs => ufs.UserId == userFavoriteProductmodel.UserId && ufs.ShoesId == userFavoriteProductmodel.ProductId);

                applicationDbContext.UserFavoriteShoes.Remove(userFavoriteShoesToDelete);
            }
            else
            {
                UserFavoriteProducts userFavoriteProductsToDelete = await applicationDbContext
                  .UserFavoriteProducts.FirstAsync(ufs => ufs.UserId == userFavoriteProductmodel.UserId && ufs.ProductId == userFavoriteProductmodel.ProductId);

                applicationDbContext.UserFavoriteProducts.Remove(userFavoriteProductsToDelete);
            }
            await applicationDbContext.SaveChangesAsync();
        }
    }
}
