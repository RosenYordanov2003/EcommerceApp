namespace EcommerceApp.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using Contracts;
    using Data;
    using Infrastructure.Data.Models;
    using Models.UserMessage;
    using Models.AdminModels.UserMessages;
    using Models.Pager;
    using EcommerceApp.Core.Models.TimeDifference;
    using EcommerceApp.Core.Models.Discount;

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

        public async Task<IEnumerable<UserMessageCardModel>> GetUserMessagesAsync(Pager pager)
        {
            var userMessages = dbContext.UserMessages.AsQueryable().OrderBy(m => m.IsResponded);

            var messages = await userMessages
                .Skip((pager.CurrentPage - 1) * pager.PageSize)
                .Take(pager.PageSize)
                .Select(m => new UserMessageCardModel()
                {
                    Message = m.Message,
                    Username = m.User.UserName,
                    Id = m.Id,
                    IsResponded = m.IsResponded,
                    CreatedOn = m.CreatedOn
                })
                .ToArrayAsync();

            foreach (var message in messages)
            {
                message.ElapsedTime = CalculateTimeDifference(message.CreatedOn);
            }

            return messages;
        }

        public async Task MarkMessageAsRespondedByIdAsync(Guid id)
        {
            UserMessage userMessage = await dbContext.UserMessages.FirstAsync(m => m.Id == id);
            userMessage.IsResponded = true;
            await dbContext.SaveChangesAsync();
        }

        public async Task UploadUserMessageAsync(UploadUserMessageModel uploadUserMessageModel)
        {
            UserMessage userMessage = new UserMessage()
            {
                UserId = uploadUserMessageModel.UserId,
                Message = uploadUserMessageModel.Message,
                CreatedOn = DateTime.UtcNow,
            };
            await dbContext.UserMessages.AddAsync(userMessage);
            await dbContext.SaveChangesAsync();
        }
        private string CalculateTimeDifference(DateTime date)
        {
            YearTimeCalculator yearTimeCalculator = new YearTimeCalculator();
            MonthTimeCalculator monthTimeCalculator = new MonthTimeCalculator();
            WeekTimeCalculator weekTimeCalculator = new WeekTimeCalculator();
            DayTimeCalculator dayTimeCalculator = new DayTimeCalculator();
            HourTimeCalculator hourTimeCalculator = new HourTimeCalculator();
            MinutesTimeCalculator minutesTimeCalculator = new MinutesTimeCalculator();

            yearTimeCalculator.SetNextDateTimeCalculator(monthTimeCalculator);
            monthTimeCalculator.SetNextDateTimeCalculator(weekTimeCalculator);
            weekTimeCalculator.SetNextDateTimeCalculator(dayTimeCalculator);
            dayTimeCalculator.SetNextDateTimeCalculator(hourTimeCalculator);
            hourTimeCalculator.SetNextDateTimeCalculator(minutesTimeCalculator);
            minutesTimeCalculator.SetNextDateTimeCalculator(new SecondsTimeCalculator());

            return yearTimeCalculator.CalculateTimeDifeerence(date);
        }
    }
}
