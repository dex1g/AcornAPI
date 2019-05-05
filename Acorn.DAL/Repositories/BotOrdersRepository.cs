using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acorn.BL.Models;
using Acorn.BL.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Acorn.DAL.Repositories
{
    public class BotOrdersRepository : IBotOrdersRepository
    {
        private readonly DatabaseContext _context;

        public BotOrdersRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task AddBotOrderAsync(BotOrder botOrder)
        {
            _context.BotOrders.Add(botOrder);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBotOrderAsync(long botId)
        {
            var botOrderToDelete = await GetBotOrderByIdAsync(botId);

            if (botOrderToDelete != null)
            {
                _context.BotOrders.Remove(botOrderToDelete);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("BotOrder does not exist");
            }
        }

        public async Task<IEnumerable<BotOrder>> GetAllAsync()
        {
            return await _context.BotOrders.ToListAsync();
        }

        public async Task<BotOrder> GetBotOrderByIdAsync(long botId)
        {
            return await _context.BotOrders.FirstOrDefaultAsync(b => b.BotId == botId);
        }

        public async Task UpdateBotOrderAsync(BotOrder botOrder)
        {
            var botOrderToUpdate = await GetBotOrderByIdAsync(botOrder.BotId);

            if (botOrderToUpdate != null)
            {
                _context.Update(botOrder);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("BotOrder does not exist");
            }
        }
    }
}
