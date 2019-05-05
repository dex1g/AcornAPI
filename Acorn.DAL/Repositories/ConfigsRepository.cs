using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acorn.BL.Models;
using Acorn.BL.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Acorn.DAL.Repositories
{
    public class ConfigsRepository : IConfigsRepository
    {
        private readonly DatabaseContext _context;

        public ConfigsRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task AddConfigAsync(Config config)
        {
            _context.Configs.Add(config);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteConfigAsync(long botId)
        {
            var configToDelete = await GetConfigByIdAsync(botId);

            if (configToDelete != null)
            {
                _context.Configs.Remove(configToDelete);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Config does not exist");
            }
        }

        public async Task<IEnumerable<Config>> GetAllAsync()
        {
            return await _context.Configs.ToListAsync();
        }

        public async Task<Config> GetConfigByIdAsync(long botId)
        {
            return await _context.Configs.FirstOrDefaultAsync(c => c.BotId == botId);
        }

        public async Task UpdateConfigAsync(Config config)
        {
            var configToUpdate = await GetConfigByIdAsync(config.BotId);

            if (configToUpdate != null)
            {
                _context.Update(config);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Config does not exist");
            }
        }
    }
}
