using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acorn.BL.Models;
using Acorn.BL.RepositoriesInterfaces;
using Acorn.BL.Validators;

namespace Acorn.BL.Services
{
    public class LogService : ILogService
    {
        private readonly ILogsRepository _logsRepository;

        public LogService(ILogsRepository logsRepository)
        {
            _logsRepository = logsRepository;
        }

        public async Task<long> CreateNewLogAsync(Log log)
        {
            if (!LogValidator.ValidateDefault(log))
            {
                throw new InvalidOperationException("Log's validation failed");
            }

            return await _logsRepository.AddLogAsync(log);
        }

        public async Task DeleteLogAsync(long logId)
        {
            await _logsRepository.DeleteLogAsync(logId);
        }

        public async Task<IEnumerable<Log>> GetAllLogsAsync()
        {
            return await _logsRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Log>> GetAllLogsByBotIdAsync(int botId)
        {
            return await _logsRepository.GetAllByBotId(botId);
        }

        public async Task<Log> GetLogByIdAsync(long logId)
        {
            return await _logsRepository.GetLogByIdAsync(logId);
        }

        public async Task<Log> GetLatestLogByBotId(int botId)
        {
            return await _logsRepository.GetLatestLogByBotId(botId);
        }

        public async Task UpdateLogAsync(Log log)
        {
            if (!LogValidator.ValidateDefault(log))
            {
                throw new InvalidOperationException("Log's validation failed");
            }

            await _logsRepository.UpdateLogAsync(log);
        }
    }
}
