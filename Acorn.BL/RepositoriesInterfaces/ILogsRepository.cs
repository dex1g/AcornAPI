using System.Collections.Generic;
using System.Threading.Tasks;
using Acorn.BL.Models;


namespace Acorn.BL.RepositoriesInterfaces
{
    public interface ILogsRepository
    {
        Task<long> AddLogAsync(Log log);
        Task DeleteLogAsync(long logId);
        Task UpdateLogAsync(Log log);
        Task<IEnumerable<Log>> GetAllAsync();
        Task<Log> GetLogByIdAsync(long logId);
        Task<IEnumerable<Log>> GetAllByBotId(int botId);
        Task<Log> GetLatestLogByBotId(int botId);
    }
}
