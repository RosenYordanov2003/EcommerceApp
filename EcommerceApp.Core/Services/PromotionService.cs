namespace EcommerceApp.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using Infrastructure.Data.Models;
    using Contracts;
    using Data;
    using Models.AdminModels.Promotion;

    public class PromotionService : IPromotionService
    {
        private readonly ApplicationDbContext dbContext;

        public PromotionService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task ApplyPromotionAsync(AddPromotionModel addPromotionModel)
        {
            Promotion promotion = new Promotion()
            {
                ExpireTime = addPromotionModel.ExpirationTime,
                PercantageDiscount = addPromotionModel.Percentages,
            };

            promotion.ProductId = addPromotionModel.ProductCategory != "Shoes" ? addPromotionModel.ProductId : null;
            promotion.ShoesId = addPromotionModel.ProductCategory == "Shoes" ? addPromotionModel.ProductId : null;

            if (promotion.ShoesId.HasValue)
            {
                Shoes shoes = await dbContext.Shoes.FirstAsync(sh => sh.Id == promotion.ShoesId);
                await RemoveOldPromotions(addPromotionModel);
                shoes.Promotion = promotion;
            }
            else
            {
                Product product = await dbContext.Clothes.FirstAsync(p => p.Id == promotion.ProductId);
                await RemoveOldPromotions(addPromotionModel);
                product.Promotion = promotion;
            }

            await dbContext.Promotions.AddAsync(promotion);
            await dbContext.SaveChangesAsync();
        }

        private async Task RemoveOldPromotions(AddPromotionModel addPromotionModel)
        {
            if (addPromotionModel.ProductCategory == "Shoes")
            {
                var promoions = await dbContext.Promotions.Where(p => p.ShoesId == addPromotionModel.ProductId).ToArrayAsync();
                foreach (var item in promoions)
                {
                    dbContext.Promotions.Remove(item);
                }
            }
            else
            {
                var promoions = await dbContext.Promotions.Where(p => p.ProductId == addPromotionModel.ProductId).ToArrayAsync();
                foreach (var item in promoions)
                {
                    dbContext.Promotions.Remove(item);
                }
            }
            await dbContext.SaveChangesAsync();

        }

        public async Task<bool> CheckIfPromotionExistsByIdAsync(Guid id)
        {
            return await dbContext.Promotions.AnyAsync(p => p.Id == id);
        }

        public async Task RemovePromotionAsync(Guid id)
        {
            Promotion promotion = await dbContext.Promotions
                .Include(p => p.Product)
                .Include(p => p.Shoes)
                .FirstAsync(p => p.Id == id);

            dbContext.Promotions.Remove(promotion);

            Product product = promotion.Product;
            Shoes shoes = promotion.Shoes;

            if (product != null)
            {
                product.Promotion = null;
            }
            if (shoes != null)
            {
                shoes.Promotion = null;
            }


            await dbContext.SaveChangesAsync();
        }

        public async Task ClearExpiredPrmotionsAsync()
        {
            List<Promotion> expiredPromotions = await dbContext.Promotions.Where(p => p.ExpireTime < DateTime.UtcNow).ToListAsync();

            if (expiredPromotions.Count == 0)
            {
                return;
            }
            foreach (var promotion in expiredPromotions)
            {
                if (promotion.ShoesId.HasValue)
                {
                    Shoes shoes = await dbContext.Shoes.Include(s => s.Promotion).FirstAsync(sh => sh.Id == promotion.ShoesId);
                    shoes.Promotion = null;
                    shoes.PromotionId = null;
                    continue;
                }
                if (promotion.ProductId.HasValue)
                {
                    Product product = await dbContext.Clothes.Include(p => p.Promotion).FirstAsync(sh => sh.Id == promotion.ProductId);
                    product.Promotion = null;
                    product.PromotionId = null;
                }
            }
            await dbContext.SaveChangesAsync();
            dbContext.Promotions.RemoveRange(expiredPromotions);
            await dbContext.SaveChangesAsync();
        }
    }
}
