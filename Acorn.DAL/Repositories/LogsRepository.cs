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

        public async Task<Log> GetByBotId(int botId)
        {
            return await _context.Logs.FirstOrDefaultAsync(log => log.BotId == botId);
        }

        public async Task UpdateLogAsync(Log log)
        {
            _context.Logs.Update(log);
            await _context.SaveChangesAsync();
        }
    }
}