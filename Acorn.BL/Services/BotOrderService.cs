using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acorn.BL.Models;
using Acorn.BL.RepositoriesInterfaces;
using Acorn.BL.Validators;

namespace Acorn.BL.Services
{
    public class BotOrderService : IBotOrderService
    {
        private readonly IBotOrdersRepository _botOrdersRepository;

        public BotOrderService(IBotOrdersRepository botOrdersRepository)
        {
            _botOrdersRepository = botOrdersRepository;
        }

        public async Task CreateNewBotOrderAsync(BotOrder botOrder)
        {
            await _botOrdersRepository.AddBotOrderAsync(botOrder);
        }

        public async Task DeleteBotOrderAsync(long botId)
        {
            await _botOrdersRepository.DeleteBotOrderAsync(botId);
        }

        public async Task<IEnumerable<BotOrder>> GetAllBotOrdersAsync()
        {
            return await _botOrdersRepository.GetAllAsync();
        }

        public async Task<BotOrder> GetBotOrderByIdAsync(long botId)
        {
            return await _botOrdersRepository.GetBotOrderByIdAsync(botId);
        }

        public async Task UpdateBotOrderAsync(BotOrder botOrder)
        {
            if (!BotOrderValidator.ValidateDefault(botOrder))
            {
                throw new InvalidOperationException("BotOrder's validation failed");
            }

            await _botOrdersRepository.UpdateBotOrderAsync(botOrder);
        }
    }
}
