namespace EcommerceApp.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using Contracts;
    using System.Collections.Generic;
    using Data;
    using Infrastructure.Data.Models;
    using Models.UserMessage;
    using Models.AdminModels.UserMessages;

    public class UserMessageService : IUserMessageService
    {
        private readonly ApplicationDbContext dbContext;
        public UserMessageService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<bool> CheckIfMessageExistsByIdAsync(Guid id)
        {
            return dbContext.UserMessages.AnyAsync(m => m.Id == id);
        }

        public async Task DeleteMessageAsync(Guid id)
        {
            UserMessage userMessageToDelete = await dbContext.UserMessages.FirstAsync(m => m.Id == id);
            dbContext.UserMessages.Remove(userMessageToDelete);
            await dbContext.SaveChangesAsync();
        }

        public async Task<int> GetMessageCountAsync()
        {
            return await dbContext.UserMessages.CountAsync();
        }

        public async Task<string> GetUserEmailByMessageIdAsync(Guid id)
        {
           return await dbContext.UserMessages
               .Where(m => m.Id == id)
               .Select(m => m.User.Email)
               .FirstAsync();
        }

        public async Task<IEnumerable<UserMessageCardModel>> GetUserMessagesAsync()
        {
            return await
                 dbContext
                .UserMessages
                .Select(m => new UserMessageCardModel()
                {
                    Message = m.Message,
                    Username = m.User.UserName,
                    Id = m.Id
                })
                .ToArrayAsync();
        }

        public async Task UploadUserMessageAsync(UploadUserMessageModel uploadUserMessageModel)
        {
            UserMessage userMessage = new UserMessage()
            {
                UserId = uploadUserMessageModel.UserId,
                Message = uploadUserMessageModel.Message
            };
            await dbContext.UserMessages.AddAsync(userMessage);
            await dbContext.SaveChangesAsync();
        }
    }
}
