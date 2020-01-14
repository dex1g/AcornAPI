using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Acorn.BL.Models;
using Acorn.BL.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Acorn.DAL.Repositories
{
    public class LogsRepository : ILogsRepository
    {
        private readonly DatabaseContext _context;

        public LogsRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<long> AddLogAsync(Log log)
        {
            _context.Logs.Add(log);
            await _context.SaveChangesAsync();

            var addedId = log.LogId;

            return addedId;
        }

        public async Task DeleteLogAsync(long logId)
        {
            var logToDelete = await _context.Logs.FirstOrDefaultAsync(l => l.LogId == logId);

            if (logToDelete != null)
            {
                _context.Logs.Remove(logToDelete);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException(Resources.LogNotExistString);
            }
        }

        public async Task<IEnumerable<Log>> GetAllAsync()
        {
            return await _context.Logs.ToListAsync();
        }

        public async Task<IEnumerable<Log>> GetAllByBotId(int botId)
        {
            var botsToReturn = await _context.Logs.Where(log => log.BotId == botId).OrderByDescending(l => l.Date).ToListAsync();
            return botsToReturn;
        }

        public async Task<Log> GetLogByIdAsync(long logId)
        {
            return await _context.Logs.FirstOrDefaultAsync(l => l.LogId == logId);
        }

        public async Task<Log> GetLatestLogByBotId(int botId)
        {
            var botExists = await _context.Bots.AnyAsync(b => b.BotId == botId);
            if (!botExists)
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, Resources.BotNotExistString, botId));
            return await _context.Logs.Where(l => l.BotId == botId).OrderByDescending(x => x.Date).FirstOrDefaultAsync();
        }

        public async Task UpdateLogAsync(Log log)
        {
            var exists = await _context.Logs.AnyAsync(l => l.LogId == log.LogId);

            if (exists)
            {
                _context.Logs.Update(log);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException(Resources.LogNotExistString);
            }
        }
    }
}