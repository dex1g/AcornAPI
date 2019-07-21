using System;
using System.Collections.Generic;
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

            long addedId = log.LogId;

            return addedId;
        }

        public async Task DeleteLogAsync(long logId)
        {
            var logToDelete = await GetLogByIdAsync(logId);

            if (logToDelete != null)
            {
                _context.Logs.Remove(logToDelete);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Log does not exist");
            }
        }

        public async Task<IEnumerable<Log>> GetAllAsync()
        {
            return await _context.Logs.ToListAsync();
        }

        public async Task<IEnumerable<Log>> GetAllByBotId(int botId)
        {
            var logs = await GetAllAsync();
            var botsToReturn = logs.Where(log => log.BotId == botId);
            return botsToReturn;
        }

        public async Task<Log> GetLogByIdAsync(long logId)
        {
            return await _context.Logs.FirstOrDefaultAsync(l => l.LogId == logId);
        }

        public async Task<Log> GetLatestLogByBotId(int botId)
        {
            var logs = (await GetAllByBotId(botId)).ToArray();
            var latestDate = logs.Max(x => x.Date);
            var log = logs.First(x => x.Date == latestDate);
            return log;
        }

        public async Task UpdateLogAsync(Log log)
        {
            var logToUpdate = await GetLogByIdAsync(log.LogId);

            if (logToUpdate != null)
            {
                _context.Update(log);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Log does not exist");
            }
        }
    }
}