using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acorn.BL.Enums;
using Acorn.BL.Models;
using Acorn.BL.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Acorn.DAL.Repositories
{
    public class BotsRepository : IBotsRepository
    {
        private readonly DatabaseContext _context;

        public BotsRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task AddBotAsync(Bot bot)
        {
            _context.Bots.Add(bot);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBotAsync(long botId)
        {
            var botToDelete = await GetBotByIdAsync(botId);

            if (botToDelete != null)
            {
                _context.Bots.Remove(botToDelete);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException(Resources.BotNotExistString);
            }
        }

        public async Task<IEnumerable<Bot>> GetAllAsync()
        {
            return await _context.Bots.OrderBy(key => key.BotId).ToListAsync();
        }

        public async Task<Bot> GetBotByIdAsync(long botId)
        {
            return await _context.Bots.AsNoTracking().FirstOrDefaultAsync(b => b.BotId == botId);
        }

        public async Task<BotOrder> UpdateBotAsync(Bot bot)
        {
            var botToUpdate = await GetBotByIdAsync(bot.BotId);

            if (botToUpdate != null)
            {
                _context.Bots.Update(bot);
                await _context.SaveChangesAsync();
                return bot.BotOrder;
            }
            else
            {
                throw new InvalidOperationException(Resources.BotNotExistString);
            }
        }
    }
}