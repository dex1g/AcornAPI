using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acorn.BL.Enums;
using Acorn.BL.Models;
using Acorn.BL.RepositoriesInterfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Acorn.DAL.Repositories
{
    public class BotsRepository : IBotsRepository
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public BotsRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddBotAsync(Bot bot)
        {
            var exists = await _context.Bots.AnyAsync(b => b.BotId == bot.BotId);
            if (exists)
                throw new InvalidOperationException(Resources.BotAlreadyExistString);

            bot.Config = new Config { Bot = bot, BotId = bot.BotId };
            var log = new Log { Bot = bot, BotId = bot.BotId, Date = DateTime.Now, Status = "Created new bot" };
            _context.Bots.Add(bot);
            _context.Logs.Add(log);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBotAsync(long botId)
        {
            var botToDelete = await _context.Bots.FirstOrDefaultAsync(b => b.BotId == botId);

            if (botToDelete != null)
            {
                var accounts = _context.Accounts.Where(a => a.BotId == botToDelete.BotId);
                var freshAccs = _mapper.Map<IEnumerable<FreshAccount>>(accounts);

                _context.Accounts.RemoveRange(accounts);
                _context.FreshAccounts.AddRange(freshAccs);
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

        public async Task<Bot> GetBotByIdAsync(int botId)
        {
            return await _context.Bots.FindAsync(botId);
        }

        public async Task SetAllBotOrdersAsync(BotOrder order)
        {
            var bots = await _context.Bots.ToListAsync();

            foreach (var bot in bots)
                bot.BotOrder = order;

            await _context.SaveChangesAsync();
        }

        public async Task<BotOrder> UpdateBotAsync(Bot bot)
        {
            var exists = await _context.Bots.AnyAsync(b => b.BotId == bot.BotId);

            if (exists)
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