using System.Collections.Generic;
using System.Threading.Tasks;
using Acorn.BL.Models;


namespace Acorn.BL.Services
{
    public interface ILogService
    {
        Task<long> CreateNewLogAsync(Log log);
        Task DeleteLogAsync(long logId);
        Task UpdateLogAsync(Log log);
        Task<IEnumerable<Log>> GetAllLogsAsync();
        Task<Log> GetLogByIdAsync(long logId);
    }
}
