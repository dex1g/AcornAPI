using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acorn.BL.Models;
using Acorn.BL.RepositoriesInterfaces;
using Acorn.BL.Validators;

namespace Acorn.BL.Services
{
    public class BotService : IBotService
    {
        private readonly IBotsRepository _botsRepository;

        public BotService(IBotsRepository botsRepository)
        {
            _botsRepository = botsRepository;
        }

        public async Task CreateNewBotAsync(Bot bot)
        {
            if (!BotValidator.ValidateDefault(bot))
            {
                throw new InvalidOperationException(Resources.BotValidFailString);
            }

            await _botsRepository.AddBotAsync(bot);
        }

        public async Task DeleteBotAsync(long botId)
        {
            await _botsRepository.DeleteBotAsync(botId);
        }

        public async Task<IEnumerable<Bot>> GetAllBotsAsync()
        {
            return await _botsRepository.GetAllAsync();
        }

        public async Task<Bot> GetBotByIdAsync(long botId)
        {
            return await _botsRepository.GetBotByIdAsync(botId);
        }

        public async Task UpdateBotAsync(Bot bot)
        {
            if (!BotValidator.ValidateDefault(bot))
            {
                throw new InvalidOperationException(Resources.BotValidFailString);
            }

            await _botsRepository.UpdateBotAsync(bot);
        }
    }
}
