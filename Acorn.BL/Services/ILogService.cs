using System;
using System.Threading.Tasks;
using Acorn.BL.Models;

namespace Acorn.BL.Services
{
    public interface ILogService
    {
        Task<Log> GetLogByBotId(int botId);
        Task UpdateLogAsync(int botId, string message, DateTime date);
    }
}
