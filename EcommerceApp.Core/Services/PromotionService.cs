namespace EcommerceApp.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using Infrastructure.Data.Models;
    using Contracts;
    using Data;

    public class PromotionService : IPromotionService
    {
        private readonly ApplicationDbContext dbContext;
        public PromotionService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
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
            if (shoes!= null)
            {
                shoes.Promotion = null;
            }


            await dbContext.SaveChangesAsync();
        }
    }
}
