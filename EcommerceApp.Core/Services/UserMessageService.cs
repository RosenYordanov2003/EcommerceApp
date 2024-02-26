namespace EcommerceApp.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using Contracts;
    using Data;
    using Infrastructure.Data.Models;
    using Models.UserMessage;
    using System.Collections.Generic;
    using EcommerceApp.Core.Models.AdminModels.UserMessages;

    public class UserMessageService : IUserMessageService
    {
        private readonly ApplicationDbContext dbContext;
        public UserMessageService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> GetMessageCountAsync()
        {
            return await dbContext.UserMessages.CountAsync();
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
