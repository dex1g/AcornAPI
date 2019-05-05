using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acorn.BL.Models;
using Acorn.BL.RepositoriesInterfaces;
using Acorn.BL.Validators;

namespace Acorn.BL.Services
{
    public class ConfigService : IConfigService
    {
        private readonly IConfigsRepository _configsRepository;

        public ConfigService(IConfigsRepository configsRepository)
        {
            _configsRepository = configsRepository;
        }

        public async Task CreateNewConfigAsync(Config config)
        {
            await _configsRepository.AddConfigAsync(config);
        }

        public async Task DeleteConfigAsync(long botId)
        {
            await _configsRepository.DeleteConfigAsync(botId);
        }

        public async Task<IEnumerable<Config>> GetAllConfigsAsync()
        {
            return await _configsRepository.GetAllAsync();
        }

        public async Task<Config> GetConfigByIdAsync(long botId)
        {
            return await _configsRepository.GetConfigByIdAsync(botId);
        }

        public async Task UpdateConfigAsync(Config config)
        {
            if (!ConfigValidator.ValidateDefault(config))
            {
                throw new InvalidOperationException("Config's validation failed");
            }

            await _configsRepository.UpdateConfigAsync(config);
        }
    }
}
