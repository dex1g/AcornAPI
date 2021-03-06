﻿using System;
using System.Collections.Generic;
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
            var configToDelete = await _context.Configs.FirstOrDefaultAsync(c => c.BotId == botId);

            if (configToDelete != null)
            {
                _context.Configs.Remove(configToDelete);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException(Resources.ConfigNotExistString);
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
            var exists = await _context.Configs.AnyAsync(c => c.BotId == config.BotId);

            if (exists)
            {
                _context.Configs.Update(config);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException(Resources.ConfigNotExistString);
            }
        }
    }
}
