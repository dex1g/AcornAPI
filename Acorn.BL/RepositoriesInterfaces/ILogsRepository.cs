using System.Threading.Tasks;
using Acorn.BL.Models;

namespace Acorn.BL.RepositoriesInterfaces
{
    public interface ILogsRepository
    {
        Task<Log> GetByBotId(int botId);
        Task UpdateLogAsync(Log log);
    }
}
