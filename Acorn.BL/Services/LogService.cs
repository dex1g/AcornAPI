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

        public async Task<Log> GetLogByBotId(int botId)
        {
            return await _logsRepository.GetByBotId(botId);
        }

        public async Task UpdateLogAsync(int botId, string message, DateTime date)
        {
            var log = await _logsRepository.GetByBotId(botId) ?? new Log { BotId = botId };
            log.Status = message;
            log.Date = date;

            if (!LogValidator.ValidateDefault(log))
            {
                throw new InvalidOperationException(Resources.LogValidFailString);
            }

            await _logsRepository.UpdateLogAsync(log);
        }
    }
}
